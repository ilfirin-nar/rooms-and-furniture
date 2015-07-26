using System;
using System.Globalization;
using NUnit.Framework;
using RoomsAndFurniture.Web.Tests.Infrastructure;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Tests.Room
{
    [TestFixture]
    public class CreateTests : TestsBase
    {
        [Test]
        public void Create_ValidParameters_Success()
        {
            var roomName = string.Format("Test Room {0}", DateTime.Now);
            var handler = Container.GetInstance<IRoomWebHandler>();
            var result = handler.Create(roomName, DateTime.Now);
            Assert.AreNotEqual(result, null);
            var resultData = result.Data;
            Assert.AreEqual(resultData.Name, roomName);
            Assert.AreNotEqual(resultData.Id, 0);
        }

        [Test]
        public void Create_AlreadyExistingRoom_AlreadyExists()
        {
            var roomName = string.Format("Test Room {0}", DateTime.Now);
            var handler = Container.GetInstance<IRoomWebHandler>();
            handler.Create(roomName, DateTime.Now);
            var result = handler.Create(roomName, DateTime.Now);
            Assert.AreNotEqual(result, null);
            Assert.AreEqual(result.Data, null);
            Assert.AreEqual(result.IsSuccess, false);
            Assert.AreNotEqual(result.Message, null);
            Assert.AreNotEqual(result.Message, string.Empty);
        }
    }
}