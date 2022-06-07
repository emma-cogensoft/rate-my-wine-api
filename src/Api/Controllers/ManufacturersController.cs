using Application;
using Application.Manufacturers.Commands.Create;
using Application.Manufacturers.Commands.Delete;
using Application.Manufacturers.Commands.Update;
using Application.Manufacturers.Queries.GetById;
using Application.Manufacturers.Queries.GetList;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ManufacturersController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ManufacturersController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturers()
        {
            var manufacturers = await _mediatr.Send(new GetListManufacturersQuery());
            return manufacturers.ToList();

        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturer(int id)
        {
            try
            {
                var manufacturer = await _mediatr.Send(new GetManufacturerByIdQuery(id));
                return manufacturer;
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Manufacturers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManufacturer(int id, UpdateManufacturerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            
            await _mediatr.Send(command);
            return NoContent();
        }

        // POST: api/Manufacturers
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> AddManufacturer(CreateManufacturerCommand command)
        {
            var manufacturerId = await _mediatr.Send(command);
            return CreatedAtAction("GetManufacturer", new { id = manufacturerId });
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            try
            {
                await _mediatr.Send(new DeleteManufacturerCommand(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
