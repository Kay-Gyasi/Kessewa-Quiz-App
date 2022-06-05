using System.Linq;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Persistence.DatabaseContext;
using Kessewa.Quiz.Persistence.Repositories.Base;
using Kessewa.Quiz.Processors.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kessewa.Quiz.Persistence.Repositories
{
    [Repository]
    public class StudentRepository : RepositoryBase<Students>, IStudentRepository
    {
        public StudentRepository(KessewaDbContext context, ILogger<Students> logger) : base(context, logger)
        {
        }

        public override IQueryable<Students> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(x => x.User);
        }
    }
}