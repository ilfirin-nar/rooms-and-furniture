using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DapperExtensions;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Infrastructure.Database.Exceptions;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    public class Repositiry<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly static PropertyInfo PrimaryKeyProperty;
        private readonly IQueryExecuter queryExecuter;

        static Repositiry()
        {
            PrimaryKeyProperty = typeof (TEntity).GetProperty("Id");
        }

        public Repositiry(IQueryExecuter queryExecuter)
        {
            this.queryExecuter = queryExecuter;
        }

        public TEntity Get(dynamic id)
        {
            return queryExecuter.Execute(connection => connection.Get<TEntity>((object)id));
        }

        public IList<TEntity> Get()
        {
            return queryExecuter.Execute(connection => connection.GetList<TEntity>().ToList());
        }

        /// <summary>Возвращает идентификатор сущности</summary>
        public dynamic Save(TEntity entity)
        {
            return IsNewEntity(entity)
                ? queryExecuter.Execute(connection =>
                {
                    var id = connection.Insert(entity);
                    PrimaryKeyProperty.SetValue(entity, id);
                    return id;
                })
                : queryExecuter.Execute(connection =>
                {
                    var id = GetEntityId(entity);
                    if (connection.Update(entity))
                    {
                        return id;
                    }
                    throw new SaveEntityFailedException<TEntity>(id);
                });
        }

        public void Save(IEnumerable<TEntity> entities)
        {
            var forInsert = entities.Where(IsNewEntity).ToList();
            var forUpdate = entities.Where(e => !forInsert.Contains(e));
            queryExecuter.Execute(connection =>
            {
                connection.Insert<TEntity>(forInsert);
            });
            queryExecuter.Execute(connection =>
            {
                // TODO: Fix select N + 1 :(
                foreach (var entity in forUpdate)
                {
                    connection.Update(entity);
                }
            });
        }

        public bool Remove(TEntity entity)
        {
            return queryExecuter.Execute(connection => connection.Delete(entity));
        }

        private static bool IsNewEntity(TEntity entity)
        {
            var value = PrimaryKeyProperty.GetValue(entity);
            if (value is long || value is int || value is short || value is byte)
            {
                return Convert.ToInt64(value) == 0;
            }
            return false;
        }

        private static long GetEntityId(TEntity entity)
        {
            return Convert.ToInt64(PrimaryKeyProperty.GetValue(entity));
        }
    }
}