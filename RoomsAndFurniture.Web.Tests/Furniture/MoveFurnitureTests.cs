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
        private const string FurnitureType = "Стол";

        [Test]
        public void Move_ValidParameters_Success()
        {
            var roomWebHandler = Container.GetInstance<IRoomWebHandler>();
            var furnitureWebHandler = Container.GetInstance<IFurnitureWebHandler>();

            var date = DateForTest;
            var nextDayAfterDate = date.AddDays(1);
            var firstRoomName = string.Format(FirstRoomNameTemplate, Timestamp);
            var secondRoomName = string.Format(SecondRoomNameTemplate, Timestamp);

            roomWebHandler.Create(firstRoomName, date);
            furnitureWebHandler.Create(FurnitureType, firstRoomName, date);
            roomWebHandler.Create(secondRoomName, date);
            furnitureWebHandler.Move(FurnitureType, firstRoomName, secondRoomName, nextDayAfterDate);
            var result = roomWebHandler.Get(nextDayAfterDate).Data;

            var firstRoomResult = result.First(r => r.RoomName == firstRoomName);
            Assert.AreNotEqual(null, firstRoomResult.FurnitureItems);
            var furnitureFromFirst = firstRoomResult.FurnitureItems.First(f => f.Type == FurnitureType);
            Assert.AreNotEqual(null, furnitureFromFirst);
            Assert.AreEqual(0, furnitureFromFirst.Count);

            var secondRoomResult = result.First(r => r.RoomName == secondRoomName);
            Assert.AreNotEqual(null, secondRoomResult.FurnitureItems);
            var furnitureFromSecond = secondRoomResult.FurnitureItems.First(f => f.Type == FurnitureType);
            Assert.AreNotEqual(null, furnitureFromSecond);
            Assert.AreEqual(1, furnitureFromSecond.Count);
        }
    }
}