namespace FootBall.API.Context
{
    using FootBall.API.Models;
    using Microsoft.EntityFrameworkCore;

    public sealed class PlayerContext : DbContext
    {
        public DbSet<Player> Player { get; set; }

        public PlayerContext(DbContextOptions<PlayerContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
