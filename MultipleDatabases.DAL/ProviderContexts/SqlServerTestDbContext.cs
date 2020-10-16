using Microsoft.EntityFrameworkCore;

namespace MultipleDatabases.DAL.ProviderContexts
{
    public class SqlServerTestDbContext : TestDbContext
    {
        public SqlServerTestDbContext(DbContextOptions<SqlServerTestDbContext> options) : base(options) { }
    }
}
