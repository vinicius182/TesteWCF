(function ($) {
    'use strict';
    $(function () {
        var todoListItem = $('.todo-list');

        todoListItem.on('change', '.checkbox', function () {
            if ($(this).attr('checked')) {
                $(this).removeAttr('checked');
            } else {
                $(this).attr('checked', 'checked');
            }
            $(this).closest("label").toggleClass('completed');
        });
    });
})(jQuery);