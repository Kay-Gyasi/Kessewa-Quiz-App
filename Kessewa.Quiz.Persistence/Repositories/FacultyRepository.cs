using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.ViewModels;
using Kessewa.Quiz.Persistence.DatabaseContext;
using Kessewa.Quiz.Persistence.Repositories.Base;
using Kessewa.Quiz.Processors.Repositories;
using Microsoft.Extensions.Logging;

namespace Kessewa.Quiz.Persistence.Repositories
{
    public class FacultyRepository : RepositoryBase<Faculties>, IFacultyRepository
    {
        public FacultyRepository(KessewaDbContext context, ILogger<Faculties> logger) : base(context, logger)
        {
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