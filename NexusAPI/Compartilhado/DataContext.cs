using Microsoft.EntityFrameworkCore;

namespace NexusAPI.Compartilhado
{
    public class DataContext : DbContext
    {


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
