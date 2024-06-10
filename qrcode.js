$(function () {
    $("#qr-gn").click(function () {
        $("#qrcode").html("");
        var txt = $.trim($('textarea[name="txt"]').val());
        if (txt == '') {
            alert("Please enter text you want to embed in QR Code");
            return false;
        }
        var size = $('select[name="size"]').val();
        var sizeSplit = size.split('x');
        var width = sizeSplit[0];
        var height = sizeSplit[1];
        generateQRcode(width, height, txt);
        return false;
    });

    function generateQRcode(width, height, text) {
        $('#qrcode').html("").qrcode({ width: width, height: height, text: text });
    }
});
