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
        public string? ImagePath { get; set; }

        public ICollection<UserBook> UserBooks { get; set; }

    }
}
