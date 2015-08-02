using System;
using System.Data;

namespace RoomsAndFurniture.Web.Infrastructure.CommonInterfaces
{
    public interface ISession : IDisposable
    {
        IDbConnection Connection { get; }
        bool InTransaction { get; set; }
    }
}