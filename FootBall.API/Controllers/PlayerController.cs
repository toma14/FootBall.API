using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootBall.API.Controllers
{
    using FootBall.API.Context;
    using FootBall.API.Models;

    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private PlayerContext db;

        public PlayerController(PlayerContext db) { this.db = db; }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetById(int id)
        {
            Player Player = await this.db.Player.FirstOrDefaultAsync(x => x.Id == id);

            if (Player == null)
                return NotFound();

            return new ObjectResult(Player);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> Create(Player Player)
        {
            if (Player == null)
                return this.BadRequest();

            db.Player.Add(Player);

            await this.db.SaveChangesAsync();

            return Ok(Player);
        }

        [HttpPut]
        public async Task<ActionResult<Player>> Update(Player Player)
        {
            if (Player == null)
                return this.BadRequest();

            if (!db.Player.Any(x => x.Id == Player.Id))
                return this.NotFound();

            db.Player.Update(Player);
            await db.SaveChangesAsync();

            return Ok(Player);
        }

        [HttpDelete]
        public async Task<ActionResult<Player>> Delete(int id)
        {
            Player Player = await this.db.Player.FirstOrDefaultAsync(x => x.Id == id);

            if (id < 0)
                return NotFound();

            db.Player.Remove(Player);
            await db.SaveChangesAsync();
            return Ok(Player);

        }

    }
}
