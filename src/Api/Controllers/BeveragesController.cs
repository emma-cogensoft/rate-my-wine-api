using Api.Requests;
using Application;
using Application.Beverages.Commands;
using Application.Beverages.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeveragesController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;

        public BeveragesController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        // GET: api/Beverages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beverage>>> GetBeverages()
        {
            var beverages = await _mediatr.Send(new GetAllBeveragesQuery());
            return beverages.ToList();
        }

        // GET: api/Beverages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beverage>> GetBeverage(int id)
        {
            try
            {
                var beverage = await _mediatr.Send(_mapper.Map<GetBeverageByIdQuery>(id));
                return beverage;
            }
            catch(EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Beverages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeverage(int id, UpdateBeverageRequest request)
        {
            await _mediatr.Send(_mapper.Map<CreateBeverageCommand>(request));
            return NoContent();
        }

        // POST: api/Beverages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beverage>> PostBeverage(CreateBeverageRequest request)
        {
            var beverage = await _mediatr.Send(_mapper.Map<CreateBeverageCommand>(request));

            return CreatedAtAction("GetBeverage", new { id = beverage.Id }, beverage);
        }

        // DELETE: api/Beverages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeverage(int id)
        {
            try
            {
                await _mediatr.Send(_mapper.Map<DeleteBeverageCommand>(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
