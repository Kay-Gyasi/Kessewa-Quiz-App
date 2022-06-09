using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.ValueObjects;
using Kessewa.Quiz.Persistence.DatabaseContext;
using Kessewa.Quiz.Processors.Repositories;
using Kessewa.Quiz.Processors.Repositories.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Persistence.Repositories.Administration
{
    [Repository]
    public class InitializeDbRepository : IInitializeDbRepository
    {
        private readonly KessewaDbContext _context;
        private readonly ILogger<KessewaDbContext> _logger;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IQuestionRepository _questionRepository;

        public InitializeDbRepository(KessewaDbContext context, ILogger<KessewaDbContext> logger,
            IFacultyRepository facultyRepository,
            IDepartmentRepository departmentRepository,
            IUserRepository userRepository, 
            ILecturerRepository lecturerRepository,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IQuizRepository quizRepository,
            IQuestionRepository questionRepository)
        {
            _context = context;
            _logger = logger;
            _facultyRepository = facultyRepository;
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
            _lecturerRepository = lecturerRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _quizRepository = quizRepository;
            _questionRepository = questionRepository;
        }

        public async Task InitializeDb()
        {
            try
            {
                await AddMigrations();
                await SeedFaculties();
                await SeedDepartments();
                await SeedUsers();
                await SeedLecturers();
                await SeedStudents();
                await SeedCourses();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while initializing database");
                throw;
            }
        }


        private async Task AddMigrations()
        {
            await _context.Database.MigrateAsync();
        }

        private async Task SeedFaculties()
        {
            if (await IsInitialized<Faculties>()) return;
            var faculties = new List<Faculties>
            {
                Faculties.Create("Faculty of Engineering"),
                Faculties.Create("Faculty of Mineralogy"),
            };
            await _facultyRepository.InsertAsync(faculties);
        }

        private async Task SeedDepartments()
        {
            if (await IsInitialized<Departments>()) return;
            var departments = new List<Departments>
            {
                Departments.Create("Computer Science and Engineering", 1)
                    .WithEmail(Email.Create("kaygyasidev@gmail.com"))
                    .WithPhone(Phone.Create("+966505555555")),
                Departments.Create("Mineral Sciences", 2)
                    .WithEmail(Email.Create("nanafobil@gmail.com"))
                    .WithPhone(Phone.Create("+966505555555")),
            };
            await _departmentRepository.InsertAsync(departments);
        }

        private async Task SeedUsers()
        {
            if (await IsInitialized<Users>()) return;
            var users = new List<Users>
            {
                Users.Create("Jeremiah", "Gyasi")
                    .WithEmail(Email.Create("kaygyasi715@gmail.com"))
                    .WithDisplayName("Prof. Gyasi")   
                    .OfType(UserType.Lecturer)
                    .WithPhone(Phone.Create("0557833216"))
                    .WithAddress(Address.Create("Takoradi", "I.Adu-Anaji Rd."))
                    .WithDepartmentId(2),
                Users.Create("Samuel", "Woode")
                    .WithEmail(Email.Create("nanafobil@gmail.com"))
                    .WithDisplayName("Doc. Woode")
                    .OfType(UserType.Student)
                    .WithPhone(Phone.Create("0557511677"))
                    .WithAddress(Address.Create("Tarkwa", "Cyanide Rd."))
                    .WithDepartmentId(1),
            };
            await _userRepository.InsertAsync(users, new CancellationToken());
        }

        private async Task SeedLecturers()
        {
            if (await IsInitialized<Lecturers>()) return;
            var lecturers = new List<Lecturers>
            {
                Lecturers.Create(1, LecturerType.AssistantLecturer)
            };
            await _lecturerRepository.InsertAsync(lecturers, new CancellationToken());
        }

        private async Task SeedStudents()
        {
            if (await IsInitialized<Students>()) return;
            var students = new List<Students>
            {
                Students.Create(2)
                    .AtLevel(LevelType.Third)
            };
            await _studentRepository.InsertAsync(students, new CancellationToken());
        }

        private async Task SeedCourses()
        {
            if (await IsInitialized<Courses>()) return;
            var courses = new List<Courses>
            {
                Courses.Create("Data Structures")
                    .WithLecturerId(1)
                    .HasCreditHours(CreditHours.Three)
                    .ForLevel(LevelType.Third),
                Courses.Create("Operating Systems")
                    .WithLecturerId(1)
                    .HasCreditHours(CreditHours.Three)
                    .ForLevel(LevelType.Third),
            };
            await _courseRepository.InsertAsync(courses, new CancellationToken());
        }

        //private async Task SeedQuizzes()
        //{
        //    if (await IsInitialized<Courses>()) return;
        //    var quizzes = new List<Quizzes>
        //    {
        //        Quizzes.Create("Init", 1) // continue
        //    };
        //}


        private async Task<bool> IsInitialized<T>() where T : class
        {
            return await _context.Set<T>().AnyAsync();
        }
    }
}