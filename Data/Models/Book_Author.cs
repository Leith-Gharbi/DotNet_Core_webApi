using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Core_webApi.Data.Models
{
    public class Book_Author
    {
        public int Id { get; set; }

        // Navigation Properties
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AutherId { get; set; }
        public Author Author { get; set; }
    }
}
