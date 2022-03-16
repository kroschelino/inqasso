using inqasso.core.Interfaces;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Inqasso.Core
{
    public class SqlServerDatabase : IDatabase, IDisposable
    {
        //private SqlConnection _connection;

        private const string DatabaseName = "inqasso";
        private const string DataSource = "";
        private readonly ILogger<SqlServerDbContext> _logger;

        public SqlServerDbContext(ILogger<SqlServerDbContext> logger = null)
        {
            _logger = logger;

            //var connectionBuilder = new SqlConnectionStringBuilder
            //{
            //    DataSource = DataSource
            //};

            //_connection = new SqlConnection(connectionBuilder.ConnectionString);
            //_connection.Open();
            //_logger?.LogDebug("")
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