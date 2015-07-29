(function(dialogs, urls) {

    'use strict';

    dialogs.initRemoveRoomDialog = function (dialogOpenElement, callback) {
        var dialog,
            form,
            roomNameField = $(".roomNameField"),
            roomNameMoveToField = $(".roomNameMoveToField"),
            dateField = $(".roomRemoveDateField"),
            allFields = $([]).add(roomNameField).add(dateField),
            tips = $(".validateTips"),
            isWithoutMoving = false;

        $(dateField).datepicker();

        dialog = $(".removeRoomDialog").dialog({
            autoOpen: false,
            height: 400,
            width: 380,
            modal: true,
            buttons: {
                "Удалить комнату": removeRoom,
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
            removeRoom();
        });

        dialogOpenElement.on("click", function () {
            var element = $(this), tr = element.closest('tr');
            isWithoutMoving = tr.find('.emptyRoom').length > 0;
            if (isWithoutMoving) {
                hideMoveToField();
            } else {
                showMoveToField();
            }
            roomNameField.val(tr.find('td.itemName').text());
            dialog.dialog("open");
        });

        function showMoveToField() {
            dialog.find('.roomNameMoveToFieldLabel').show();
            dialog.find('.roomNameMoveToField').show();
        }

        function hideMoveToField() {
            dialog.find('.roomNameMoveToFieldLabel').hide();
            dialog.find('.roomNameMoveToField').hide();
        }

        function removeRoom() {
            var isValid = validate();
            if (isValid) {
                if (isWithoutMoving) {
                    var parameters = { name: roomNameField.val(), date: dateField.val() };
                    $.get(urls.RemoveRoomWithoutMoving, parameters, function(data) {
                        if (data.IsSuccess) {
                            callback(data.Data);
                            dialog.dialog("close");
                        } else {
                            updateTips(data.Message);
                        }
                    });
                } else {
                    var parameters = {
                        name: roomNameField.val(),
                        moveFurnitureTo: roomNameMoveToField.val(),
                        date: dateField.val()
                    };
                    $.get(urls.RemoveRoom, parameters, function (data) {
                        if (data.IsSuccess) {
                            callback(roomNameField.val());
                            dialog.dialog("close");
                        } else {
                            updateTips(data.Message);
                        }
                    });
                }
            }
            return isValid;
        }

        function validate() {
            var isValid = true;
            allFields.removeClass("ui-state-error");
            if (!isWithoutMoving) {
                isValid = checkLength(roomNameMoveToField, "Комната, куда переместить мебель", 3, 20);
            }
            isValid = isValid && checkDateField();
            return isValid;
        }

        function checkLength(object, fieldName, min, max) {
            if (object.val().length > max || object.val().length < min) {
                setErrorClass(object);
                updateTips('Длина поля ' + fieldName + ' должна быть между ' + min + ' и ' + max + '.');
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