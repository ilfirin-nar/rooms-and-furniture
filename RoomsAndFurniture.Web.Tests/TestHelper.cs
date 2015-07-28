using System;

namespace RoomsAndFurniture.Web.Tests
{
    public static class TestHelper
    {
        public static void Repeat(Action action, int count)
        {
            var index = 0;
            while (index < count)
            {
                action();
                index++;
            }
        } 
    }
}