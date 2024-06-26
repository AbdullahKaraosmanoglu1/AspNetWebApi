function fetchBookDataAndUpdate(bookId) {
    // Fetch book data from the API
    $.ajax({
        url: "https://localhost:7238/api/Book/" + bookId,
        method: 'GET',
        success: function (data) {
            // Verileri Local Storage'a kaydet
            localStorage.setItem('bookData', JSON.stringify(data.data));
            // Diğer sayfaya yönlendir
            window.location.href = 'updateBook.html';
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}

$(document).ready(function () {
    // Güncelleme butonuna tıklandığında
    $(document).on('click', '.edit-icon', function () {
        var bookId = $(this).data('book-id');
        fetchBookDataAndUpdate(bookId); // Yeni fonksiyonu çağır
    });

    // Local Storage'dan verileri al
    var bookData = JSON.parse(localStorage.getItem('bookData'));
    if (bookData) {
        // Verileri inputlara yerleştir
        $('#id').val(bookData.id);
        $('#updatedName').val(bookData.name);
        $('#updatedAuthor').val(bookData.author);
        $('#updatedLanguage').val(bookData.language);
        $('#updatedPublisher').val(bookData.publisher);
        $('#updatedImagePath').val(bookData.imagePath);
        $('#updatedSlugName').val(bookData.slugName);
        $('#updatedPrintingYear').val(bookData.printingYear);
        $('#updatedPageCount').val(bookData.pageCount);
        $('#updatedPrice').val(bookData.price);
        $('#updatedBookCategoryId').val(bookData.bookCategoryId);
        $('#updatedCreatedDate').val(bookData.createdDate);
        $('#updatedUpdatedDate').val(bookData.updatedDate);
        $('#updatedIsActive').val(bookData.isActive);
        $('#updatedIsDeleted').val(bookData.isDeleted);

        // Local Storage'dan verileri temizle
        localStorage.removeItem('bookData');
    }
});

// Güncelleme butonuna tıklandığında
$('#updateButton').click(function (event) {
    event.preventDefault();
    // Güncellenecek verileri al
    var updatedBook = {
        id: $('#id').val(),
        name: $('#updatedName').val(),
        author: $('#updatedAuthor').val(),
        language: $('#updatedLanguage').val(),
        publisher: $('#updatedPublisher').val(),
        imagePath: $('#updatedImagePath').val(),
        slugName: $('#updatedSlugName').val(),
        printingYear: $('#updatedPrintingYear').val(),
        pageCount: $('#updatedPageCount').val(),
        price: $('#updatedPrice').val(),
        bookCategoryId: $('#updatedBookCategoryId').val(),
        createdDate: $('#updatedCreatedDate').val(),
        updatedDate: $('#updatedUpdatedDate').val(),
        isActive: $('#updatedIsActive').val(),
        isDeleted: $('#updatedIsDeleted').val()
    };

    // AJAX isteği ile güncelleme yap
    $.ajax({
        url: "https://localhost:7238/api/Book/",
        method: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(updatedBook),
        success: function (response) {
            console.log('Güncelleme başarılı.');
            // Güncelleme başarılı olduğunda başka bir sayfaya yönlendirilebilirsiniz
            window.location.href = 'booksTable.html';
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
});
