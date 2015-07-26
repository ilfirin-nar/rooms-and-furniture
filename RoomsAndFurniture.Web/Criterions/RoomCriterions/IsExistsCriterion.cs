using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.RoomCriterions
{
    public class IsExistsCriterion : ICriterion
    {
        public IsExistsCriterion(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}