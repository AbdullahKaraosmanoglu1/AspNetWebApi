
/*GETALL Request*/
$(document).ready(function () {
    $('#getDataBtn').click(function () {
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
                    // Diðer özellikleri de ekleyebilirsiniz
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