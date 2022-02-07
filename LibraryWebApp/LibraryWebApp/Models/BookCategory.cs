using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class BookCategory
    {

        public int BookCategoryId { get; set; }

        [Required]
        [DisplayName("Category's name")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public BookCategory()
        {
        }
    }
}
