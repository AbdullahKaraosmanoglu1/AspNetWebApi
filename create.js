function createBook() {
    var name = $('#bookNameInput').val();
    var author = $('#authorInput').val();
    var language = $('#languageInput').val();
    var publisher = $('#publisherInput').val();
    var imagePath = $('#imagePathInput').val();
    var printingYear = parseInt($('#printingYearInput').val());
    var pageCount = parseInt($('#pageCountInput').val());
    var price = parseFloat($('#priceInput').val());
    var bookCategoryId = parseInt($('#bookCategoryIdInput').val());

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

    $.ajax({
        url: "https://localhost:7238/api/Book",
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(newBook),
        success: function (data) {
            console.log("Yeni kitap oluþturuldu:", data);
            
        },
        error: function (error) {
            console.error("Yeni kitap oluþturulurken bir hata oluþtu:", error);
            
        }
    });
}

$(document).ready(function () {
    $('#createBook').click(function () {
        window.location.href = 'create.html';
    });

    $('#createBookBtn').click(function () {
        createBook(); 
    });
});
