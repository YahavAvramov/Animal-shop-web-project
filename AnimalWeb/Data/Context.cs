using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace AnimalWeb.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}
