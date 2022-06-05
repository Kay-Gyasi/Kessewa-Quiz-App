using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.ViewModels;
using Kessewa.Quiz.Persistence.DatabaseContext;
using Kessewa.Quiz.Persistence.Repositories.Base;
using Kessewa.Quiz.Processors.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kessewa.Quiz.Persistence.Repositories
{
    public class CourseRepository : RepositoryBase<Courses>, ICourseRepository
    {
        public CourseRepository(KessewaDbContext context, ILogger<Courses> logger) : base(context, logger)
        {
        }

        public override IQueryable<Courses> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(k => k.Lecturer)
                .Include(k => k.Departments);
        }

        public override async Task<List<Lookup>> GetLookupAsync()
        {
            var courses = await GetAllAsync();
            return courses.Select(k => new Lookup
            {
                Id = k.Id,
                Name = k.Name
            }).ToList();
        }
    }
}
