﻿using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace BookReviewAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}