using System.ComponentModel.DataAnnotations;

namespace BookApplication.Data.Entity
{
    public class Role : BaseEntity
    {
        [StringLength(100)]
        public string RoleName { get; set; }
    }
}
