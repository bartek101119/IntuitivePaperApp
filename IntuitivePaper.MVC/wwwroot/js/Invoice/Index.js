$(document).ready(function () {
    $('.delete-icon').click(function (e) {
        e.preventDefault();
        var invoiceId = $(this).data('invoice-id');
        var $invoiceElement = $(this).closest('.col-md-3');

        // Poka� modal
        $('#confirmModal').modal('show');

        // Obs�uga klikni�cia "Usu�"
        $('#confirmDelete').click(function () {
            // Wywo�aj ��danie usuwania faktury
            $.ajax({
                url: `/Invoice/${invoiceId}`,
                type: 'delete',
                success: function (result) {
                    toastr["success"]("Faktura zostala usunieta");
                    $invoiceElement.remove();
                    // Ukryj modal po usuni�ciu faktury
                    $('#confirmModal').modal('hide');
                },
                error: function () {
                    toastr["error"]("Wystapil b��d podczas usuwania faktury");
                }
            });
        });
    });
});
