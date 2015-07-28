using System.Linq;
using NUnit.Framework;
using RoomsAndFurniture.Web.Models;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Tests.Room
{
    [TestFixture]
    public class GetRoomsTests : TestsBase
    {
        private const string FirstRoomTemplate = "First Room {0}";
        private const string SecondRoomTemplate = "Second Room {0}";
        private const string ThirdRoomTemplate = "Third Room {0}";
        private const string FirstFurnitureType = "Стеллаж {0}";
        private const string SecondFurnitureType = "Комод {0}";
        private const string ThirdFurnitureType = "Диван {0}";

        [Test]
        public void Get_NotEmptyListConcreeteDate_Succes()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();
            var firstRoomName = string.Format(FirstRoomTemplate, Timestamp);
            var secondRoomName = string.Format(SecondRoomTemplate, Timestamp);
            var thirdRoomName = string.Format(ThirdRoomTemplate, Timestamp);
            var firstFurnitureType = string.Format(FirstFurnitureType, Timestamp);
            var secondFurnitureType = string.Format(SecondFurnitureType, Timestamp);
            var thirdFurnitureType = string.Format(ThirdFurnitureType, Timestamp);
            var date = DateForTest;
            var nextDate = date.AddDays(1);
            var nextNextDate = nextDate.AddDays(1);

            roomWebHandler.Create(firstRoomName, date);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(firstFurnitureType, firstRoomName, nextDate); }, 1);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(firstFurnitureType, firstRoomName, nextNextDate); }, 3);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(secondFurnitureType, firstRoomName, date); }, 2);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(thirdFurnitureType, firstRoomName, date); }, 1);
            roomWebHandler.Create(secondRoomName, date);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(firstFurnitureType, secondRoomName, date); }, 2);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(secondFurnitureType, secondRoomName, nextDate); }, 1);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(thirdFurnitureType, secondRoomName, date); }, 3);
            roomWebHandler.Create(thirdRoomName, nextDate);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(firstFurnitureType, thirdRoomName, nextDate); }, 1);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(thirdFurnitureType, thirdRoomName, nextNextDate); }, 2);
            var result = roomWebHandler.Get(nextNextDate);


            Assert.AreNotEqual(null, result);
            var data = result.Data;
            Assert.AreNotEqual(null, data);
            Assert.AreEqual(3, data.Count);
            var firstRoom = data.Single(r => r.RoomName == firstRoomName);
            var secondRoom = data.Single(r => r.RoomName == secondRoomName);
            var thirdRoom = data.Single(r => r.RoomName == thirdRoomName);
            Assert.AreEqual(3, firstRoom.FurnitureItems.Count);
            Assert.AreEqual(3, secondRoom.FurnitureItems.Count);
            Assert.AreEqual(2, thirdRoom.FurnitureItems.Count);
            Assert.AreEqual(4, firstRoom.FurnitureItems.First(f => f.Type == firstFurnitureType).Count);
            Assert.AreEqual(2, firstRoom.FurnitureItems.First(f => f.Type == secondFurnitureType).Count);
            Assert.AreEqual(1, firstRoom.FurnitureItems.First(f => f.Type == thirdFurnitureType).Count);
            Assert.AreEqual(2, secondRoom.FurnitureItems.First(f => f.Type == firstFurnitureType).Count);
            Assert.AreEqual(1, secondRoom.FurnitureItems.First(f => f.Type == secondFurnitureType).Count);
            Assert.AreEqual(3, secondRoom.FurnitureItems.First(f => f.Type == thirdFurnitureType).Count);
            Assert.AreEqual(1, thirdRoom.FurnitureItems.First(f => f.Type == firstFurnitureType).Count);
            Assert.AreEqual(2, thirdRoom.FurnitureItems.First(f => f.Type == thirdFurnitureType).Count);
        }

        [Test]
        public void Get_RemovedRoom_Succes()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var firstRoomName = string.Format(FirstRoomTemplate, Timestamp);
            var secondRoomName = string.Format(SecondRoomTemplate, Timestamp);
            var date = DateForTest;
            var nextDate = date.AddDays(1);
            var nextNextDate = nextDate.AddDays(1);

            roomWebHandler.Create(firstRoomName, date);
            roomWebHandler.Create(secondRoomName, nextDate);
            roomWebHandler.Remove(firstRoomName, secondRoomName, nextDate);
            var result = roomWebHandler.Get(nextNextDate).Data;

            Assert.AreEqual(0, result.Count(r => r.RoomName == firstRoomName));
            Assert.AreEqual(1, result.Count(r => r.RoomName == secondRoomName));
        }
    }
}