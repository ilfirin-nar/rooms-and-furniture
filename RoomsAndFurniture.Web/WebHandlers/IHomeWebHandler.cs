﻿using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Models;

namespace RoomsAndFurniture.Web.WebHandlers
{
    public interface IHomeWebHandler : IWebHandler
    {
        HomeClientModel Get();
    }
}