/* GetAllAsync(); EndPoint Request*/
$(document).ready(function () {
    $('#getAllBooksBtn').click(function () {
        $.ajax({
            url: "https://localhost:7238/api/Book",
            method: 'GET',
            success: function (data) {
                console.log(data);
                var booksHtml = ''; // Kitaplarýn HTML içeriðini saklayacak deðiþken
                data.data.forEach(function (book) {
                    booksHtml += '<div class="book">';
                    booksHtml += '<p class="name">Name: ' + book.name + '</p>';
                    booksHtml += '<p class="author">Author: ' + book.author + '</p>';
                    booksHtml += '<p class="publisher">Publisher: ' + book.publisher + '</p>';
                    // Diðer özelliklerde isteðe göre eklenebilir...
                    booksHtml += '</div>';
                });
                $('#dataContainer').html(booksHtml); // Kitaplarýn HTML içeriðini dataContainer içine ekle
            },
            error: function (error) {
                console.error(error);
            }
        });
    });
});

/* GetByIdAsync(); EndPoint Request */
$(document).ready(function () {
    $('#getBookByIdSection').click(function () {
        // Örnek olarak, alýnacak kitabýn ID'si #bookIdInput alanýndan alýnacak
        var bookId = $('#bookIdInput').val();

        // AJAX çaðrýsý yapýlýyor
        $.ajax({
            url: "https://localhost:7238/api/Book/" + bookId, // Book ID'sini URL'ye ekleyerek istek yapýlýyor
            method: 'GET',
            success: function (data) {
                console.log(data);

                // Alýnan kitabýn bilgileri HTML içeriðine dönüþtürülüyor
                var bookHtml = '<div class="book">';
                bookHtml += '<p class="name">Name: ' + data.data.name + '</p>';
                bookHtml += '<p class="author">Author: ' + data.data.author + '</p>';
                bookHtml += '<p class="publisher">Publisher: ' + data.data.publisher + '</p>';
                // Diðer özelliklerde isteðe göre eklenebilir...
                bookHtml += '</div>';

                // Kitap HTML içeriði dataContainer içine ekleniyor
                $('#dataContainer').html(bookHtml);
            },
            error: function (error) {
                console.error(error);
            }
        });
    });
});

/* CreateBookAsync(); EndPoint Request */
$(document).ready(function () {   

    // Yeni kitap oluþtur butonuna týklandýðýnda
    $('#createBookBtn').click(function () {
        // Kullanýcýnýn girdiði bilgileri al
        var name = $('#bookNameInput').val();
        var author = $('#authorInput').val();
        var language = $('#languageInput').val();
        var publisher = $('#publisherInput').val();
        var imagePath = $('#imagePathInput').val();
        var printingYear = parseInt($('#printingYearInput').val());
        var pageCount = parseInt($('#pageCountInput').val());
        var price = parseFloat($('#priceInput').val());
        var bookCategoryId = parseInt($('#bookCategoryIdInput').val());

        // Yeni kitap nesnesi oluþtur
        var newBook = {
            Name: name,
            Author: author,
            Language: language,
            Publisher: publisher,
            ImagePath: imagePath,
            SlugName: name,
            PrintingYear: printingYear,
            PageCount: pageCount,
            Price: price,
            BookCategoryId: bookCategoryId
        };

        // AJAX isteði gönder
        $.ajax({
            url: "https://localhost:7238/api/Book",
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(newBook),
            success: function (data) {
                console.log("Yeni kitap oluþturuldu:", data);
                // Baþarýlý bir þekilde oluþturulan kitabý göstermek için gerekli kodu buraya ekleyin
            },
            error: function (error) {
                console.error("Yeni kitap oluþturulurken bir hata oluþtu:", error);
                // Hata durumunda kullanýcýya bir hata mesajý göstermek için gerekli kodu buraya ekleyin
            }
        });
    });
});
