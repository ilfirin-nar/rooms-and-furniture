using System;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    internal class FurnitureAmountIncreaser : IFurnitureAmountIncreaser
    {
        private readonly IFurnitureReader reader;
        private readonly IFurnitureCreator creator;
        private readonly IFurnitureUpdater updater;

        public FurnitureAmountIncreaser(
            IFurnitureReader reader,
            IFurnitureCreator creator,
            IFurnitureUpdater updater)
        {
            this.reader = reader;
            this.creator = creator;
            this.updater = updater;
        }

        public int Increase(string type, DateTime date, string roomName, int increaseBy)
        {
            var furniture = reader.Get(type, date, roomName);
            if (furniture == null)
            {
                return creator.Create(type, date, roomName, increaseBy);
            }
            furniture.Count = furniture.Count + increaseBy;
            return updater.Update(furniture);
        }
    }
}