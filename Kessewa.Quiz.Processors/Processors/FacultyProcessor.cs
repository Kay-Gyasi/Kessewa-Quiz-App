using System.Linq;
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
    public class FacultyProcessor
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;

        public FacultyProcessor(IFacultyRepository facultyRepository, IMapper mapper)
        {
            _facultyRepository = facultyRepository;
            _mapper = mapper;
        }

        public async Task<int> SaveAsync(FacultyCommand command)
        {
            var isNew = command.Id == default;

            Faculties faculty;
            if (isNew)
            {
                faculty = Faculties.Create(command.Name);
            }
            else
            {
                faculty = await _facultyRepository.GetAsync(command.Id);
            }

            faculty.WithDescription(command.Description);

            if (isNew)
                await _facultyRepository.InsertAsync(faculty);
            else
                await _facultyRepository.UpdateAsync(faculty);

            return faculty.Id;
        }

        public async Task<PaginatedList<FacultyPageDto>> GetPage(PaginatedCommand command)
        {
            var faculties = await _facultyRepository.GetPage(command, new CancellationToken());
            return _mapper.Map<PaginatedList<FacultyPageDto>>(faculties);
        }

        public async Task<FacultyDto> GetAsync(int id)
        {
            var faculty = await _facultyRepository.GetAsync(id);
            return _mapper.Map<FacultyDto>(faculty);
        }

        public async Task DeleteAsync(int id)
        {
            var faculty = await _facultyRepository.GetAsync(id);
            await _facultyRepository.DeleteAsync(faculty, new CancellationToken());
        }
    }
}