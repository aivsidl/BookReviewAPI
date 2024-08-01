using BookReviewAPI.Data;
using BookReviewAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookReviewAPI.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new List<Book>();

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public int AddBook(Book book)
        {
            
            Book? lastBook = BookStore.BookList // .Max(fp => fp.Id);
                .OrderByDescending(fp => fp.Id)
                .FirstOrDefault();
            if (lastBook != null)
            {
                book.Id = lastBook.Id + 1;
               
            }
            else 
            { 
                book.Id = 1;
            }
            BookStore.BookList.Add(book);
            return book.Id;
        }

        public void UpdateBook(Book book)
        {
            var existingBook = GetBookById(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.PublishedDate = book.PublishedDate;
            }
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}
