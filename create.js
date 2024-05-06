// JavaScript source code
/* CreateBookAsync(); EndPoint Request */
$(document).ready(function () {

    // Yeni kitap olu�tur butonuna t�kland���nda
    $('#createBook').click(function () {
        // Kullan�c�y� create.html sayfas�na y�nlendir
        window.location.href = 'create.html';
    });

    $('#createBookBtn').click(function () {
        // Kullan�c�n�n girdi�i bilgileri al
        var name = $('#bookNameInput').val();
        var author = $('#authorInput').val();
        var language = $('#languageInput').val();
        var publisher = $('#publisherInput').val();
        var imagePath = $('#imagePathInput').val();
        var printingYear = parseInt($('#printingYearInput').val());
        var pageCount = parseInt($('#pageCountInput').val());
        var price = parseFloat($('#priceInput').val());
        var bookCategoryId = parseInt($('#bookCategoryIdInput').val());

        // Yeni kitap nesnesi olu�tur
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

        // AJAX iste�i g�nder
        $.ajax({
            url: "https://localhost:7238/api/Book",
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(newBook),
            success: function (data) {
                console.log("Yeni kitap olu�turuldu:", data);
                // Ba�ar�l� bir �ekilde olu�turulan kitab� g�stermek i�in gerekli kodu buraya ekleyin
            },
            error: function (error) {
                console.error("Yeni kitap olu�turulurken bir hata olu�tu:", error);
                // Hata durumunda kullan�c�ya bir hata mesaj� g�stermek i�in gerekli kodu buraya ekleyin
            }
        });
    });
});