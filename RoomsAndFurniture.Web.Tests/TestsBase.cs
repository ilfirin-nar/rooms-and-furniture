﻿using System;
using System.IO;
using LightInject;
using NUnit.Framework;
using RoomsAndFurniture.Web.Infrastructure.Database;
using RoomsAndFurniture.Web.Tests.Infrastructure;

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
            var start = new DateTime(1995, 1, 1);
            var gen = new Random();
            var range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        protected long Timestamp
        {
            get
            {
                lock (locker)
                {
                    return (int) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                }
            }
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