using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kessewa.Quiz.Processors.Repositories.Administration
{
    public interface IInitializeDbRepository
    {
        Task InitializeDb();
    }
}
