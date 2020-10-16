using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultipleDatabases.DAL;
using MultipleDatabases.DAL.ProviderContexts;
using System;
using System.IO;

namespace DbMigrator
{
    public class Program
    {
        private static IConfigurationRoot _configuration;
        public static void Main()
        {
            LoadConfiguration();

            var inputDbProvider = _configuration.GetValue<string>("InputDatabaseProvider");
            var outputDbProvider = _configuration.GetValue<string>("OutputDatabaseProvider");

            while (true)
            {
                Console.Write($"Do you confirm migrating data from \"{inputDbProvider}\" to \"{outputDbProvider}\"? [y/N]: ");
                var response = Console.ReadLine();
                if (response.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Migrating...");
                    MigrateData(inputDbProvider, outputDbProvider);
                    Console.WriteLine("Migration finished");
                    break;
                }
                if (response.Equals("n", StringComparison.OrdinalIgnoreCase) || string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Migration cancelled");
                    break;
                }
            }
            Console.ReadKey();
        }

        private static void LoadConfiguration()
        {
            _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .Build();
        }

        private static TestDbContext GetDbContext(string provider)
        {
            switch (provider)
            {
                case "SqlServer":
                    var connectionStringSqlServer = _configuration.GetValue<string>("ConnectionStrings:TestDatabaseSqlServer");
                    var optionsBuilderSqlServer = new DbContextOptionsBuilder<SqlServerTestDbContext>().UseSqlServer(connectionStringSqlServer);
                    return new SqlServerTestDbContext(optionsBuilderSqlServer.Options);
                case "Oracle":
                    var connectionStringOracle = _configuration.GetValue<string>("ConnectionStrings:TestDatabaseOracle");
                    var optionsBuilderOracle = new DbContextOptionsBuilder<OracleTestDbContext>().UseOracle(connectionStringOracle);
                    return new OracleTestDbContext(optionsBuilderOracle.Options);
                default:
                    throw new Exception("No valid database provider! Available options: SqlServer, Oracle.");
            }
        }

        private static void MigrateData(string inputDbProvider, string outputDbProvider)
        {
            var inputDbContext = GetDbContext(inputDbProvider);
            var outputDbContext = GetDbContext(outputDbProvider);

            outputDbContext.TestOnes.AddRange(inputDbContext.TestOnes.Include(t => t.Elems));
            outputDbContext.SaveChanges();
        }
    }
}
