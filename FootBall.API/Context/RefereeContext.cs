namespace FootBall.API.Context
{
    using FootBall.API.Models;
    using Microsoft.EntityFrameworkCore;

    public sealed class RefereeContext : DbContext
    {
        public DbSet<Referee> Referee { get; set; }

        public RefereeContext(DbContextOptions<RefereeContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
