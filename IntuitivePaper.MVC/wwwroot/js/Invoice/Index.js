$(document).ready(function () {
    $('.delete-icon').click(function (e) {
        e.preventDefault();
        var invoiceId = $(this).data('invoice-id');
        var $invoiceElement = $(this).closest('.col-md-3');

        // Poka¿ modal
        $('#confirmModal').modal('show');

        // Obs³uga klikniêcia "Usuñ"
        $('#confirmDelete').click(function () {
            // Wywo³aj ¿¹danie usuwania faktury
            $.ajax({
                url: `/Invoice/${invoiceId}`,
                type: 'delete',
                success: function (result) {
                    toastr["success"]("Faktura zostala usunieta");
                    $invoiceElement.remove();
                    // Ukryj modal po usuniêciu faktury
                    $('#confirmModal').modal('hide');
                },
                error: function () {
                    toastr["error"]("Wystapil b³¹d podczas usuwania faktury");
                }
            });
        });
    });
});
