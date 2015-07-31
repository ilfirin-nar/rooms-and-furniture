using DapperExtensions.Mapper;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    public abstract class EntityAutoMapper<TPrimaryKey, TEntity> : ClassMapper<TEntity>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected EntityAutoMapper()
        {
            Map(x => x.Id).Column("Id").Key(KeyType.Identity);
            AutoMap();
        }

        protected EntityAutoMapper(string identityColumnName)
        {
            Map(x => x.Id).Column(identityColumnName).Key(KeyType.Identity);
            AutoMap();
        }
    }
}