$(document).on("click", ".delete-icon", function () {
    // Silinecek kitab�n ID'sini al
    var bookId = $(this).data("book-id");

    // Confirm dialog ile kullan�c�dan silme i�lemini onay al
    var confirmation = confirm("Bu kitab� silmek istedi�inize emin misiniz?");

    // Kullan�c� onaylarsa
    if (confirmation) {
        // AJAX iste�i g�ndererek kitab� sil
        $.ajax({
            url: "https://localhost:7238/api/Book/" + bookId,
            type: "DELETE",
            success: function (response) {
                // Ba�ar�l� yan�t ald���m�zda veriyi yeniden y�kle
                $("#getData").click();
            },
            error: function (xhr, status, error) {
                // Hata durumunda konsola hata mesaj�n� yazd�r
                console.error(xhr.responseText);
            }
        });
    }
});
