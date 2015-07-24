using System.Web.Configuration;

namespace RoomsAndFurniture.Web.Infrastructure
{
    public static class ConnectionStringKeeper
    {
        private static string connectionString;

        public static string RoomsAndFurniture
        {
            get {
                return connectionString ??
                       (connectionString =
                           @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\sources\rooms-and-furniture\RoomsAndFurniture.Web\App_Data\RoomsAndFurniture.mdf;Integrated Security=True");
            }
        }
    }
}