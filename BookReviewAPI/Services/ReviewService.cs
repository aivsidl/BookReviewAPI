using BookReviewAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookReviewAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly List<Review> _reviews = new List<Review>();

        public IEnumerable<Review> GetReviewsByBookId(int bookId)
        {
            return _reviews.Where(r => r.BookId == bookId);
        }

        public Review GetReviewById(int bookId, int id)
        {
            return _reviews.FirstOrDefault(r => r.BookId == bookId && r.Id == id);
        }

        public void AddReview(Review review)
        {
            _reviews.Add(review);
        }

        public void UpdateReview(Review review)
        {
            var existingReview = GetReviewById(review.BookId, review.Id);
            if (existingReview != null)
            {
                existingReview.ReviewerName = review.ReviewerName;
                existingReview.Rating = review.Rating;
                existingReview.Comment = review.Comment;
            }
        }

        public void DeleteReview(int bookId, int id)
        {
            var review = GetReviewById(bookId, id);
            if (review != null)
            {
                _reviews.Remove(review);
            }
        }
    }
}
