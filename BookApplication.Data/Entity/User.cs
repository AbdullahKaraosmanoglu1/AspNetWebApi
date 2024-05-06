using System.ComponentModel.DataAnnotations;

namespace BookApplication.Data.Entity
{
    public class User : BaseEntity
    {
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(500)]
        public string Email { get; set; }
        [StringLength(500)]
        public string Password { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? AccessTokenCreatedDate { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenCreatedDate { get; set; }
        [StringLength(100)]
        public string? ImagePath { get; set; }
        public decimal MoneyAmount { get; set; }
        public int RoleId { get; set; }

        public ICollection<UserBook> UserBooks { get; set; }

    }
}
