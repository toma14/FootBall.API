using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootBall.API.Controllers
{
    using FootBall.API.Context;
    using FootBall.API.Models;

    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext db;

        public UserController(UserContext context)
        {
            db = context;

            if (!this.db.User.Any())
            {
                this.db.User.Add(new User() { Id = 1, FirstName = "Giorgi", Age = 16, LastName = "Test" });
                this.db.User.Add(new User() { Id = 2, FirstName = "Mako", Age = 12, LastName = "TestTwo" });
                this.db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await this.db.User.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            User user = await this.db.User.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            if (user == null)
                return this.BadRequest();

            db.User.Add(user);

            await this.db.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update (User user)
        {
            if (user == null)
                return this.BadRequest();

            if (!db.User.Any(x => x.Id == user.Id))
                return this.NotFound();

            db.User.Update(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = await this.db.User.FirstOrDefaultAsync(x => x.Id == id);
             
            if (id < 0)
                return NotFound();

            db.User.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
