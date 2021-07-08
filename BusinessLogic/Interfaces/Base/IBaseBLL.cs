using System;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Base
{
    public interface IBaseBll
    {
        Task<int> SaveChangesAsync();

        TService GetService<TService>(Func<TService> serviceCreationMethod)
            where TService : class;
    }
}