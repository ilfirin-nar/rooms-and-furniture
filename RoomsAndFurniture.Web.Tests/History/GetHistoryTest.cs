using System.Linq;
using NUnit.Framework;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Tests.History
{
    [TestFixture]
    public class GetHistoryTest : TestsBase
    {
        [Test]
        public void Get_FullEmptyData_Success()
        {
            var handler = Container.GetInstance<IHistoryWebHandler>();
            var result = handler.Get();
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreNotEqual(null, result.Data);
            Assert.GreaterOrEqual(result.Data.Count, 0);
        }

        [Test]
        public void Get_ShortEmptyData_Success()
        {
            var handler = Container.GetInstance<IHistoryWebHandler>();
            var result = handler.Get(true);
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreNotEqual(null, result.Data);
            Assert.GreaterOrEqual(result.Data.Count, 0);
        }

        [Test]
        public void Get_FullData_Success()
        {
            var roomHandler = Container.GetInstance<IRoomWebHandler>();
            var historyHandler = Container.GetInstance<IHistoryWebHandler>();

            roomHandler.Create(string.Format("Test Room {0}", Timestamp), DateForTest);
            var result = historyHandler.Get();
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreNotEqual(null, result.Data);
            Assert.GreaterOrEqual(result.Data.Count, 1);
            Assert.GreaterOrEqual(result.Data.Count(m => string.IsNullOrEmpty(m.Description)), 0);
        }

        [Test]
        public void Get_ShortData_Success()
        {
            var roomHandler = Container.GetInstance<IRoomWebHandler>();
            var historyHandler = Container.GetInstance<IHistoryWebHandler>();

            roomHandler.Create(string.Format("Test Room {0}", Timestamp), DateForTest);
            var result = historyHandler.Get(false);
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreNotEqual(null, result.Data);
            Assert.GreaterOrEqual(result.Data.Count, 1);
            Assert.GreaterOrEqual(result.Data.Count(m => !string.IsNullOrEmpty(m.Description)), 0);
        }
    }
}