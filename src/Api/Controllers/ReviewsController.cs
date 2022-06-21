using Application;
using Application.Reviews.Commands;
using Application.Reviews.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;

        public ReviewsController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            var reviews = await _mediatr.Send(new GetReviewsListQuery());
            return reviews.ToList();

        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            try
            {
                var review = await _mediatr.Send(_mapper.Map<GetReviewByIdQuery>(id));
                return review;
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, UpdateReviewCommand command)
        {
            await _mediatr.Send(_mapper.Map<CreateReviewCommand>(command));
            return NoContent();
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(CreateReviewCommand command)
        {
            var review = await _mediatr.Send(_mapper.Map<CreateReviewCommand>(command));

            return CreatedAtAction("GetReview", new { id = review.Id }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                await _mediatr.Send(_mapper.Map<DeleteReviewCommand>(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
