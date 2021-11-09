﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Core_webApi.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        // Navigation Properties

        public List<Book_Author> Book_Author { get; set; }

    }
}
