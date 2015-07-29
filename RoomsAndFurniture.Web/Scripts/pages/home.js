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
        input.datepicker({
            onSelect: function (dateFilter) {
                reloadTable(dateFilter);
                window.history.pushState(dateFilter, "DateFilter", '/?date=' + dateFilter.split(' ')[0]);
            }
        });
    }
    
    function initDialogs() {
        dialogs.initAddRoomDialog($('.addRoomLink'), addRowToRoomsTable);
        innitTableDialogs();
    }

    function innitTableDialogs() {
        dialogs.initRemoveRoomDialog($('.removeRoomLink'), deleteRowFromRoomsTable);
    }

    function addRowToRoomsTable(data) {
        $('.roomsNotFound').remove();
        var row = $(templates.formRoomsTableRowHtml(data));
        tableBody.append(row);
    }

    function reloadTable(dateFilter) {
        $.get(urls.GetRooms, { date: dateFilter }, function (data) {
            if (data.IsSuccess) {
                var rowHtml = '';
                if (data.Data === null || data.Data === undefined || data.Data.length === 0) {
                    if ($('.roomsNotFound').length > 0) {
                        return;
                    }
                    tableBody.closest('table').after(templates.formRoomsNotFoundHtml(dateFilter));
                    tableBody.html('');
                    return;
                }
                $('.roomsNotFound').remove();
                for (var index = 0; index < data.Data.length; index++) {
                    rowHtml += templates.formRoomsTableRowHtml(data.Data[index]);
                }
                tableBody.html(rowHtml);
                innitTableDialogs();
            } else {
                tableBody.html(data.Message);
            }
        });
    }

    function deleteRowFromRoomsTable(roomName) {
        if (roomName === null) {
            reloadTable($('.dateFilter').val());
            return;
        }
        tableBody.find("td.itemName:contains('" + roomName + "')").closest('tr').remove();
    }

})(App.Page, App.Dialogs, App.Templates.RoomsTemplates, App.Urls.Urls);