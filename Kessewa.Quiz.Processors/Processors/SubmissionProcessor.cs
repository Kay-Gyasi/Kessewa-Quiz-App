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
    public class SubmissionProcessor
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IMapper _mapper;
        private readonly IQuizRepository _quizRepository;
        private readonly IStudentRepository _studentRepository;

        public SubmissionProcessor(ISubmissionRepository submissionRepository, IMapper mapper,
            IQuizRepository quizRepository, IStudentRepository studentRepository)
        {
            _submissionRepository = submissionRepository;
            _mapper = mapper;
            _quizRepository = quizRepository;
            _studentRepository = studentRepository;
        }

        public async Task<int> SaveAsync(SubmissionCommand command)
        {
            var isNew = command.Id == default;
            await BuildSubmissionCommand(command);

            Submissions submission;
            if (isNew)
            {
                submission = Submissions.Create(command.QuizId, command.StudentId);
            }
            else
            {
                submission = await _submissionRepository.GetAsync(command.Id);
                submission.WithQuizId(command.QuizId)
                    .WithStudentId(command.StudentId);
            }

            submission.ForStudent(_mapper.Map<Students>(command.Student))
                .ForQuiz(_mapper.Map<Quizzes>(command.Quiz))
                .WasSubmittedAt(command.TimeSubmitted)
                .WithChoices(command.Choices);

            if (isNew)
                await _submissionRepository.InsertAsync(submission);
            else
                await _submissionRepository.UpdateAsync(submission);

            return submission.Id;
        }

        public async Task<PaginatedList<SubmissionPageDto>> GetPageAsync(PaginatedCommand command)
        {
            var submissions = await _submissionRepository.GetPage(command, new CancellationToken());
            return _mapper.Map<PaginatedList<SubmissionPageDto>>(submissions);
        }

        public async Task<SubmissionDto> GetAsync(int id)
        {
            var submission = await _submissionRepository.GetAsync(id);
            return _mapper.Map<SubmissionDto>(submission);
        }
        
        public async Task DeleteAsync(int id)
        {
            var submission = await _submissionRepository.GetAsync(id);
            await _submissionRepository.DeleteAsync(submission, new CancellationToken());
        }



        private async Task BuildSubmissionCommand(SubmissionCommand command)
        {
            var quiz = command.QuizId != default ? await _quizRepository.GetAsync(command.QuizId) : null;
            var student = command.StudentId != default ? await _studentRepository.GetAsync(command.StudentId) : null;

            if (quiz != null) command.Quiz = _mapper.Map<QuizCommand>(quiz);
            if (student != null) command.Student = _mapper.Map<StudentCommand>(student);
        }
    }
}