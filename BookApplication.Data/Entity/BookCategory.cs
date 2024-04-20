using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Data.Entity
{
    public class BookCategory : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string? ImagePath { get; set; }
        [StringLength(100)]
        public string? SlugName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
