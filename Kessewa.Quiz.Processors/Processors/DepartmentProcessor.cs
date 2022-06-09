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

namespace Kessewa.Quiz.Processors.Processors
{
    [Processor]
    public class DepartmentProcessor
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFacultyRepository _facultyRepository;

        public DepartmentProcessor(IDepartmentRepository departmentRepository,
            IFacultyRepository facultyRepository, 
            IMapper mapper)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
            _facultyRepository = facultyRepository;
        }

        public async Task<int> SaveAsync(DepartmentCommand command)
        {
            var isNew = command.Id == default;
            await BuildFacultyCommand(command);

            Departments department;
            if (isNew)
            {
                department = Departments.Create(command.Name, command.FacultyId);
            }
            else
            {
                department = await _departmentRepository.GetAsync(command.Id);
                department.WithName(command.Name)
                    .WithFacultyId(command.FacultyId);
            }

            department.WithDescription(command.Description)
                .WithEmail(Email.Create(command.Email.EmailAddress))
                .WithPhone(Phone.Create(command.Phone.PhoneNumber))
                .ForFaculty(_mapper.Map<Faculties>(command.Faculty));
            
            if (isNew)
                await _departmentRepository.InsertAsync(department);
            else
                await _departmentRepository.UpdateAsync(department);

            return department.Id;
        }

        public async Task<PaginatedList<DepartmentPageDto>> GetPageAsync(PaginatedCommand command)
        {
            return _mapper.Map<PaginatedList<DepartmentPageDto>>(
                await _departmentRepository.GetPage(command, new CancellationToken()));
        }

        public async Task<DepartmentDto> GetAsync(int id)
        {
            var department = await _departmentRepository.GetAsync(id);
            return department != null ? _mapper.Map<DepartmentDto>(department) : null;
        }

        public async Task DeleteAsync(int id)
        {
            var department = await _departmentRepository.GetAsync(id);
            if (department != null)
                await _departmentRepository.DeleteAsync(department, new CancellationToken());

        }

        private async Task BuildFacultyCommand(DepartmentCommand command)
        {
            if (command.FacultyId == default) return;
            var faculty = await _facultyRepository.GetAsync(command.FacultyId);
            command.Faculty = _mapper.Map<FacultyCommand>(faculty);
        }
    }
}