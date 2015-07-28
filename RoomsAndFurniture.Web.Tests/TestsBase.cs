using System;
using System.IO;
using LightInject;
using NUnit.Framework;
using RoomsAndFurniture.Web.Infrastructure.Database;

namespace RoomsAndFurniture.Web.Tests
{
    public abstract class TestsBase
    {
        private readonly object locker = new object();
        protected readonly ServiceContainer Container;
        private DateTime dateForTest = new DateTime(2014, 12, 31);

        protected static DateTime DateForTest
        {
            get { return RandomDay(); }
        }

        private static DateTime RandomDay()
        {
            var start = new DateTime(1905, 1, 1);
            var gen = new Random();
            var range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        protected static long Timestamp
        {
            get { return (long)(DateTime.UtcNow.Subtract(DateTime.Today)).TotalMilliseconds; }
        }

        protected TestsBase()
        {
            Container = TestsServiceInstaller.Install();
            DeleteDatabase();
            Container.GetInstance<IDatabaseInitializer>().Initialize();
        }

        [TestFixtureTearDown]
        public void Cleanup()
        {
            DeleteDatabase();
        }

        private static void DeleteDatabase()
        {
            File.Delete(DatabaseInfoKeeper.Main.FilePath);
        }
    }
}