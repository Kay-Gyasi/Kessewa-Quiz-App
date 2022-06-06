using AutoMapper;
using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Dtos.PageDtos;

namespace Kessewa.Quiz.Processors.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Courses, CourseDto>().ReverseMap();
            CreateMap<Courses, CoursePageDto>().ReverseMap();
            CreateMap<PaginatedList<Courses>, PaginatedList<CoursePageDto>>().ReverseMap();
            CreateMap<Courses, CourseCommand>().ReverseMap();

            CreateMap<Departments, DepartmentDto>().ReverseMap();
            CreateMap<Departments, DepartmentPageDto>().ReverseMap();
            CreateMap<PaginatedList<Departments>, PaginatedList<DepartmentPageDto>>().ReverseMap();
            CreateMap<Departments, DepartmentCommand>().ReverseMap();

            CreateMap<Faculties, FacultyDto>().ReverseMap();
            CreateMap<Faculties, FacultyPageDto>().ReverseMap();
            CreateMap<PaginatedList<Faculties>, PaginatedList<FacultyPageDto>>().ReverseMap();
            CreateMap<Faculties, FacultyCommand>().ReverseMap();

            CreateMap<Lecturers, LecturerDto>().ReverseMap();
            CreateMap<Lecturers, LecturerPageDto>().ReverseMap();
            CreateMap<PaginatedList<Lecturers>, PaginatedList<LecturerPageDto>>().ReverseMap();
            CreateMap<Lecturers, LecturerCommand>().ReverseMap();

            CreateMap<Questions, QuestionDto>().ReverseMap();
            CreateMap<Questions, QuestionPageDto>().ReverseMap();
            CreateMap<PaginatedList<Questions>, PaginatedList<QuestionPageDto>>().ReverseMap();
            CreateMap<Questions, QuestionCommand>().ReverseMap();

            CreateMap<Quizzes, QuizDto>().ReverseMap();
            CreateMap<Quizzes, QuizPageDto>().ReverseMap();
            CreateMap<PaginatedList<Quizzes>, PaginatedList<QuizPageDto>>().ReverseMap();
            CreateMap<Quizzes, QuizCommand>().ReverseMap();

            CreateMap<Students, StudentDto>().ReverseMap();
            CreateMap<Students, StudentPageDto>().ReverseMap();
            CreateMap<PaginatedList<Students>, PaginatedList<StudentPageDto>>().ReverseMap();
            CreateMap<Students, StudentCommand>().ReverseMap();

            CreateMap<Submissions, SubmissionDto>().ReverseMap();
            CreateMap<Submissions, SubmissionPageDto>().ReverseMap();
            CreateMap<PaginatedList<Submissions>, PaginatedList<SubmissionPageDto>>().ReverseMap();
            CreateMap<Submissions, SubmissionCommand>().ReverseMap();

            CreateMap<Users, UserDto>().ReverseMap();
            CreateMap<Users, UserPageDto>().ReverseMap();
            CreateMap<PaginatedList<Users>, PaginatedList<UserPageDto>>().ReverseMap();
            CreateMap<Users, UserCommand>().ReverseMap();
        }
    }
}

