using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Persistence;
using Kessewa.Quiz.Processors.Repositories.Base;

namespace Kessewa.Quiz.Processors.Repositories
{
    [Repository]
    public interface IQuestionRepository : IRepositoryBase<Questions>
    {

    }
}