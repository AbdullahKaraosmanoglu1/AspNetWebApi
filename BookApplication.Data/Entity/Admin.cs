using System.ComponentModel.DataAnnotations;

namespace BookApplication.Data.Entity
{
    public class Admin : BaseEntity
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(500)]
        public string? AccessToken { get; set; }

        [StringLength(500)]
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenCreatedDate { get; set; }
        public DateTime? AccessTokenCreatedDate { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
