using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inqasso.Core
{
    internal class SqlServerDbContext : DbContext
    {
        private string _connectionString;
        private readonly ILogger<SqlServerDbContext> _logger;

        internal SqlServerDbContext(ILogger<SqlServerDbContext> logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = logger;



            //var connectionBuilder = new SqlConnectionStringBuilder
            //{
            //    DataSource = DataSource
            //};

            //_connection = new SqlConnection(connectionBuilder.ConnectionString);
            //_connection.Open();
            //_logger?.LogDebug("")
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public virtual void AddTransaction()
        {
            //var sql = "SELECT memberName FROM dbo.members";
            //using (SqlCommand command = new SqlCommand(sql, _connection))
            //{
            //    using (SqlDataReader reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
            //        }
            //    }
            //}


        }


        

        public virtual void Dispose()
        {
            //_connection?.Dispose();
        }

        public virtual async ValueTask DisposeAsync()
        {
            //await _connection.DisposeAsync();
        }
    }
}