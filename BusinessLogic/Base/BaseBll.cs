using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Interfaces.Base;
using DataAccess.Interfaces.Base;

namespace BusinessLogic.Base
{
    public class BaseBll<TUnitOfWork> : IBaseBll
        where TUnitOfWork : IBaseUnitOfWork
    {
        protected readonly TUnitOfWork Uow;
        private readonly Dictionary<Type, object> _serviceCache = new();

        public BaseBll(TUnitOfWork uow)
        {
            Uow = uow;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Uow.SaveChangesAsync();
        }

        public TService GetService<TService>(Func<TService> serviceCreationMethod) where TService : class
        {
            if (_serviceCache.TryGetValue(typeof(TService), out var repo))
                return (TService) repo;

            var repoInstance = serviceCreationMethod();
            _serviceCache.Add(typeof(TService), repoInstance);
            return repoInstance;
        }
    }
}