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
    public class QuizProcessor
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IMapper _mapper;

        public QuizProcessor(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }

        public async Task<int> SaveAsync(QuizCommand command)
        {
            var isNew = command.Id == default;
            await BuildQuizCommand(command);

            Quizzes quiz;
            if (isNew)
            {
                quiz = Quizzes.Create(command.Name, command.CourseId);
            }
            else
            {
                quiz = await _quizRepository.GetAsync(command.Id);
                quiz.WithName(command.Name)
                    .WithCourseId(command.CourseId);
            }

            quiz.ToBeTakenOn(command.DateToBeTaken)
                .ToBeTakenAt(command.TimeToBeTaken)
                .WithDuration(command.Duration)
                .ForCourse(_mapper.Map<Courses>(command.Course));

            if (isNew)
                await _quizRepository.InsertAsync(quiz);
            else
                await _quizRepository.UpdateAsync(quiz);

            return quiz.Id;
        }

        public async Task<PaginatedList<QuizPageDto>> GetPageAsync(PaginatedCommand command)
        {
            var quizzes = await _quizRepository.GetPage(command, new CancellationToken());
            return _mapper.Map<PaginatedList<QuizPageDto>>(quizzes);
        }

        public async Task<QuizDto> GetAsync(int quizId)
        {
            var quiz = await _quizRepository.GetAsync(quizId);
            return _mapper.Map<QuizDto>(quiz);
        }

        public async Task DeleteAsync(int quizId)
        {
            var quiz = await _quizRepository.GetAsync(quizId);
            await _quizRepository.DeleteAsync(quiz, new CancellationToken());
        }


        private async Task BuildQuizCommand(QuizCommand command)
        {
            if (command.CourseId == default) return;
            var course = await _quizRepository.GetAsync(command.CourseId);
            command.Course = _mapper.Map<CourseCommand>(course);
        }
    }
}