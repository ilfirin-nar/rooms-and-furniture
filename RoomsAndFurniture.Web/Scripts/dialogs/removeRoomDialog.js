(function(dialogs, urls) {

    'use strict';

    dialogs.initRoomDialog = function (dialogOpenElement, callback) {
        var dialog,
            form,
            roomNameField = $("#roomCreateNameField"),
            dateField = $("#roomCreateDateField"),
            allFields = $([]).add(roomNameField).add(dateField),
            tips = $(".validateTips");

        $(dateField).datepicker();

        dialog = $(".addRoomDialog").dialog({
            autoOpen: false,
            height: 400,
            width: 380,
            modal: true,
            buttons: {
                "Создать комнату": addRoom,
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
            addRoom();
        });

        dialogOpenElement.on("click", function() {
            dialog.dialog("open");
        });

        function addRoom() {
            var isValid = validate();
            if (isValid) {
                var parameters = { name: roomNameField.val(), date: dateField.val() };
                $.get(urls.CreateRoom, parameters, function (data) {
                    if (data.IsSuccess) {
                        callback(data.Data);
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
            isValid = checkLength(roomNameField, "Название комнаты", 3, 20);
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