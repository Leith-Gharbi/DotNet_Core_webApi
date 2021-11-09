﻿using DotNet_Core_webApi.Data.Models;
using DotNet_Core_webApi.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Core_webApi.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void  AddAuthor (AuthorVM authorVm)
        {
            var _author = new Author()
            {
                FullName = authorVm.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
    }
}
