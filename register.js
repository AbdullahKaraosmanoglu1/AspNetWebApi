function getRoles() {
    $.ajax({
        url: 'https://localhost:7238/api/Admin/GetAllRoles',
        method: 'GET',
        success: function (data) {
            // Rollerin se�eneklerini a��l�r men�ye ekle
            var roleSelect = $('#roleInput');
            data.data.forEach(function (role) {
                roleSelect.append('<option value="' + role.id + '">' + role.roleName + '</option>');
                console.log("Rol Verileri:", data.data);
            });
        },
        error: function (error) {
            console.error('Roller al�n�rken bir hata olu�tu:', error);
        }
    });
}

// Kullan�c�y� kaydetme fonksiyonu
function registerUser() {
    // Formdaki verileri al
    var firstName = $('#firstNameInput').val();
    var lastName = $('#lastNameInput').val();
    var email = $('#emailInput').val();
    var password = $('#passwordInput').val();
    var roleId = $('#roleInput').val(); // Se�ilen rol�n ID'sini al

    // Yeni kullan�c� nesnesi olu�tur
    var newUser = {
        FirstName: firstName,
        LastName: lastName,
        Email: email,
        Password: password,
        RoleId: roleId // Kullan�c�n�n se�ti�i rol�n ID'sini ata
    };

    // Web API'ye istek g�nder
    $.ajax({
        url: 'https://localhost:7238/api/User',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(newUser),
        success: function (data) {
            console.log('Kullan�c� ba�ar�yla kaydedildi:', data);
            // Ba�ka bir sayfaya y�nlendirme veya ba�ka bir i�lem yapabilirsiniz
        },
        error: function (error) {
            console.error('Kullan�c� kaydedilirken bir hata olu�tu:', error);
            // Hata durumunda kullan�c�ya bilgi verme veya yeniden deneme gibi i�lemler yap�labilir
        }
    });
}


$(document).ready(function () {
    // Rollerin al�nmas� i�in AJAX iste�i
    getRoles();

    // Kay�t ol d��mesine t�klan�nca
    $('#registerBtn').click(function (event) {
        event.preventDefault(); // Formun varsay�lan davran���n� engelle

        // Kullan�c�y� kaydet fonksiyonunu �a��r
        registerUser();
    });
});

// Rollerin al�nmas� i�in AJAX iste�ini i�eren fonksiyon
