using System.Collections.Generic;

namespace RoomsAndFurniture.Web.Infrastructure.CommonInterfaces
{
    public interface IRepository { }

    public interface IRepository<TEntity> : IRepository where TEntity : IEntity
    {
        TEntity Get(dynamic id);

        IList<TEntity> Get();

        dynamic Save(TEntity entity);

        bool Remove(TEntity entity);
    }
}