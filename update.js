/* GetAll EndPoint Request*/
$(document).ready(function () {
    $('#getData').click(function () {
        $.ajax({
            url: "https://localhost:7238/api/Book",
            method: 'GET',
            success: function (data) {
                console.log(data);
                var tableContent = ''; // Tablo içeriðini saklayacak deðiþken
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
                    // Tarih alanlarýný formatlayýn
                    var createdDate = new Date(book.createdDate);
                    var updatedDate = new Date(book.updatedDate);
                    tableContent += '<td>' + createdDate.getDate() + "-" + (createdDate.getMonth() + 1) + "-" + createdDate.getFullYear() + '</td>';
                    tableContent += '<td>' + updatedDate.getDate() + "-" + (updatedDate.getMonth() + 1) + "-" + updatedDate.getFullYear() + '</td>';
                    // isActive ve isDeleted alanlarýný düzenleyin
                    var isActiveText;
                    if (book.isActive === true) {
                        isActiveText = 'Aktif';
                    } else if (book.isActive === false) {
                        isActiveText = 'Pasif';
                    } else {
                        isActiveText = 'Onay Bekliyor';
                    }
                    var isDeletedText = book.isDeleted ? 'Silinmiþ' : 'Aktif';
                    tableContent += '<td>' + isActiveText + '</td>';
                    tableContent += '<td>' + isDeletedText + '</td>';
                    tableContent += '<td>'; // Ýþlemler için yeni bir hücre
                    tableContent += '<i class="fas fa-edit edit-icon" data-book-id="' + book.id + '"></i>'; // Güncelleme ikonu
                    tableContent += '<i class="fas fa-trash delete-icon" data-book-id="' + book.id + '"></i>'; // Silme ikonu
                    tableContent += '<i class="fas fa-info-circle info-icon" data-book-id="' + book.id + '"></i>'; // Detay ikonu
                    tableContent += '</td>';
                    tableContent += '</tr>';
                });
                $('#dataBody').html(tableContent); // Tablo içeriðini dataBody içine ekle 

            }
        });
    });
});

/* UpdateBook EndPoint Request*/
$(document).ready(function () {
    // Güncelleme butonuna týklandýðýnda
    $(document).on('click', '.edit-icon', function () {
        var bookId = $(this).data('book-id');

        // Fetch book data from the API
        $.ajax({
            url: "https://localhost:7238/api/Book/" + bookId,
            method: 'GET',
            success: function (data) {
                // Verileri Local Storage'a kaydet
                localStorage.setItem('bookData', JSON.stringify(data.data));
                // Diðer sayfaya yönlendir
                window.location.href = 'updateBook.html';
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    });
});

$(document).ready(function () {
    // Local Storage'dan verileri al
    var bookData = JSON.parse(localStorage.getItem('bookData'));
    if (bookData) {
        // Verileri inputlara yerleþtir
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

// Güncelleme butonuna týklandýðýnda
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

    // AJAX isteði ile güncelleme yap
    $.ajax({
        url: "https://localhost:7238/api/Book/",
        method: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(updatedBook),
        success: function (response) {
            console.log('Güncelleme baþarýlý.');
            // Güncelleme baþarýlý olduðunda baþka bir sayfaya yönlendirilebilirsiniz
            window.location.href = 'booksTable.html';
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
});



