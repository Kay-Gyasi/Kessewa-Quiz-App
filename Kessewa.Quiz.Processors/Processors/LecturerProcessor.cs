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
    public class LecturerProcessor
    {
        private readonly ILecturerRepository _lecturerRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public LecturerProcessor(ILecturerRepository lecturerRepository, IMapper mapper,
            IUserRepository userRepository)
        {
            _lecturerRepository = lecturerRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<int> SaveAsync(LecturerCommand command)
        {
            var isNew = command.Id == default;
            await BuildLecturerCommand(command);

            Lecturers lecturer;
            if (isNew)
            {
                lecturer = Lecturers.Create(command.UserId, command.Type);
            }
            else
            {
                lecturer = await _lecturerRepository.GetAsync(command.Id);
                lecturer.OfType(command.Type)
                    .WithUserId(command.UserId);
            }

            lecturer.ForUser(_mapper.Map<Users>(command.User));

            if (isNew)
                await _lecturerRepository.InsertAsync(lecturer);
            else
                await _lecturerRepository.UpdateAsync(lecturer);

            return lecturer.Id;
        }

        public async Task<LecturerDto> GetAsync(int id)
        {
            var lecturer = await _lecturerRepository.GetAsync(id);
            return _mapper.Map<LecturerDto>(lecturer);
        }

        public async Task<PaginatedList<LecturerPageDto>> GetPageAsync(PaginatedCommand command)
        {
            var lecturers = await _lecturerRepository.GetPage(command, new CancellationToken());
            return _mapper.Map<PaginatedList<LecturerPageDto>>(lecturers);
        }

        public async Task DeleteAsync(int id)
        {
            var lecturer = await _lecturerRepository.GetAsync(id);
            await _lecturerRepository.DeleteAsync(lecturer, new CancellationToken());
        }

        private async Task BuildLecturerCommand(LecturerCommand command)
        {
            if (command.UserId == default) return;
            var user = await _userRepository.GetAsync(command.UserId);
            command.User = _mapper.Map<UserCommand>(user);
        }
    }
}