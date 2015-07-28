using System.Linq;
using NUnit.Framework;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Tests.Room
{
    [TestFixture]
    public class RemoveRoomTests : TestsBase
    {
        private const string FirstRoomTemplate = "First Room {0}";
        private const string SecondRoomTemplate = "Second Room {0}";

        [Test]
        public void Remove_EmptyRoom_Success()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var firstRoomName = string.Format(FirstRoomTemplate, Timestamp);
            var secondRoomName = string.Format(SecondRoomTemplate, Timestamp);
            var date = DateForTest;

            roomWebHandler.Create(firstRoomName, date);
            roomWebHandler.Create(secondRoomName, date);
            var removeResult = roomWebHandler.Remove(firstRoomName, secondRoomName, date.AddDays(1));

            Assert.AreNotEqual(null, removeResult);
            Assert.AreEqual(true, removeResult.IsSuccess);
            Assert.AreEqual(true, string.IsNullOrEmpty(removeResult.Message));

            var result = roomWebHandler.Get(date.AddDays(1)).Data.FirstOrDefault(r => r.RoomName == firstRoomName);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void Remove_NotExistingRoom_Fail()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var firstRoomName = string.Format(FirstRoomTemplate, Timestamp);

            var result = roomWebHandler.Remove(firstRoomName, "Room For move", DateForTest);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(false, result.IsSuccess);
            Assert.AreEqual(false, string.IsNullOrEmpty(result.Message));
        }

        [Test]
        public void Remove_NotExistingRoomAtDate_Fail()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var firstRoomName = string.Format(FirstRoomTemplate, Timestamp);
            var date = DateForTest;

            roomWebHandler.Create(firstRoomName, date);
            var result = roomWebHandler.Remove(firstRoomName, "Room For move", date.AddDays(-1));

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(false, result.IsSuccess);
            Assert.AreEqual(false, string.IsNullOrEmpty(result.Message));
        }
    }
}