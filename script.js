/* GetAllAsync(); EndPoint Request*/
$(document).ready(function () {
    $('#getAllBooksBtn').click(function () {
        $.ajax({
            url: "https://localhost:7238/api/Book",
            method: 'GET',
            success: function (data) {
                console.log(data);
                var booksHtml = ''; // Kitaplar�n HTML i�eri�ini saklayacak de�i�ken
                data.data.forEach(function (book) {
                    booksHtml += '<div class="book">';
                    booksHtml += '<p class="name">Name: ' + book.name + '</p>';
                    booksHtml += '<p class="author">Author: ' + book.author + '</p>';
                    booksHtml += '<p class="publisher">Publisher: ' + book.publisher + '</p>';
                    // Di�er �zelliklerde iste�e g�re eklenebilir...
                    booksHtml += '</div>';
                });
                $('#dataContainer').html(booksHtml); // Kitaplar�n HTML i�eri�ini dataContainer i�ine ekle
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
        // �rnek olarak, al�nacak kitab�n ID'si #bookIdInput alan�ndan al�nacak
        var bookId = $('#bookIdInput').val();

        // AJAX �a�r�s� yap�l�yor
        $.ajax({
            url: "https://localhost:7238/api/Book/" + bookId, // Book ID'sini URL'ye ekleyerek istek yap�l�yor
            method: 'GET',
            success: function (data) {
                console.log(data);

                // Al�nan kitab�n bilgileri HTML i�eri�ine d�n��t�r�l�yor
                var bookHtml = '<div class="book">';
                bookHtml += '<p class="name">Name: ' + data.data.name + '</p>';
                bookHtml += '<p class="author">Author: ' + data.data.author + '</p>';
                bookHtml += '<p class="publisher">Publisher: ' + data.data.publisher + '</p>';
                // Di�er �zelliklerde iste�e g�re eklenebilir...
                bookHtml += '</div>';

                // Kitap HTML i�eri�i dataContainer i�ine ekleniyor
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

    // Yeni kitap olu�tur butonuna t�kland���nda
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
