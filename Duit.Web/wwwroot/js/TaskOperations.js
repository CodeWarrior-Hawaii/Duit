$(document).ready(function() {
    $('.todoCompleteChk').change(function() {
        var parent = $(this).parent();
        parent.toggleClass("strikethrough");
    });

    $('.todoCompleteChk').on('click',
        function(e) {
            e.stopPropagation();
        }
    );

    $('.newTaskBtn').on('click',
        function() {

        });
})

