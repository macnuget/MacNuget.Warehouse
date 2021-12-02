namespace MacNuget.Warehouse.ApplicationCore.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepositoryBase<TEntity, TPrimaryKey>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TPrimaryKey id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TPrimaryKey id);
        long Count();
    }
}
