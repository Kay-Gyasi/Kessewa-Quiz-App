using System.Collections.Generic;
using System.Linq;
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
    public class DepartmentRepository : RepositoryBase<Departments>, IDepartmentRepository
    {
        public DepartmentRepository(KessewaDbContext context, ILogger<Departments> logger) : base(context, logger)
        {
        }

        public override IQueryable<Departments> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(x => x.Courses)
                .Include(x => x.Faculty)
                .Include(x => x.Users);
        }

        public override async Task<List<Lookup>> GetLookupAsync()
        {
            var departments = await GetAllAsync();
            return departments.Select(x => new Lookup
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}