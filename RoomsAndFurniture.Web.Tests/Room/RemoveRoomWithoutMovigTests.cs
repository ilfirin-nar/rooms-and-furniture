using System.Linq;
using NUnit.Framework;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Tests.Room
{
    [TestFixture]
    public class RemoveRoomWithoutMovig : TestsBase
    {
        private const string TestRoomTemplate = "Test Room {0}";
        private const string FurnitureType = "Шкаф {0}";

        [Test]
        public void RemoveWithoutMovig_EmptyRoom_Success()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var roomName = string.Format(TestRoomTemplate, Timestamp);
            var date = DateForTest;

            roomWebHandler.Create(roomName, date);
            var removeResult = roomWebHandler.RemoveWithoutMovig(roomName, date.AddDays(1));

            Assert.AreNotEqual(null, removeResult);
            Assert.AreEqual(true, removeResult.IsSuccess);
            Assert.AreEqual(true, string.IsNullOrEmpty(removeResult.Message));

            var result = roomWebHandler.Get(date.AddDays(1)).Data.FirstOrDefault(r => r.RoomName == roomName);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void RemoveWithoutMovig_NotEmptyRoom_Success()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();
            var roomName = string.Format(TestRoomTemplate, Timestamp);
            var furnitureType = string.Format(FurnitureType, Timestamp);
            var date = DateForTest;

            roomWebHandler.Create(roomName, date);
            furnitureWebHandler.Create(furnitureType, roomName, date);
            var removeResult = roomWebHandler.RemoveWithoutMovig(roomName, date.AddDays(1));

            Assert.AreNotEqual(null, removeResult);
            Assert.AreEqual(false, removeResult.IsSuccess);
            Assert.AreEqual(false, string.IsNullOrEmpty(removeResult.Message));

            var result = roomWebHandler.Get(date.AddDays(1)).Data.FirstOrDefault(r => r.RoomName == roomName);
            Assert.AreNotEqual(null, result);
        }
    }
}