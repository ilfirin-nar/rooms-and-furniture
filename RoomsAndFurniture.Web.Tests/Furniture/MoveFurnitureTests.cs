using System.Linq;
using NUnit.Framework;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Tests.Furniture
{
    [TestFixture]
    public class MoveFurnitureTests : TestsBase
    {
        private const string FirstRoomNameTemplate = "First Room {0}";
        private const string SecondRoomNameTemplate = "Second Room {0}";
        private const string FirstFurnitureType = "Стол {0}";
        private const string SecondFurnitureType = "Стул {0}";

        [Test]
        public void Move_OneFurnitureTypeAndEmptySecondRoom_Success()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();

            var date = DateForTest;
            var nextDayAfterDate = date.AddDays(1);
            var nextNextDayAfterDate = nextDayAfterDate.AddDays(1);
            var firstRoomName = string.Format(FirstRoomNameTemplate, Timestamp);
            var secondRoomName = string.Format(SecondRoomNameTemplate, Timestamp);
            var firstFurnitureType = string.Format(FirstFurnitureType, Timestamp);

            roomWebHandler.Create(firstRoomName, date);
            furnitureWebHandler.Create(firstFurnitureType, firstRoomName, date);
            roomWebHandler.Create(secondRoomName, date);
            furnitureWebHandler.Move(firstFurnitureType, firstRoomName, secondRoomName, nextDayAfterDate);
            var result = roomWebHandler.Get(nextNextDayAfterDate).Data;

            var firstRoomResult = result.First(r => r.RoomName == firstRoomName);
            Assert.AreNotEqual(null, firstRoomResult.FurnitureItems);
            Assert.AreEqual(1, firstRoomResult.FurnitureItems.Count);
            var furnitureFromFirstRoom = firstRoomResult.FurnitureItems.First(f => f.Type == firstFurnitureType);
            Assert.AreNotEqual(null, furnitureFromFirstRoom);
            Assert.AreEqual(0, furnitureFromFirstRoom.Count);

            var secondRoomResult = result.First(r => r.RoomName == secondRoomName);
            Assert.AreNotEqual(null, secondRoomResult.FurnitureItems);
            Assert.AreEqual(1, secondRoomResult.FurnitureItems.Count);
            var furnitureFromSecondRoom = secondRoomResult.FurnitureItems.First(f => f.Type == firstFurnitureType);
            Assert.AreNotEqual(null, furnitureFromSecondRoom);
            Assert.AreEqual(1, furnitureFromSecondRoom.Count);
        }

        [Test]
        public void Move_TwoFurnitureTypesAndEmptySecondRoom_Success()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();

            var date = DateForTest;
            var nextDayAfterDate = date.AddDays(1);
            var firstRoomName = string.Format(FirstRoomNameTemplate, Timestamp);
            var secondRoomName = string.Format(SecondRoomNameTemplate, Timestamp);
            var firstFurnitureType = string.Format(FirstFurnitureType, Timestamp);
            var secondFurnitureType = string.Format(SecondFurnitureType, Timestamp);

            roomWebHandler.Create(firstRoomName, date);
            furnitureWebHandler.Create(firstFurnitureType, firstRoomName, date);
            furnitureWebHandler.Create(secondFurnitureType, firstRoomName, date);
            roomWebHandler.Create(secondRoomName, date);
            furnitureWebHandler.Move(firstFurnitureType, firstRoomName, secondRoomName, nextDayAfterDate);
            furnitureWebHandler.Move(secondFurnitureType, firstRoomName, secondRoomName, nextDayAfterDate);
            var result = roomWebHandler.Get(nextDayAfterDate).Data;

            var firstRoomResult = result.First(r => r.RoomName == firstRoomName);
            Assert.AreNotEqual(null, firstRoomResult.FurnitureItems);
            Assert.AreEqual(2, firstRoomResult.FurnitureItems.Count);
            var firstFurnitureFromFirst = firstRoomResult.FurnitureItems.First(f => f.Type == firstFurnitureType);
            Assert.AreNotEqual(null, firstFurnitureFromFirst);
            Assert.AreEqual(0, firstFurnitureFromFirst.Count);
            var secondFurnitureFromFirstRoom = firstRoomResult.FurnitureItems.First(f => f.Type == secondFurnitureType);
            Assert.AreNotEqual(null, secondFurnitureFromFirstRoom);
            Assert.AreEqual(0, secondFurnitureFromFirstRoom.Count);

            var secondRoomResult = result.First(r => r.RoomName == secondRoomName);
            Assert.AreNotEqual(null, secondRoomResult.FurnitureItems);
            Assert.AreEqual(2, secondRoomResult.FurnitureItems.Count);
            var firstFurnitureFromSecondRoom = secondRoomResult.FurnitureItems.First(f => f.Type == firstFurnitureType);
            Assert.AreNotEqual(null, firstFurnitureFromSecondRoom);
            Assert.AreEqual(1, firstFurnitureFromSecondRoom.Count);
            var secondFurnitureFromSecondRoom = secondRoomResult.FurnitureItems.First(f => f.Type == secondFurnitureType);
            Assert.AreNotEqual(null, secondFurnitureFromSecondRoom);
            Assert.AreEqual(1, secondFurnitureFromSecondRoom.Count);
        }

        [Test]
        public void Move_OneFurnitureTypeAndNotEmptySecondRoom_Success()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();

            var date = DateForTest;
            var nextDayAfterDate = date.AddDays(1);
            var firstRoomName = string.Format(FirstRoomNameTemplate, Timestamp);
            var secondRoomName = string.Format(SecondRoomNameTemplate, Timestamp);
            var firstFurnitureType = string.Format(FirstFurnitureType, Timestamp);

            roomWebHandler.Create(firstRoomName, date);
            furnitureWebHandler.Create(firstFurnitureType, firstRoomName, date);
            roomWebHandler.Create(secondRoomName, date);
            furnitureWebHandler.Create(firstFurnitureType, secondRoomName, date);
            furnitureWebHandler.Move(firstFurnitureType, firstRoomName, secondRoomName, nextDayAfterDate);
            var result = roomWebHandler.Get(nextDayAfterDate).Data;

            var firstRoomResult = result.First(r => r.RoomName == firstRoomName);
            Assert.AreNotEqual(null, firstRoomResult.FurnitureItems);
            Assert.AreEqual(1, firstRoomResult.FurnitureItems.Count);
            var furnitureFromFirstRoom = firstRoomResult.FurnitureItems.First(f => f.Type == firstFurnitureType);
            Assert.AreNotEqual(null, furnitureFromFirstRoom);
            Assert.AreEqual(0, furnitureFromFirstRoom.Count);

            var secondRoomResult = result.First(r => r.RoomName == secondRoomName);
            Assert.AreNotEqual(null, secondRoomResult.FurnitureItems);
            Assert.AreEqual(1, secondRoomResult.FurnitureItems.Count);
            var furnitureFromSecondRoom = secondRoomResult.FurnitureItems.First(f => f.Type == firstFurnitureType);
            Assert.AreNotEqual(null, furnitureFromSecondRoom);
            Assert.AreEqual(2, furnitureFromSecondRoom.Count);
        }
        
        [Test]
        public void Move_FirstRoomNotExists_Fail()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();

            var date = DateForTest;
            var nextDayAfterDate = date.AddDays(1);
            var firstRoomName = string.Format(FirstRoomNameTemplate, Timestamp);
            var secondRoomName = string.Format(SecondRoomNameTemplate, Timestamp);
            var firstFurnitureType = string.Format(FirstFurnitureType, Timestamp);

            roomWebHandler.Create(firstRoomName, date);
            furnitureWebHandler.Create(firstFurnitureType, secondRoomName, date);
            var result = furnitureWebHandler.Move(firstFurnitureType, firstRoomName, secondRoomName, nextDayAfterDate);
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(false, result.IsSuccess);
            Assert.AreEqual(false, string.IsNullOrEmpty(result.Message));
        }

        [Test]
        public void Move_SecondRoomNotExists_Fail()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();

            var date = DateForTest;
            var nextDayAfterDate = date.AddDays(1);
            var firstRoomName = string.Format(FirstRoomNameTemplate, Timestamp);
            var secondRoomName = string.Format(SecondRoomNameTemplate, Timestamp);
            var firstFurnitureType = string.Format(FirstFurnitureType, Timestamp);            

            roomWebHandler.Create(firstRoomName, date);
            furnitureWebHandler.Create(firstFurnitureType, firstRoomName, date);
            roomWebHandler.Create(secondRoomName, date.AddDays(5));
            var result = furnitureWebHandler.Move(firstFurnitureType, firstRoomName, secondRoomName, nextDayAfterDate);
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(false, result.IsSuccess);
            Assert.AreEqual(false, string.IsNullOrEmpty(result.Message));
        }

        [Test]
        public void Move_FurnitureNotFound_Fail()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();

            var date = DateForTest;
            var nextDayAfterDate = date.AddDays(1);
            var firstRoomName = string.Format(FirstRoomNameTemplate, Timestamp);
            var secondRoomName = string.Format(SecondRoomNameTemplate, Timestamp);
            var firstFurnitureType = string.Format(FirstFurnitureType, Timestamp);

            roomWebHandler.Create(firstRoomName, date);
            var result = furnitureWebHandler.Move(firstFurnitureType, firstRoomName, secondRoomName, nextDayAfterDate);
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(false, result.IsSuccess);
            Assert.AreEqual(false, string.IsNullOrEmpty(result.Message));
        }
    }
}