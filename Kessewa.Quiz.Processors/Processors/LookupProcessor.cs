using System.Collections.Generic;
using System.Threading.Tasks;
using Kessewa.Quiz.Domain.ViewModels;
using Kessewa.Quiz.Processors.Repositories;

namespace Kessewa.Quiz.Processors.Processors
{
    [Processor]
    public class LookupProcessor
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IUserRepository _userRepository;

        public LookupProcessor(ICourseRepository courseRepository, ILecturerRepository lecturerRepository,
            IDepartmentRepository departmentRepository, IFacultyRepository facultyRepository,
            IQuestionRepository questionRepository, IQuizRepository quizRepository, IStudentRepository studentRepository,
            ISubmissionRepository submissionRepository, IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _lecturerRepository = lecturerRepository;
            _departmentRepository = departmentRepository;
            _facultyRepository = facultyRepository;
            _questionRepository = questionRepository;
            _quizRepository = quizRepository;
            _studentRepository = studentRepository;
            _submissionRepository = submissionRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Lookup>> GetLookup(LookupType type)
        {
            return type switch
            {
                LookupType.Courses => await _courseRepository.GetLookupAsync(),
                LookupType.Lecturers => await _lecturerRepository.GetLookupAsync(),
                LookupType.Departments => await _departmentRepository.GetLookupAsync(),
                LookupType.Faculties => await _facultyRepository.GetLookupAsync(),
                LookupType.Questions => await _questionRepository.GetLookupAsync(),
                LookupType.Quizzes => await _quizRepository.GetLookupAsync(),
                LookupType.Students => await _studentRepository.GetLookupAsync(),
                LookupType.Submissions => await _submissionRepository.GetLookupAsync(),
                LookupType.Users => await _userRepository.GetLookupAsync(),
                _ => new List<Lookup>(),
            };
        }
    }

    public enum LookupType
    {
        Courses = 1,
        Departments,
        Faculties,
        Lecturers,
        Questions,
        Quizzes,
        Students,
        Submissions,
        Users
    }
}