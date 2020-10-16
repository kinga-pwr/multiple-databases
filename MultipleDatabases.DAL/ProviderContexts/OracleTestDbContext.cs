using Microsoft.EntityFrameworkCore;

namespace MultipleDatabases.DAL.ProviderContexts
{
    public class OracleTestDbContext : TestDbContext
    {
        public OracleTestDbContext(DbContextOptions<OracleTestDbContext> options) : base(options) { }
    }
}
