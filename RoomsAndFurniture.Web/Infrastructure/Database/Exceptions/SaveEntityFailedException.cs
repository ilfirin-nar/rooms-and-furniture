using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Infrastructure.Database.Exceptions
{
    public class SaveEntityFailedException<TEntity> : Exception where TEntity : IEntity
    {
        private static readonly string EntityTypeName;
        private readonly long id;

        static SaveEntityFailedException()
        {
            EntityTypeName = typeof (TEntity).Name;
        }

        public SaveEntityFailedException(long id)
        {
            this.id = id;
        }

        public override string Message
        {
            get { return string.Format("Saving entity {0} with ID = {1} failed", EntityTypeName, id); }
        }
    }
}