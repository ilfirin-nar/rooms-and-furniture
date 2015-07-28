using System;
using System.Linq;
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

        [Test]
        public void Create_RoomNotExists_Fail()
        {
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();
            var furnitureType = string.Format("Test Furniture {0}", Timestamp);

            var date = DateForTest;            
            var furniture = furnitureWebHandler.Create(furnitureType, "Room name", date);

            Assert.AreNotEqual(null, furniture);
            Assert.AreEqual(false, furniture.IsSuccess);
            Assert.AreNotEqual(null, furniture.Message);
            Assert.AreNotEqual(string.Empty, furniture.Message);
        }

        [Test]
        public void Create_AddAnotherFurniturBeforeDate_AtDateFurnitureShouldHaveTwoInstances()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();

            var roomName = string.Format("Test Room {0}", Timestamp);
            var furnitureType = string.Format("Test Furniture {0}", Timestamp);

            var date = DateForTest;
            roomWebHandler.Create(roomName, date.AddDays(-4));
            Action<DateTime, int> check = (dateToCheck, expectedCount) =>
            {
                var resultFurniture = roomWebHandler.Get(dateToCheck).Data
                .First(r => r.RoomName == roomName).FurnitureItems
                .First(f => f.Type == furnitureType);
                Assert.AreEqual(expectedCount, resultFurniture.Count);
            };
            furnitureWebHandler.Create(furnitureType, roomName, date.AddDays(-4));
            check(date.AddDays(-4), 1);
            check(date.AddDays(-3), 1);
            check(date.AddDays(-2), 1);
            check(date.AddDays(-1), 1);
            check(date, 1);
            check(date.AddDays(1), 1);
            check(date.AddDays(2), 1);
            furnitureWebHandler.Create(furnitureType, roomName, date.AddDays(-2));
            check(date.AddDays(-4), 1);
            check(date.AddDays(-3), 1);
            check(date.AddDays(-2), 2);
            check(date.AddDays(-1), 2);
            check(date, 2);
            check(date.AddDays(1), 2);
            check(date.AddDays(2), 2);
            furnitureWebHandler.Create(furnitureType, roomName, date.AddDays(-1));
            check(date.AddDays(-4), 1);
            check(date.AddDays(-3), 1);
            check(date.AddDays(-2), 2);
            check(date.AddDays(-1), 3);
            check(date, 3);
            check(date.AddDays(1), 3);
            check(date.AddDays(2), 3);
            furnitureWebHandler.Create(furnitureType, roomName, date.AddDays(1));
            check(date.AddDays(-4), 1);
            check(date.AddDays(-3), 1);
            check(date.AddDays(-2), 2);
            check(date.AddDays(-1), 3);
            check(date, 3);
            check(date.AddDays(1), 4);
            check(date.AddDays(2), 4);
            furnitureWebHandler.Create(furnitureType, roomName, date.AddDays(2));
            check(date.AddDays(-4), 1);
            check(date.AddDays(-3), 1);
            check(date.AddDays(-2), 2);
            check(date.AddDays(-1), 3);
            check(date, 3);
            check(date.AddDays(1), 4);
            check(date.AddDays(2), 5);
            furnitureWebHandler.Create(furnitureType, roomName, date);
            check(date.AddDays(-4), 1);
            check(date.AddDays(-3), 1);
            check(date.AddDays(-2), 2);
            check(date.AddDays(-1), 3);
            check(date, 4);
            check(date.AddDays(1), 5);
            check(date.AddDays(2), 6);
        }
    }
}