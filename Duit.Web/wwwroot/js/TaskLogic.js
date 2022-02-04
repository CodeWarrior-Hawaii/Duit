$(document).ready(function() {
    $('.deleteTaskLink').on('click',
        function() {
            var title = $(this).data('title');
            var id = $(this).data('id');
            $('.deleteTaskButton').data('id', id);
            $('#deleteModal').modal().toggle();
        }
    );

    $('.deleteTaskButton').on('click',
        function() {
            var id = $(this).data('id');
            $.ajax('/Tasks/Delete',
                {
                    method: 'POST',
                    data: {
                        id: id
                    },
                    success: function(data, status, jqxhr) {
                        if (status === 'success') {
                            $("#taskRow" + id).remove();
                            $('#deleteModal').modal().toggle();
                            $(document.body).removeClass("modal-open");
                        }
                    },
                    error: function(jqhxr, status, errorThrown) {
                        
                    }
                }
            );
        });
});