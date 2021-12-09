namespace MacNuget.Warehouse.ApplicationCore.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepositoryBase<TEntity, TPrimaryKey>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(TPrimaryKey id);
        Task<TPrimaryKey> Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TPrimaryKey id);
    }
}
