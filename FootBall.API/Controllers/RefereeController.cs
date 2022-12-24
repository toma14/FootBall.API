using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootBall.API.Controllers
{
    using FootBall.API.Context;
    using FootBall.API.Models;

    using Microsoft.EntityFrameworkCore;
    [Route("api/[controller]")]
    [ApiController]
    public class RefereeController : ControllerBase
    {
        private RefereeContext db;

        public RefereeController(RefereeContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Referee>>> GetAll()
        {
            return await this.db.Referee.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Referee>> GetById(int id)
        {
            Referee referee = await this.db.Referee.FirstOrDefaultAsync(x => x.Id == id);

            if (referee == null)
                return NotFound();

            return new ObjectResult(referee);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Referee>> Create(Referee referee)
        {
            if (referee == null)
                return this.BadRequest();

            db.Referee.Add(referee);

            await this.db.SaveChangesAsync();

            return Ok(referee);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<Referee>> Update(Referee referee)
        {
            if (referee == null)
                return this.BadRequest();

            if (!db.Referee.Any(x => x.Id == referee.Id))
                return this.NotFound();

            db.Referee.Update(referee);
            await db.SaveChangesAsync();

            return Ok(referee);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<Referee>> Delete(int id)
        {
            Referee referee = await this.db.Referee.FirstOrDefaultAsync(x => x.Id == id);

            if (id < 0)
                return NotFound();

            db.Referee.Remove(referee);
            await db.SaveChangesAsync();
            return Ok(referee);
        }
    }
}