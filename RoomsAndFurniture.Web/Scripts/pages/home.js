(function (page, dialogs, templates) {

    'use strict';

    page.start = function () {
        var addRoomLink = $('.addRoomLink');
        dialogs.initRoomDialog(addRoomLink, addRowToRoomsTable);
    }

    function addRowToRoomsTable(data) {
        var row = $(templates.formRoomsTableRowHtml(data));
        $('.roomsTable tbody').append(row);
    }

})(App.Page, App.Dialogs, App.Templates.RoomsTemplates);