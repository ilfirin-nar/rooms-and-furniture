(function (urls) {

    'use strict';

    urls.Urls = {
        GetRooms: '/Room/Get',
        CreateRoom: '/Room/Create',
        RemoveRoom: '/Room/Remove',
        RemoveRoomWithoutMoving: '/Room/RemoveWithoutMoving',
        CreateFurniture: '/Furniture/Create',
        MoveFurniture: '/Furniture/Move',
        RemoveFurniture: '/Furniture/Remove'
    };

})(App.Urls);