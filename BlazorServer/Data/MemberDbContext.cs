using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data
{
    public sealed class MemberDbContext : DbContext
    {
        public MemberDbContext(
            DbContextOptions<MemberDbContext> options
        ) : 
            base(
                options
            )
        {

        }

        public DbSet<Member>? Members { get; set; } = null;
    }
}