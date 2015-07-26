using LightInject;
using RoomsAndFurniture.Web.Tests.Infrastructure;

namespace RoomsAndFurniture.Web.Tests
{
    public abstract class TestsBase
    {
        protected readonly ServiceContainer Container;

        protected TestsBase()
        {
            Container = TestsServiceInstaller.Install();
            Container.GetInstance<IDatabaseInitializer>().Initialize();
        }
    }
}