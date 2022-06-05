using System.Linq;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Persistence.DatabaseContext;
using Kessewa.Quiz.Persistence.Repositories.Base;
using Kessewa.Quiz.Processors.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kessewa.Quiz.Persistence.Repositories
{
    public class SubmissionRepository : RepositoryBase<Submissions>, ISubmissionRepository
    {
        public SubmissionRepository(KessewaDbContext context, ILogger<Submissions> logger) : base(context, logger)
        {
        }

        public override IQueryable<Submissions> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(x => x.Quiz)
                .Include(x => x.Student)
                .Include(x => x.Choices);
        }
    }
}