using Microsoft.EntityFrameworkCore;
using MultipleDatabases.DAL.Models;

namespace MultipleDatabases.DAL
{
    public class TestDbContext : DbContext
    {
        public DbSet<TestOne> TestOnes { get; set; }

        public TestDbContext(DbContextOptions options) : base(options) { }
    }
}
