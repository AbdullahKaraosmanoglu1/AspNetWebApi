function getAllBooks() {
    $.ajax({
        url: "https://localhost:7238/api/Book",
        method: 'GET',
        headers: { "Authorization": 'Bearer ' + localStorage.getItem('token') },
        success: function (data) {
            console.log(data);
            var tableContent = ''; // Tablo içeriğini saklayacak değişken
            data.data.forEach(function (book) {
                tableContent += '<tr>';
                tableContent += '<td>' + book.id + '</td>';
                tableContent += '<td>' + book.name + '</td>';
                tableContent += '<td>' + book.author + '</td>';
                tableContent += '<td>' + book.language + '</td>';
                tableContent += '<td>' + book.publisher + '</td>';
                tableContent += '<td>' + book.imagePath + '</td>';
                tableContent += '<td>' + book.slugName + '</td>';
                tableContent += '<td>' + book.printingYear + '</td>';
                tableContent += '<td>' + book.pageCount + '</td>';
                tableContent += '<td>' + book.price + '</td>';
                tableContent += '<td>' + book.bookCategoryId + '</td>';
                tableContent += '<td>' + book.createdDate + '</td>';
                tableContent += '<td>' + book.updatedDate + '</td>';
                tableContent += '<td>' + book.isActive + '</td>';
                tableContent += '<td>' + book.isDeleted + '</td>';
                tableContent += '<td>'; // Yeni işlemler için yeni bir hücre
                tableContent += '<i class="fas fa-edit edit-icon" data-book-id="' + book.id + '"></i>'; // Güncelleme ikonu
                tableContent += '<i class="fas fa-trash delete-icon" data-book-id="' + book.id + '"></i>'; // Silme ikonu
                tableContent += '<i class="fas fa-info-circle info-icon" data-book-id="' + book.id + '"></i>'; // Detay ikonu
                tableContent += '</td>';
                tableContent += '</tr>';
            });
            $('#dataBody').html(tableContent); // Tablo içeriğini dataBody içine ekle
        }
    });
}

$(document).ready(function () {
    $('#getData').click(function () {
        getAllBooks(); // Yeni fonksiyonu çağır
    });

    // info iconuna tıklandığında
    $(document).on('click', '.info-icon', function () {
        var bookId = $(this).data('book-id');

        // Fetch book data from the API
        $.ajax({
            url: "https://localhost:7238/api/Book/" + bookId,
            method: 'GET',
            success: function (data) {
                // Verileri Local Storage'a kaydet
                localStorage.setItem('bookData', JSON.stringify(data.data));
                // Diğer sayfaya yönlendir
                window.location.href = 'GetById.html';
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    });

    // Local Storage'dan verileri al ve inputlara yerleştir
    var bookData = JSON.parse(localStorage.getItem('bookData'));
    if (bookData) {
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
    }
});
