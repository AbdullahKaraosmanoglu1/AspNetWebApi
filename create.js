// JavaScript source code
/* CreateBookAsync(); EndPoint Request */
$(document).ready(function () {

    // Yeni kitap oluþtur butonuna týklandýðýnda
    $('#createBook').click(function () {
        // Kullanýcýyý create.html sayfasýna yönlendir
        window.location.href = 'create.html';
    });

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