using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.ValueObjects;
using Kessewa.Quiz.Persistence.DatabaseContext;
using Kessewa.Quiz.Processors.Repositories;
using Kessewa.Quiz.Processors.Repositories.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kessewa.Quiz.Persistence.Repositories.Administration
{
    [Repository]
    public class InitializeDbRepository : IInitializeDbRepository
    {
        private readonly KessewaDbContext _context;
        private readonly ILogger<KessewaDbContext> _logger;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public InitializeDbRepository(KessewaDbContext context, ILogger<KessewaDbContext> logger,
            IFacultyRepository facultyRepository,
            IDepartmentRepository departmentRepository)
        {
            _context = context;
            _logger = logger;
            _facultyRepository = facultyRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task InitializeDb()
        {
            try
            {
                await SeedDb();
                await SeedFaculties();
                await SeedDepartments();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while initializing database");
                throw;
            }
        }


        private async Task SeedDb()
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



        private async Task<bool> IsInitialized<T>() where T : class
        {
            return await _context.Set<T>().AnyAsync();
        }
    }
}