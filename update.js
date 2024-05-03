$(document).ready(function () {
    $(document).on('click', '.edit-icon', function () {
        var bookId = $(this).data('book-id');

        // Fetch book data from the API
        $.ajax({
            url: "https://localhost:7238/api/Book/" + bookId,
            method: 'GET',
            success: function (data) {
               // var book = data.data; // Assuming the data is not nested
                $('#id').val(data.id);
                $('#updatedName').val(data.name);
                $('#updatedAuthor').val(data.author);
                $('#updatedLanguage').val(data.language);
                $('#updatedPublisher').val(data.publisher);
                $('#updatedImagePath').val(data.imagePath);
                $('#updatedSlugName').val(data.slugName);
                $('#updatedPrintingYear').val(data.printingYear);
                $('#updatedPageCount').val(data.pageCount);
                $('#updatedPrice').val(data.price);
                $('#updatedBookCategoryId').val(data.bookCategoryId);
                $('#updatedCreatedDate').val(data.createdDate);
                $('#updatedUpdatedDate').val(data.updatedDate);
                $('#updatedIsActive').val(data.isActive);
                $('#updatedIsDeleted').val(data.isDeleted);

                // Redirect to update page
                window.location.href = 'guncelleme.html?bookId=' + bookId;
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
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
                window.location.href = 'index.html';
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    });
});
