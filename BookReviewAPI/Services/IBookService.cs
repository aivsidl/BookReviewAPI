using BookReviewAPI.Models;
using System.Collections.Generic;

namespace BookReviewAPI.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        int AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
