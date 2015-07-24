using System;
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
            TransactionForTests.GoAndRollback(() =>
            {
                const string roomName = "Test Room";
                var handler = Container.GetInstance<IRoomWebHandler>();
                var result = handler.Create(roomName, DateTime.Now);
                Assert.AreNotEqual(result, null);
                Assert.AreEqual(result.Name, roomName);
                Assert.AreNotEqual(result.Id, 0);
            });
        }
    }
}