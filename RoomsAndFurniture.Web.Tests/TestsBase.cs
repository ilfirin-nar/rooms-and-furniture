using System;
using System.IO;
using LightInject;
using NUnit.Framework;
using RoomsAndFurniture.Web.Infrastructure.Database;
using RoomsAndFurniture.Web.Tests.Infrastructure;

namespace RoomsAndFurniture.Web.Tests
{
    public abstract class TestsBase
    {
        protected readonly ServiceContainer Container;
        private DateTime dateForTest = new DateTime(2014, 12, 31);

        protected DateTime DateForTest
        {
            get { return dateForTest = dateForTest.AddDays(1); }
        }

        protected long Timestamp
        {
            get { return (int) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds; }
        }

        protected TestsBase()
        {
            Container = TestsServiceInstaller.Install();
            Container.GetInstance<IDatabaseInitializer>().Initialize();
        }

        [TestFixtureTearDown]
        public void Cleanup()
        {
            File.Delete(DatabaseInfoKeeper.Main.FilePath);
        }
    }
}