using Microsoft.EntityFrameworkCore;
namespace On.Infra
{
    public class OnContext: DbContext
    {
        public OnContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyAllConfigurations();
        }  
    }
}
