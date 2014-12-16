using DecPlayground.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DecPlayground.DAL
{
    public class DecPlaygroundContext : DbContext
    {

        public DecPlaygroundContext()
            : base("DecPlaygroundContext")
        {
        }

        public DbSet<VoteResult> VoteResults { get; set; }
        public DbSet<Task> Tasks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}