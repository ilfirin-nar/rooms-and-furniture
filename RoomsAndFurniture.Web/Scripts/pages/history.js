(function (page, dialogs) {

    'use strict';

    page.start = function() {
        $('.shortHistory').on('change', function() {
            window.location.href = '/History?isShort=' + $(this).is(':checked');
        });
    };

})(App.Page, App.Dialogs);