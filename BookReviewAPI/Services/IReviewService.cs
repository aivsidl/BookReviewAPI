using BookReviewAPI.Models;
using System.Collections.Generic;

namespace BookReviewAPI.Services
{
    public interface IReviewService
    {
        IEnumerable<Review> GetReviewsByBookId(int bookId);
        Review GetReviewById(int bookId, int id);
        void AddReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int bookId, int id);
    }
}
