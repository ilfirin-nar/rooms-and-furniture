using NUnit.Framework;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Tests.Room
{
    [TestFixture]
    public class CreateRoomTests : TestsBase
    {
        [Test]
        public void Create_ValidParameters_Success()
        {
            const string roomName = "Test Room UNIQUE";
            var handler = Container.GetInstance<IRoomWebHandler>();
            var date = DateForTest;
            var result = handler.Create(roomName, date);
            Assert.AreNotEqual(null, result);
            var resultData = result.Data;
            Assert.AreNotEqual(null, resultData);
            Assert.AreEqual(roomName, resultData.RoomName);
            Assert.AreNotEqual(0, resultData.RoomId);
        }

        [Test]
        public void Create_AlreadyExistingRoom_Fail()
        {
            var roomName = string.Format("Test Room {0}", Timestamp);
            var handler = Container.GetInstance<IRoomWebHandler>();
            var date = DateForTest;
            handler.Create(roomName, date);
            var result = handler.Create(roomName, date);
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(false, result.IsSuccess);
            Assert.AreNotEqual(null, result.Message);
            Assert.AreNotEqual(string.Empty, result.Message);
            Assert.AreEqual(null, result.Data);
        }
    }
}