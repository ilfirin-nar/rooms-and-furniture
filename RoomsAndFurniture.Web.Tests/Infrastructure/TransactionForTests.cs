using System;
using System.Transactions;

namespace RoomsAndFurniture.Web.Tests.Infrastructure
{
    public static class TransactionForTests
    {
        public static void GoAndRollback(Action action)
        {
            using (var scope = new TransactionScope())
            {
                action();
                scope.Dispose();
            }
        }
    }
}