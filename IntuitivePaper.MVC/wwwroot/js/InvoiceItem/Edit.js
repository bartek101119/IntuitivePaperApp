$(document).ready(function () {

    const RenderInvoiceItem = (invoiceItem, container) => {
        container.empty();

        for (const element of invoiceItem) {
            const square = $('<div class="square"></div>'); // Tworzenie elementu kwadratowego
            square.attr('data-invoice-item-id', element.id);

            // Generowanie zawartości kwadratu na podstawie właściwości faktury
            const description = $('<p></p>').text(`Opis: ${element.description}`);
            const unitPrice = $('<p></p>').text(`Cena jednostkowa: ${element.unitPrice} PLN`);
            const quantity = $('<p></p>').text(`Ilość: ${element.quantity}`);
            const netAmount = $('<p></p>').text(`Wartość netto: ${element.netAmount} PLN`);
            const taxRate = $('<p></p>').text(`Stawka podatku VAT: ${element.taxRate}%`);
            const taxAmount = $('<p></p>').text(`Kwota podatku VAT: ${element.taxAmount} PLN`);
            const grossAmount = $('<p></p>').text(`Wartość brutto: ${element.grossAmount} PLN`);
            const deleteButton = $('<button class="delete-button">Usuń</button>');

            // Dodawanie wygenerowanych elementów do kwadratu
            square.append(description, unitPrice, quantity, netAmount, taxRate, taxAmount, grossAmount, deleteButton);

            // Dodawanie kwadratu do kontenera
            container.append(square);
        }

        // Stylowanie kwadratów obok siebie
        const squares = container.find('.square');
        squares.css('display', 'inline-block');
        squares.css('margin-right', '10px');
        squares.css('padding', '10px');
        squares.css('border', '1px solid black');
        squares.css('background-color', '#F2F2F2');
    }



    const LoadInvoiceItem = () => {
        const container = $("#invoiceItem")
        const invoiceId = container.data("id")


        $.ajax({
            url: `/Invoice/${invoiceId}/InvoiceItem`,
            type: 'get',
            success: function (data) {
                if (!data.length) {
                    container.html("Na tej fakturze nie ma żadnych pozycji")
                }
                else {
                    RenderInvoiceItem(data, container)
                    attachDeleteButtonHandler(container)
                }
            },
            error: function () {
                toastr["error"]("Błąd po stronie serwera. Proszę spróbować później")
            }
        })
    }

    const attachDeleteButtonHandler = (container) => {
        container.on('click', '.delete-button', function () {
            const square = $(this).closest('.square');
            const invoiceId = container.data('id');
            const invoiceItemId = square.data('invoice-item-id'); // Pobranie identyfikatora elementu faktury

            // Wywołanie żądania AJAX do usunięcia elementu faktury
            $.ajax({
                url: `/Invoice/${invoiceId}/InvoiceItem/${invoiceItemId}`,
                type: 'delete',
                success: function () {
                    square.remove(); // Usunięcie kwadratu po usunięciu elementu faktury
                    toastr["success"]("Pomyślnie usunięto pozycję faktury");
                },
                error: function () {
                    toastr["error"]("Błąd podczas usuwania pozycji faktury");
                }
            });
        });
    }

    LoadInvoiceItem()

    $("#createInvoiceItemModal form").submit(function (event) {
        event.preventDefault();

        const container = $("#invoiceItem");
        const invoiceId = container.data("id");

        const invoiceItemsCount = container.find('.square').length;
        console.log('Liczba pozycji:', invoiceItemsCount); // Sprawdzenie liczby pozycji na konsoli

        if (invoiceItemsCount < 13) {
            $.ajax({
                url: $(this).attr('action'),
                type: $(this).attr('method'),
                data: $(this).serialize(),
                success: function (data) {
                    toastr["success"]("Dodano nową pozycję do faktury")
                    // Załaduj zaktualizowane pozycje faktury
                    $.ajax({
                        url: `/Invoice/${invoiceId}/InvoiceItem`,
                        type: 'get',
                        success: function (response) {
                            RenderInvoiceItem(response, container);
                        },
                        error: function () {
                            toastr["error"]("Błąd podczas pobierania danych");
                        }
                    });
                },
                error: function () {
                    toastr["error"]("Dodawanie nie powiodło się")
                }
            })
        }
        else {
            toastr["error"]("Możesz dodać maksymalnie 13 pozycji na fakturze")
        }
    })
});