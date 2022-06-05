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
    public class LecturerRepository : RepositoryBase<Lecturers>, ILecturerRepository
    {
        public LecturerRepository(KessewaDbContext context, ILogger<Lecturers> logger) : base(context, logger)
        {
        }

        public override IQueryable<Lecturers> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(x => x.Courses)
                .Include(x => x.User);
        }

        public override async Task<List<Lookup>> GetLookupAsync()
        {
            var lecturers = await GetAllAsync();
            return lecturers.Select(x => new Lookup
            {
                Id = x.Id,
                Name = x.User.DisplayName ?? x.User.FirstName + " " + x.User.LastName,
            }).ToList();
        }
    }
}