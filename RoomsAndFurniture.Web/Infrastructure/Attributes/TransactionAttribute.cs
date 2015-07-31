using System;

namespace RoomsAndFurniture.Web.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class TransactionAttribute : Attribute {}
}