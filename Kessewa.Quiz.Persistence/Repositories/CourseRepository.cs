using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    [Repository]
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

        protected override Expression<Func<Courses, bool>> GetSearchCondition(string search)
        {
            return x => EF.Functions.Like(x.Name, $"%{search}%") ||
                        EF.Functions.Like(x.Level.ToString(), $"%{search}%") ||
                        EF.Functions.Like(x.Lecturer.User.DisplayName, $"%{search}%") ||
                        EF.Functions.Like(x.CreditHours.ToString(), $"%{search}%");
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
