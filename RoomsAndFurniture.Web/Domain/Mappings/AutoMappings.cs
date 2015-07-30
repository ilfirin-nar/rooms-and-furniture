using RoomsAndFurniture.Web.Infrastructure.Database;

namespace RoomsAndFurniture.Web.Domain.Mappings
{
    public sealed class RoomMapping : EntityAutoMapper<int, Room> {}
    public sealed class FurnitureMapping : EntityAutoMapper<int, Furniture> {}
    public sealed class FurnitureLocationMapping : EntityAutoMapper<int, FurnitureLocation> { }
}