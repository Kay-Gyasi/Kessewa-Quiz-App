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
    public class QuestionRepository : RepositoryBase<Questions>, IQuestionRepository
    {
        public QuestionRepository(KessewaDbContext context, ILogger<Questions> logger) : base(context, logger)
        {
        }

        public override IQueryable<Questions> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(x => x.Quiz)
                .Include(x => x.Options);
        }
    }
}