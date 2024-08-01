using BookReviewAPI.Models;
using BookReviewAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookReviewAPI.Controllers
{
    [ApiController]
    [Route("api/books/{bookId}/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetReviews(int bookId)
        {
            return Ok(_reviewService.GetReviewsByBookId(bookId));
        }

        [HttpGet("{id}")]
        public ActionResult<Review> GetReview(int bookId, int id)
        {
            var review = _reviewService.GetReviewById(bookId, id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPost]
        public ActionResult<Review> CreateReview(int bookId, Review review)
        {
            review.BookId = bookId;
            _reviewService.AddReview(review);
            return CreatedAtAction(nameof(GetReview), new { bookId = bookId, id = review.Id }, review);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReview(int bookId, int id, Review review)
        {
            if (id != review.Id || bookId != review.BookId)
            {
                return BadRequest();
            }

            _reviewService.UpdateReview(review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int bookId, int id)
        {
            _reviewService.DeleteReview(bookId, id);
            return NoContent();
        }
    }
}
