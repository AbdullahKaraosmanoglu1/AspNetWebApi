$(document).ready(function () {
    $('#getDataBtn').click(function () {
        $.ajax({
            url: "https://localhost:7238/api/Book",
            method: 'GET',
            success: function (data) {
                console.log(data.data);
                for (var i = 0; i < data.data.length; i++) {
                    var item = data.data[i];
                    console.log(item);
                    $('.name').html(item.name);
                    $('.author').html(item.author);
                    $('.publisher').html(item.publisher);
                }
            },
            error: function (error) {
                console.error(error);
            }
        });
    });
});
