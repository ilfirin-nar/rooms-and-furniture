using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly static PropertyInfo primaryKeyProperty;
        private readonly ISqliteConnectionFactory connectionFactory;

        static Repositiry()
        {
            primaryKeyProperty = typeof (TEntity).GetProperty("Id");
        }

        public Repositiry(ISqliteConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public TEntity Get(dynamic id)
        {

            return Execute(connection => connection.Get<TEntity>((object)id));
        }

        public IList<TEntity> Get()
        {
            return Execute(connection => connection.GetList<TEntity>().ToList());
        }

        /// <summary>Возвращает идентификатор сущности</summary>
        public dynamic Save(TEntity entity)
        {
            return IsNewEntity(entity)
                ? Execute(connection => connection.Insert(entity))
                : Execute(connection =>
                {
                    var id = GetEntityId(entity);
                    if (connection.Update(entity))
                    {
                        return id;
                    }
                    throw new SaveEntityFailedException<TEntity>(id);
                });
        }

        public bool Remove(TEntity entity)
        {
            return Execute(connection => connection.Delete(entity));
        }

        private TResult Execute<TResult>(Func<IDbConnection, TResult> action)
        {
            using (var connection = connectionFactory.Create())
            {
                return action(connection);
            }
        }

        private static bool IsNewEntity(TEntity entity)
        {
            var value = primaryKeyProperty.GetValue(entity);
            if (value is long || value is int || value is short || value is byte)
            {
                return (long) value == 0;
            }
            return false;
        }

        private static long GetEntityId(TEntity entity)
        {
            return (long) primaryKeyProperty.GetValue(entity);
        }
    }
}