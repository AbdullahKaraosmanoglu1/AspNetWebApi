function deleteBook(bookId) {

    var confirmation = confirm("Bu kitabı silmek istediğinize emin misiniz?");

    if (confirmation) {
        $.ajax({
            url: "https://localhost:7238/api/Book/" + bookId,
            type: "DELETE",
            success: function (response) {

                $("#getData").click();
            },
            error: function (xhr, status, error) {

                console.error(xhr.responseText);
            }
        });
    }
}

$(document).on("click", ".delete-icon", function () {
    // Silinecek kitavın ID'sini al
    var bookId = $(this).data("book-id");
    deleteBook(bookId);
});
