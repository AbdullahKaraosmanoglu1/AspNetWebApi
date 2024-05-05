/* DeleteAsync(); EndPoint Request */
$(document).on("click", ".delete-icon", function () {
    // Silinecek kitavın ID'sini al
    var bookId = $(this).data("book-id");

    // Confirm dialog ile kullanıcıdan silme işleminin onay al
    var confirmation = confirm("Bu kitabı silmek istediğinize emin misiniz?");

    // Kullanıcı onaylarsa
    if (confirmation) {
        // AJAX isteði göndererek kitabı sil
        $.ajax({
            url: "https://localhost:7238/api/Book/" + bookId,
            type: "DELETE",
            success: function (response) {
                // Başarılı yanıt aldıðımızda veriyi yeniden yükle
                $("#getData").click();
            },
            error: function (xhr, status, error) {
                // Hata durumunda konsola hata mesajını yazdır
                console.error(xhr.responseText);
            }
        });
    }
});