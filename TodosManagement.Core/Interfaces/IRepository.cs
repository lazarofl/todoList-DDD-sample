using System.Collections.Generic;
using SharedKernel.Models;

namespace TodosManagement.Core.Interfaces
{
    public interface IRepository<TEntity, in TId> where TEntity : Entity<TId>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(TId id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TId id);
    }
}
