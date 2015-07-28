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
        private const string ThirdRoomTemplate = "Third Room {0}";
        private const string FirstFurnitureType = "Табурет {0}";
        private const string SecondFurnitureType = "Кресло {0}";
        private const string ThirdFurnitureType = "Кровать {0}";

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

        [Test]
        public void Remove_NotEmptyRoomToNotEmptyRoomMoveFurnitureItems_Success()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();
            var firstRoomName = string.Format(FirstRoomTemplate, Timestamp);
            var secondRoomName = string.Format(SecondRoomTemplate, Timestamp);
            var firstFurnitureType = string.Format(FirstFurnitureType, Timestamp);
            var secondFurnitureType = string.Format(SecondFurnitureType, Timestamp);
            var date = DateForTest;

            roomWebHandler.Create(firstRoomName, date);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(firstFurnitureType, firstRoomName, date); }, 3);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(secondFurnitureType, firstRoomName, date); }, 5);
            roomWebHandler.Create(secondRoomName, date);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(firstFurnitureType, secondRoomName, date); }, 4);
            var removeResult = roomWebHandler.Remove(firstRoomName, secondRoomName, date.AddDays(1));

            Assert.AreNotEqual(null, removeResult);
            Assert.AreEqual(true, removeResult.IsSuccess);
            Assert.AreEqual(true, string.IsNullOrEmpty(removeResult.Message));

            var result = roomWebHandler.Get(date.AddDays(1)).Data;
            Assert.AreEqual(false, result.Any(r => r.RoomName == firstRoomName));
            var secondRoom = result.First(r => r.RoomName == secondRoomName);
            Assert.AreEqual(2, secondRoom.FurnitureItems.Count);
            var secondRoomFirstFurniture = secondRoom.FurnitureItems.Single(f => f.Type == firstFurnitureType);
            var secondRoomSecondFurniture = secondRoom.FurnitureItems.Single(f => f.Type == secondFurnitureType);
            Assert.AreEqual(7, secondRoomFirstFurniture.Count);
            Assert.AreEqual(5, secondRoomSecondFurniture.Count);
        }

        [Test]
        public void Remove_NotEmptyRoomToEmptyRoomMoveFurnitureItemsWithMovings_Success()
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
            TestHelper.Repeat(() => { furnitureWebHandler.Create(firstFurnitureType, firstRoomName, date); }, 5);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(secondFurnitureType, firstRoomName, date); }, 2);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(thirdFurnitureType, firstRoomName, date); }, 1);
            roomWebHandler.Create(secondRoomName, date);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(firstFurnitureType, secondRoomName, date); }, 4);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(thirdFurnitureType, secondRoomName, date); }, 25);
            roomWebHandler.Create(thirdRoomName, date);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(secondFurnitureType, thirdRoomName, date); }, 1);
            TestHelper.Repeat(() => { furnitureWebHandler.Create(thirdFurnitureType, thirdRoomName, date); }, 2);
            furnitureWebHandler.Move(thirdFurnitureType, secondRoomName, thirdRoomName, nextDate);
            furnitureWebHandler.Move(secondFurnitureType, thirdRoomName, secondRoomName, nextDate);
            var removeResult = roomWebHandler.Remove(firstRoomName, secondRoomName, nextNextDate);

            Assert.AreNotEqual(null, removeResult);
            Assert.AreEqual(true, removeResult.IsSuccess);
            Assert.AreEqual(true, string.IsNullOrEmpty(removeResult.Message));

            var result = roomWebHandler.Get(nextNextDate).Data;
            Assert.AreEqual(false, result.Any(r => r.RoomName == firstRoomName));
            var secondRoom = result.First(r => r.RoomName == secondRoomName);
            Assert.AreEqual(3, secondRoom.FurnitureItems.Count);
            var secondRoomFirstFurniture = secondRoom.FurnitureItems.Single(f => f.Type == firstFurnitureType);
            var secondRoomSecondFurniture = secondRoom.FurnitureItems.Single(f => f.Type == secondFurnitureType);
            var secondRoomThirdFurniture = secondRoom.FurnitureItems.Single(f => f.Type == thirdFurnitureType);
            Assert.AreEqual(9, secondRoomFirstFurniture.Count);
            Assert.AreEqual(1 + 2, secondRoomSecondFurniture.Count);
            Assert.AreEqual(1, secondRoomThirdFurniture.Count);
        }
    }
}