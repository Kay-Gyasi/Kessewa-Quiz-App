using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.Processors.Repositories;

namespace Kessewa.Quiz.Processors.Processors
{
    [Processor]
    public class QuestionProcessor
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly IQuizRepository _quizRepository;

        public QuestionProcessor(IQuestionRepository questionRepository, IMapper mapper,
            IQuizRepository quizRepository)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _quizRepository = quizRepository;
        }

        public async Task<int> SaveAsync(QuestionCommand command)
        {
            var isNew = command.Id == default;
            await BuildQuestionCommand(command);

            Questions question;
            if (isNew)
            {
                question = Questions.Create(command.QuizId);
            }
            else
            {
                question = await _questionRepository.GetAsync(command.Id);
                question.WithQuizId(command.QuizId);
            }

            question.HasMarks(command.MarksAllocated)
                .WithQuestion(command.Question)
                .WithOptions(command.Options)
                .ForQuiz(_mapper.Map<Quizzes>(command.Quiz));

            if (isNew)
                await _questionRepository.InsertAsync(question);
            else
                await _questionRepository.UpdateAsync(question);

            return question.Id;
        }

        public async Task<QuestionDto> GetAsync(int id)
        {
            var question = await _questionRepository.GetAsync(id);
            return _mapper.Map<QuestionDto>(question);
        }
        
        public async Task<PaginatedList<QuestionPageDto>> GetPageAsync(PaginatedCommand command)
        {
            var question = await _questionRepository.GetPage(command, new CancellationToken());
            return _mapper.Map<PaginatedList<QuestionPageDto>>(question);
        }

        public async Task DeleteAsync(int id)
        {
            var question = await _questionRepository.GetAsync(id);
            await _questionRepository.DeleteAsync(question, new CancellationToken());
        }
        

        private async Task BuildQuestionCommand(QuestionCommand command)
        {
            if (command.QuizId == default) return;
            var quiz = await _quizRepository.GetAsync(command.QuizId);
            command.Quiz = _mapper.Map<QuizCommand>(quiz);
        }
    }
}