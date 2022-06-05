using System.Linq;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Persistence.DatabaseContext;
using Kessewa.Quiz.Persistence.Repositories.Base;
using Kessewa.Quiz.Processors.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kessewa.Quiz.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public UserRepository(KessewaDbContext context, ILogger<Users> logger) : base(context, logger)
        {
        }

        public override IQueryable<Users> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(x => x.Lecturers)
                .Include(x => x.Students);
        }
    }
}