using BookApiProject.Dtos;
using BookApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private IReviewerRepository _reviewerRepository;
        private IReviewRepository _reviewRepository;
        public ReviewsController(IReviewerRepository reviewerRepository, IReviewRepository reviewRepository)
        {
            _reviewerRepository = reviewerRepository;
            _reviewRepository = reviewRepository;
        }
        //api/reviews
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviews()
        {
            var reviews = _reviewRepository.GetReviews();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewsDto = new List<ReviewDto>();
            foreach (var review in reviews)
            {
                reviewsDto.Add(new ReviewDto
                {
                   Id = review.Id,
                   Headline = review.Headline,
                   Rating = review.Rating,
                   ReviewText = review.ReviewText
                });
            }
            return Ok(reviewsDto);

        }
    }
}
