using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.ValueObjects;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.Processors.Repositories;

namespace Kessewa.Quiz.Processors
{
    [Processor]
    public class UserProcessor
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public UserProcessor(IUserRepository userRepository, IMapper mapper,
            IDepartmentRepository departmentRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<int> SaveAsync(UserCommand command)
        {
            var isNew = command.Id == default;
            await BuildUserCommand(command);

            Users user;
            if (isNew)
            {
                user = Users.Create(command.FirstName, command.LastName);
            }
            else
            {
                user = await _userRepository.GetAsync(command.Id);
                user.WithFirstName(command.FirstName)
                    .WithLastName(command.LastName);
            }

            user.WithDisplayName(command.DisplayName)
                .WithEmail(Email.Create(command.Email.EmailAddress))
                .OfType(command.Type)
                .WithPhone(Phone.Create(command.Phone.PhoneNumber))
                .WithAddress(Address.Create(command.Address.City, command.Address.Street))
                .WithDepartmentId(command.DepartmentId)
                .InDepartment(_mapper.Map<Departments>(command.Department));

            if (isNew)
                await _userRepository.InsertAsync(user);
            else
                await _userRepository.UpdateAsync(user);

            return user.Id;
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<PaginatedList<UserPageDto>> GetPageAsync(PaginatedCommand command)
        {
            var users = await _userRepository.GetPage(command, new CancellationToken());
            return _mapper.Map<PaginatedList<UserPageDto>>(users);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);
            await _userRepository.DeleteAsync(user, new CancellationToken());
        }


        private async Task BuildUserCommand(UserCommand command)
        {
            if (command.DepartmentId == default) return;
            var department = await _departmentRepository.GetAsync(command.DepartmentId);
            command.Department = _mapper.Map<DepartmentCommand>(department);
        }
    }
}