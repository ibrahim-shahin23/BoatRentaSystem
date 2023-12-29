using Microsoft.Extensions.Options;

namespace BoatRentalSystem.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(".//SQLExpress;Database = Boatsdb;Trustd_Connection = true;TrustedServerCertificate = true;");
        }
        public DbSet<Boat> Boats { get; set; }
    }
}
