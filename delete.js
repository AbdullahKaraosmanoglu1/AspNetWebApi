$(document).on("click", ".delete-icon", function () {
    // Silinecek kitabýn ID'sini al
    var bookId = $(this).data("book-id");

    // Confirm dialog ile kullanýcýdan silme iþlemini onay al
    var confirmation = confirm("Bu kitabý silmek istediðinize emin misiniz?");

    // Kullanýcý onaylarsa
    if (confirmation) {
        // AJAX isteði göndererek kitabý sil
        $.ajax({
            url: "https://localhost:7238/api/Book/" + bookId,
            type: "DELETE",
            success: function (response) {
                // Baþarýlý yanýt aldýðýmýzda veriyi yeniden yükle
                $("#getData").click();
            },
            error: function (xhr, status, error) {
                // Hata durumunda konsola hata mesajýný yazdýr
                console.error(xhr.responseText);
            }
        });
    }
});
