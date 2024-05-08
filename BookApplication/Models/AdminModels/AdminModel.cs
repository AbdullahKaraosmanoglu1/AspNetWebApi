using System.ComponentModel.DataAnnotations;

namespace BookApplication.WebApi.Models.AdminModels
{
    public class AdminModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string AccessToken { get; set; }
        public int RoleId { get; set; }
    }
}
