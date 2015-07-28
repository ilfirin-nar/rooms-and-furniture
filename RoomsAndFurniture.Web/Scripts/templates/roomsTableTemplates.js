(function (templates) {

    'use strict';

    templates.RoomsTemplates = (function() {
        function getRoomsTableRow(data) {
            return (
                '<tr>' +
                    '<td class="itemName">' + data.RoomName + '</td>' +
                    '<td class="itemDate">' + data.Date + '</td>' +
                    '<td>' +
                    '<ul>' +
                    data.Furniture +
                    '<li><a class="createFurnitureLink">+ Добавить мебель</a></li>' +
                    '</ul>' +
                    '</td>' +
                    '<td class="itemDelete"><a class="removeRoomLink">Удалить</a></td>' +
                    '</tr>'
            );
        }

        function getRoomsTableRowFurnitureItem(data) {
            return (
                '<li>' + data.Type + '(' + data.Count + 'шт)' +
                    '<div class="furnitureControls">' +
                        '<a class="addFurniture" href="/Furniture/Create">+ Добавить</a>' +
                        '<a class="removeFurniture" href="/Furniture/Remove">- Удалить</a>' +
                        '<a class="moveFurniture">Переместить</a>' +
                    '</div>' +
                '</li>'
            );
        }

        function formFrunitureHtml(items) {
            var index = 0;
            var result = '';
            if (items === null || items === undefined || items.length === 0) {
                return '<li class="emptyRoom">Комната пуста</li>';
            }
            while (index < items.length) {
                result += getRoomsTableRowFurnitureItem(items[index]);
                index++;
            }
            return result;
        }

        return {
            formRoomsTableRowHtml: function(data) {
                return getRoomsTableRow({
                    RoomName: data.RoomName,
                    Date: data.Date,
                    Furniture: formFrunitureHtml(data.FurnitureItems)
                });
            },
            formRoomsNotFoundHtml: function(dateFilter) {
                return '<div class="roomsNotFound">Комнат на дату ' + dateFilter.split(' ')[0] + ' не существует</div>';
            }
        };
    })();

})(App.Templates);