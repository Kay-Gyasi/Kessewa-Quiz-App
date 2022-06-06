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
    public class CourseProcessor
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly ILecturerRepository _lecturerRepository;

        public CourseProcessor(ICourseRepository courseRepository,
            IMapper mapper, ILecturerRepository lecturerRepository)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _lecturerRepository = lecturerRepository;
        }

        public async Task<int> SaveAsync(CourseCommand command)
        {
            var isNew = command.Id == default;
            await BuildCourseCommand(command);

            Courses course;
            if (isNew)
            {

                course = Courses.Create(command.Name);
            }
            else
            {
                course = await _courseRepository.GetAsync(command.Id);
                course.WithName(command.Name);
            }

            course.ForLecturer(_mapper.Map<Lecturers>(command.Lecturer))
                .WithLecturerId(command.LecturerId)
                .WithDescription(command.Description)
                .ForLevel(command.Level)
                .HasCreditHours(command.CreditHours);

            if (isNew)
                await _courseRepository.InsertAsync(course);
            else
                await _courseRepository.UpdateAsync(course);
            return course.Id;
        }

        public async Task<PaginatedList<CoursePageDto>> GetPage(PaginatedCommand command)
        {
            var page = await _courseRepository.GetPage(command, new CancellationToken());
            return _mapper.Map<PaginatedList<CoursePageDto>>(page);
        }

        public async Task DeleteAsync(int courseId)
        {
            var course = await _courseRepository.GetAsync(courseId);
            await _courseRepository.DeleteAsync(course, new CancellationToken());
        }


        private async Task BuildCourseCommand(CourseCommand command)
        {
            if (command.LecturerId != 0)
            {
                command.Lecturer = _mapper.Map<LecturerCommand>(await _lecturerRepository.GetAsync(command.LecturerId));
            }
        }
    }
}