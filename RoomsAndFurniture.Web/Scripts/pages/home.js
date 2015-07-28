(function (page, dialogs, templates, urls) {

    'use strict';

    var tableBody;

    page.start = function () {
        initVars();
        $.datepicker.setDefaults({ dateFormat: 'yy-mm-dd' });
        initFilter();
        initDialogs();
    }

    function initVars() {
        tableBody = $('.roomsTable tbody');
    }

    function initFilter() {
        var input = $('.dateFilter');
        input.datepicker({ onSelect: reloadTable });
    }
    
    function initDialogs() {
        dialogs.initRoomDialog($('.addRoomLink'), addRowToRoomsTable);
    }

    function addRowToRoomsTable(data) {
        var row = $(templates.formRoomsTableRowHtml(data));
        tableBody.append(row);
    }

    function reloadTable(dateFilter) {
        $.get(urls.GetRooms, { date: dateFilter }, function (data) {
            if (data.IsSuccess) {
                var rowHtml = '';
                for (var index = 0; index < data.Data.length; index++) {
                    rowHtml += templates.formRoomsTableRowHtml(data.Data[index]);
                }
                tableBody.html(rowHtml);
            } else {
                tableBody.html(data.Message);
            }
        });
    }

})(App.Page, App.Dialogs, App.Templates.RoomsTemplates, App.Urls.Urls);