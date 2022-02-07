using LibraryWebApp.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [DisplayName("Book's name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Book's name cannot be less than 3 characters and longer than 50 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Author { get; set; }

        [Required]
        [ISBNValidator]
        public string ISBN { get; set; }

        [ForeignKey("BookCategoryId")]
        public int BookCategoryId { get; set; }

        [DisplayName("Category")]
        public BookCategory BookCategory { get; set; }

        public Book()
        {

        }
    }
}
