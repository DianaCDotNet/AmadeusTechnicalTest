using AmadeusWebAPI.Data;
using AmadeusWebAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AmadeusWebAPI.Controllers
{
    [ApiController]
    [Route("Airlines")]
    public class AirlinesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AirlinesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Airline>> Get()
        {
           return await context.Airlines.ToListAsync();
        }

        [HttpGet("{id:int}", Name = "GetAirline")]
        [AllowAnonymous]
        public async Task<ActionResult<Airline>> Get(int id)
        {
            var airline = await context.Airlines
                 .FirstOrDefaultAsync(x => x.Id == id);
            if (airline == null)
            {
                return NotFound();
            }
            return airline;
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post(Airline airline)
        {

            context.Add(airline);
            await context.SaveChangesAsync();
            return CreatedAtRoute("GetAirline", new { id = airline.Id }, airline);
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<ActionResult> Put(int id, Airline airline)
        {
            if (id != airline.Id)
            {
                return BadRequest("Error in Id");
            }

            context.Update(airline);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id:int}")]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedrRecords = await context.Airlines.FindAsync(id);
            if (deletedrRecords == null)
            {
                return NotFound();
            }

            context.Airlines.Remove(deletedrRecords);
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
