using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Data.Entity
{
    public class Book : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Author { get; set; }
        [StringLength(50)]
        public string Language { get; set; }
        [StringLength(100)]
        public string Publisher { get; set; }
        [StringLength(500)]
        public string? ImagePath { get; set; }
        [StringLength(100)]
        public string? SlugName { get; set; }
        public int PageCount { get; set; }
        public int PrintingYear { get; set; }
        public decimal Price { get; set; }

        public int BookCategoryId { get; set; }
        public BookCategory BookCategory { get; set; }

        public ICollection<UserBook> UserBooks { get; set; }
    }
}
