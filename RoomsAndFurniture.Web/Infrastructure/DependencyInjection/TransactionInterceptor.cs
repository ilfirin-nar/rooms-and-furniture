using System;
using LightInject.Interception;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Infrastructure.DependencyInjection
{
    internal class TransactionInterceptor : ITransactionInterceptor
    {
        private readonly ISession session;

        public TransactionInterceptor(ISession session)
        {
            this.session = session;
        }

        public object Invoke(IInvocationInfo invocationInfo)
        {
            using (var transaction = session.Connection.BeginTransaction())
            {
                try
                {
                    var result = invocationInfo.Proceed();
                    transaction.Commit();
                    return result;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}