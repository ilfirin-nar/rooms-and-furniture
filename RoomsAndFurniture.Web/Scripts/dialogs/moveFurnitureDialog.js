(function(dialogs, urls) {

    'use strict';

    dialogs.initMoveFurnitureDialog = function (dialogOpenElement, callback) {
        var dialog,
            form,
            roomNameField = $("#moveFurnitureRoomNameField"),
            dateField = $("#moveFurnitureDateField"),
            furnitureField = $("#moveFurnitureTypeField"),
            roomMoveToField = $("#moveFurnitureRoomMoveToField"),
            allFields = $([]).add(roomNameField).add(dateField).add(furnitureField),
            tips = $(".validateTips"),
            clickedElement = null;

        $(dateField).datepicker();

        dialog = $(".moveFurnitureDialog").dialog({
            autoOpen: false,
            height: 460,
            width: 380,
            modal: true,
            buttons: {
                "Добавить мебель": addFurniture,
                "Отмена": function() {
                    dialog.dialog("close");
                }
            },
            close: function() {
                form[0].reset();
                allFields.removeClass("ui-state-error");
            }
        });

        form = dialog.find("form").on("submit", function(event) {
            event.preventDefault();
            addFurniture();
        });

        dialogOpenElement.on("click", function () {
            clickedElement = $(this);
            roomNameField.val(clickedElement.closest('tr').find('td.itemName').text());
            furnitureField.val(clickedElement.closest('li').find('.furnitureType').text());
            dialog.dialog("open");
        });

        function addFurniture() {
            var isValid = validate();
            if (isValid) {
                var parameters = {
                    type: furnitureField.val(),
                    roomNameFrom: roomNameField.val(),
                    roomNameTo: roomMoveToField.val(),
                    date: dateField.val()
                };
                $.get(urls.MoveFurniture, parameters, function (data) {
                    if (data.IsSuccess) {
                        callback();
                        dialog.dialog("close");
                    } else {
                        updateTips(data.Message);
                    }
                });
            }
            return isValid;
        }

        function validate() {
            var isValid = true;
            allFields.removeClass("ui-state-error");
            isValid = isValid && checkLength(roomMoveToField, "Переместить мебель в комнату", 3, 20);
            isValid = isValid && checkDateField();
            return isValid;
        }

        function checkLength(object, fieldName, min, max) {
            if (object.val().length > max || object.val().length < min) {
                setErrorClass(object);
                updateTips('Длина поля ' + fieldName + ' должна быть между ' + min + ' и ' + max + ' символов');
                return false;
            } else {
                return true;
            }
        }

        function checkDateField() {
            if (dateField.val() === '' || dateField.val() === null) {
                setErrorClass(dateField);
                updateTips('Поле Дата должно быть заполнено');
                return false;
            }
            return true;
        }

        function updateTips(tip) {
            tips.text(tip).addClass("ui-state-highlight");
            setTimeout(function() {
                tips.removeClass("ui-state-highlight", 1500);
            }, 500);
        }

        function setErrorClass(field) {
            field.addClass("ui-state-error");
        }
    }

})(App.Dialogs, App.Urls.Urls);