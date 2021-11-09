using DotNet_Core_webApi.Data.Models;
using DotNet_Core_webApi.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Core_webApi.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context )
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead =book.IsRead ? book.DateRead.Value: null,
                Rate = book.IsRead ? book.Rate.Value :null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AutherId = id
                };
                _context.Book_Authors.Add(_book_author);
            }
        }

        public List<Book> GetAllBooks() =>   _context.Books.ToList();

        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(n => n.Id==bookId);



        public Book UpdateBookById(int bookId ,BookVM book  )
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if( _book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _book.DateAdded = DateTime.Now;
                _context.SaveChanges();
            }
            return _book;


        }

        public void DeleteBookById(int bookId  )
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }

        }

    }
}
