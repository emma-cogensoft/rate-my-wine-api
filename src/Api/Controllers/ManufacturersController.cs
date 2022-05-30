using Application;
using Application.Manufacturers.Commands;
using Application.Manufacturers.Queries;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ManufacturersController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturers()
        {
            var manufacturers = await _mediatr.Send(new GetAllManufacturersQuery());
            return manufacturers.ToList();

        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturer(int id)
        {
            try
            {
                var manufacturer = await _mediatr.Send(_mapper.Map<GetManufacturerByIdQuery>(id));
                return manufacturer;
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Manufacturers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturer(int id, UpdateManufacturerCommand command)
        {
            await _mediatr.Send(command);
            return NoContent();
        }

        // POST: api/Manufacturers
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> PostManufacturer(CreateManufacturerCommand command)
        {
            var manufacturer = await _mediatr.Send(command);

            return CreatedAtAction("GetManufacturer", new { id = manufacturer.Id }, manufacturer);
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            try
            {
                await _mediatr.Send(_mapper.Map<DeleteManufacturerCommand>(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
