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
    public class QuizRepository : RepositoryBase<Quizzes>, IQuizRepository
    {
        public QuizRepository(KessewaDbContext context, ILogger<Quizzes> logger) : base(context, logger)
        {
        }

        public override IQueryable<Quizzes> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(x => x.Course)
                .Include(x => x.Questions);
            //.Include(x => x.Submissions);
        }

        public override async Task<List<Lookup>> GetLookupAsync()
        {
            var quizzes = await GetAllAsync();
            return quizzes.Select(x => new Lookup
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}