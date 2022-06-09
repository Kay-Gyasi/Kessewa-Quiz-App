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
    public class StudentProcessor
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public StudentProcessor(IStudentRepository studentRepository, IMapper mapper,
            IUserRepository userRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<int> SaveAsync(StudentCommand command)
        {
            var isNew = command.Id == default;
            await BuildStudentCommand(command);

            Students student;
            if (isNew)
            {
                student = Students.Create(command.UserId);
            }
            else
            {
                student = await _studentRepository.GetAsync(command.Id);
                student.WithUserId(command.UserId);
            }

            student.ForUser(_mapper.Map<Users>(command.User))
                .AtLevel(command.Level);

            if (isNew)
                await _studentRepository.InsertAsync(student);
            else
                await _studentRepository.UpdateAsync(student);

            return student.Id;
        }

        public async Task<StudentDto> GetAsync(int id)
        {
            var student = await _studentRepository.GetAsync(id);
            return _mapper.Map<StudentDto>(student);
        }
        
        public async Task<PaginatedList<StudentPageDto>> GetPageAsync(PaginatedCommand command)
        {
            var student = await _studentRepository.GetPage(command, new CancellationToken());
            return _mapper.Map< PaginatedList<StudentPageDto>>(student);
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _studentRepository.GetAsync(id);
            await _studentRepository.DeleteAsync(student, new CancellationToken());
        }


        private async Task BuildStudentCommand(StudentCommand command)
        {
            if (command.UserId == default) return;
            var user = await _userRepository.GetAsync(command.UserId);
            command.User = _mapper.Map<UserCommand>(user);
        }
    }
}