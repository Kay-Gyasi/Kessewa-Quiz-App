using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Repositories.Administration;

namespace Kessewa.Quiz.Processors.Processors.Administration
{
    [Processor]
    public class InitializeDbProcessor
    {
        private readonly IInitializeDbRepository _repository;

        public InitializeDbProcessor(IInitializeDbRepository repository)
        {
            _repository = repository;
        }

        public async Task InitializeDatabase()
        {
            await _repository.InitializeDb();
        }
    }
}