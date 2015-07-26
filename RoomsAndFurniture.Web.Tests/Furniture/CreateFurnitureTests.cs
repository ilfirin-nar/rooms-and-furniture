using NUnit.Framework;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Tests.Furniture
{
    [TestFixture]
    public class CreateFurnitureTests : TestsBase
    {
        [Test]
        public void Create_ValidDataForCreate_Success()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();

            var roomName = string.Format("Test Room {0}", Timestamp);
            var furnitureType = string.Format("Test Furniture {0}", Timestamp);
            
            var date = DateForTest;
            roomWebHandler.Create(roomName, date);
            var furniture = furnitureWebHandler.Create(furnitureType, roomName, date);

            Assert.AreNotEqual(null, furniture);
            Assert.AreEqual(true, furniture.IsSuccess);
            Assert.AreEqual(null, furniture.Message);
        }

        [Test]
        public void Create_ValidDataForUpdate_Success()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();

            var roomName = string.Format("Test Room {0}", Timestamp);
            var furnitureType = string.Format("Test Furniture {0}", Timestamp);

            var date = DateForTest;
            roomWebHandler.Create(roomName, date);
            var furniture1 = furnitureWebHandler.Create(furnitureType, roomName, date).Data;
            var furniture2 = furnitureWebHandler.Create(furnitureType, roomName, date).Data;

            Assert.AreEqual(furniture1.Count + 1, furniture2.Count);
        }
    }
}