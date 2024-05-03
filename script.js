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
                    tableContent += '<td>' + book.createdDate + '</td>';
                    tableContent += '<td>' + book.updatedDate + '</td>';
                    tableContent += '<td>' + book.isActive + '</td>';
                    tableContent += '<td>' + book.isDeleted + '</td>';
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

