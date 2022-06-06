using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class FacultyRepository : RepositoryBase<Faculties>, IFacultyRepository
    {
        public FacultyRepository(KessewaDbContext context, ILogger<Faculties> logger) : base(context, logger)
        {
        }

        public override Expression<Func<Faculties, bool>> GetSearchCondition(string search)
        {
            return x => EF.Functions.Like(x.Name, $"%{search}%") ||
                        EF.Functions.Like(x.Description, $"%{search}%");
        }

        public override async Task<List<Lookup>> GetLookupAsync()
        {
            var faculties = await GetAllAsync();
            return faculties.Select(x => new Lookup
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}