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
            if (session.InTransaction)
            {
                return invocationInfo.Proceed();
            }
            using (var transaction = session.Connection.BeginTransaction())
            {
                session.InTransaction = true;
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
                finally
                {
                    session.InTransaction = false;
                }
            }
        }
    }
}