using DotNet_Core_webApi.Data.Models;
using DotNet_Core_webApi.Data.ViewModels;
using DotNet_Core_webApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNet_Core_webApi.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public Publisher  AddPublisher (PublisherVM publisherVM)
        {
            if (StringStarsWithNumber(publisherVM.Name))
            {
                throw new PublisherNameException("Name starts with number",publisherVM.Name);
            }
            var _publisher = new Publisher()
            {
                Name = publisherVM.Name
            };
            _context.publishers.Add(_publisher);
            _context.SaveChanges();
            return _publisher;
        }

        internal List<Publisher> GetAllPublishers(string sortBy) { 

           var allPublishers= _context.publishers.OrderBy(n=>n.Name).ToList();
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        allPublishers = allPublishers.OrderByDescending(n => n.Name).ToList();
                        break;

                    default:
                        break;
                }
            }
            return allPublishers;
        }

        public Publisher GetPublisherById(int id) => _context.publishers.FirstOrDefault(n => n.Id == id);
        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.publishers.Where(n => n.Id == publisherId).Select(n => new PublisherWithBooksAndAuthorsVM()
            {
                Name = n.Name,
                BookAuthors = n.Books.Select(n => new BookAuthorVM()
                {
                    BookName = n.Title,
                    BookAuthors = n.Book_Author.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();
            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.publishers.FirstOrDefault(n => n.Id == id);
            if(_publisher != null)
            {
                _context.publishers.Remove(_publisher);
                _context.SaveChanges();
            } else
            {
                throw new Exception($"The publisher with id : {id} does not exist ");
            }
        }
         private bool StringStarsWithNumber(string name) => (Regex.IsMatch(name, @"^\d")) ;
    }
}
