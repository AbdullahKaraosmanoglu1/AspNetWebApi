function getRoles() {
    $.ajax({
        url: 'https://localhost:7238/api/Admin/GetAllRoles',
        method: 'GET',
        success: function (data) {
            // Rollerin seçeneklerini açýlýr menüye ekle
            var roleSelect = $('#roleInput');
            data.data.forEach(function (role) {
                roleSelect.append('<option value="' + role.id + '">' + role.roleName + '</option>');
                console.log("Rol Verileri:", data.data);
            });
        },
        error: function (error) {
            console.error('Roller alýnýrken bir hata oluþtu:', error);
        }
    });
}

// Kullanýcýyý kaydetme fonksiyonu
function registerUser() {
    // Formdaki verileri al
    var firstName = $('#firstNameInput').val();
    var lastName = $('#lastNameInput').val();
    var email = $('#emailInput').val();
    var password = $('#passwordInput').val();
    var roleId = $('#roleInput').val(); // Seçilen rolün ID'sini al

    // Yeni kullanýcý nesnesi oluþtur
    var newUser = {
        FirstName: firstName,
        LastName: lastName,
        Email: email,
        Password: password,
        RoleId: roleId // Kullanýcýnýn seçtiði rolün ID'sini ata
    };

    // Web API'ye istek gönder
    $.ajax({
        url: 'https://localhost:7238/api/User',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(newUser),
        success: function (data) {
            console.log('Kullanýcý baþarýyla kaydedildi:', data);
            // Baþka bir sayfaya yönlendirme veya baþka bir iþlem yapabilirsiniz
        },
        error: function (error) {
            console.error('Kullanýcý kaydedilirken bir hata oluþtu:', error);
            // Hata durumunda kullanýcýya bilgi verme veya yeniden deneme gibi iþlemler yapýlabilir
        }
    });
}


$(document).ready(function () {
    // Rollerin alýnmasý için AJAX isteði
    getRoles();

    // Kayýt ol düðmesine týklanýnca
    $('#registerBtn').click(function (event) {
        event.preventDefault(); // Formun varsayýlan davranýþýný engelle

        // Kullanýcýyý kaydet fonksiyonunu çaðýr
        registerUser();
    });
});

// Rollerin alýnmasý için AJAX isteðini içeren fonksiyon
