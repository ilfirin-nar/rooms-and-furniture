using System;
using System.Transactions;

namespace RoomsAndFurniture.Web.Tests
{
    public static class TransactionForTests
    {
        public static void GoAndRollback(Action action)
        {
            var transaction = new CommittableTransaction(new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            });
            using (var scope = new TransactionScope(transaction))
            {
                action();
                scope.Dispose();
            }
        }
    }
}