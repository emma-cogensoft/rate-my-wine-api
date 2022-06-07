using Application;
using Application.Beverages.Commands.Create;
using Application.Beverages.Commands.Delete;
using Application.Beverages.Commands.Update;
using Application.Beverages.Queries.GetById;
using Application.Beverages.Queries.GetList;
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

        public BeveragesController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        // GET: api/Beverages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beverage>>> GetBeverages()
        {
            var beverages = await _mediatr.Send(new GetListBeveragesQuery());
            return beverages.ToList();
        }

        // GET: api/Beverages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeverageDetailVm>> GetBeverage(int id)
        {
            try
            {
                var beverage = await _mediatr.Send(new GetBeverageByIdQuery(id));
                return beverage;
            }
            catch(EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Beverages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeverage(int id, UpdateBeverageCommand command)
        {
            await _mediatr.Send(command);
            return NoContent();
        }

        // POST: api/Beverages
        [HttpPost]
        public async Task<ActionResult<Beverage>> PostBeverage(CreateBeverageCommand command)
        {
            var beverageId = await _mediatr.Send(command);

            return CreatedAtAction("GetBeverage", new { id = beverageId });
        }

        // DELETE: api/Beverages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeverage(int id)
        {
            try
            {
                await _mediatr.Send(new DeleteBeverageCommand(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
