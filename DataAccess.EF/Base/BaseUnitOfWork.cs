using System.Threading.Tasks;
using DataAccess.Base;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EF.Base
{
    public class BaseUnitOfWork<TDbContext> : BaseUnitOfWork
        where TDbContext : DbContext
    {
        protected readonly TDbContext UowDbContext;

        public BaseUnitOfWork(TDbContext uowDbContext)
        {
            UowDbContext = uowDbContext;
        }
        
        public override Task<int> SaveChangesAsync()
        {
            return UowDbContext.SaveChangesAsync();
        }
    }
}