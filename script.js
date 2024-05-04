/* GetAllAsync(); EndPoint Request*/
$(document).ready(function () {
    $('#getAllBooksBtn').click(function () {
        $.ajax({
            url: "https://localhost:7238/api/Book",
            method: 'GET',
            success: function (data) {
                console.log(data);
                var booksHtml = ''; // Kitapların HTML içeriğini saklayacak değişken
                data.data.forEach(function (book) {
                    booksHtml += '<div class="book">';
                    booksHtml += '<p class="name">Name: ' + book.name + '</p>';
                    booksHtml += '<p class="author">Author: ' + book.author + '</p>';
                    booksHtml += '<p class="publisher">Publisher: ' + book.publisher + '</p>';
                    // Diğer özelliklerde isteğe göre eklenebilir...
                    booksHtml += '</div>';
                });
                $('#dataContainer').html(booksHtml); // Kitapların HTML içeriğini dataContainer içine ekle
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
        // Örnek olarak, alınacak kitabın ID'si #bookIdInput alanından alınacak
        var bookId = $('#bookIdInput').val();

        // AJAX çağrısı yapılıyor
        $.ajax({
            url: "https://localhost:7238/api/Book/" + bookId, // Book ID'sini URL'ye ekleyerek istek yapılıyor
            method: 'GET',
            success: function (data) {
                console.log(data);

                // Alınan kitabın bilgileri HTML içeriğine dönüştürülüyor
                var bookHtml = '<div class="book">';
                bookHtml += '<p class="name">Name: ' + data.data.name + '</p>';
                bookHtml += '<p class="author">Author: ' + data.data.author + '</p>';
                bookHtml += '<p class="publisher">Publisher: ' + data.data.publisher + '</p>';
                // Diğer özelliklerde isteğe göre eklenebilir...
                bookHtml += '</div>';

                // Kitap HTML içeriği dataContainer içine ekleniyor
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

    // Yeni kitap oluştur butonuna tıklandığında
    $('#createBookBtn').click(function () {
        // Kullanıcının girdiği bilgileri al
        var name = $('#bookNameInput').val();
        var author = $('#authorInput').val();
        var language = $('#languageInput').val();
        var publisher = $('#publisherInput').val();
        var imagePath = $('#imagePathInput').val();
        var printingYear = parseInt($('#printingYearInput').val());
        var pageCount = parseInt($('#pageCountInput').val());
        var price = parseFloat($('#priceInput').val());
        var bookCategoryId = parseInt($('#bookCategoryIdInput').val());

        // Yeni kitap nesnesi oluştur
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

        // AJAX isteği gönder
        $.ajax({
            url: "https://localhost:7238/api/Book",
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(newBook),
            success: function (data) {
                console.log("Yeni kitap oluşturuldu:", data);
                // Başarılı bir şekilde oluşturulan kitabı göstermek için gerekli kodu buraya ekleyin
            },
            error: function (error) {
                console.error("Yeni kitap oluşturulurken bir hata oluştu:", error);
                // Hata durumunda kullanıcıya bir hata mesajı göstermek için gerekli kodu buraya ekleyin
            }
        });
    });
});

/* DeleteAsync(); EndPoint Request */
$(document).on("click", ".delete-icon", function () {
    // Silinecek kitavın ID'sini al
    var bookId = $(this).data("book-id");

    // Confirm dialog ile kullanıcıdan silme işleminin onay al
    var confirmation = confirm("Bu kitabı silmek istediðinize emin misiniz?");

    // Kullanıcı onaylarsa
    if (confirmation) {
        // AJAX isteði göndererek kitabı sil
        $.ajax({
            url: "https://localhost:7238/api/Book/" + bookId,
            type: "DELETE",
            success: function (response) {
                // Başarılı yanıt aldıðımızda veriyi yeniden yükle
                $("#getData").click();
            },
            error: function (xhr, status, error) {
                // Hata durumunda konsola hata mesajını yazdır
                console.error(xhr.responseText);
            }
        });
    }
});