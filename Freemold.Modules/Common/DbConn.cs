using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace Freemold.Modules.Common
{
    public class DbConn : IDisposable
    {
        public readonly string connectionString;
        private SqlConnection connection;
        private TransactionScope transactionScope;

        public DbConn(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Dispose()
        {
            transactionScope?.Dispose();
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection?.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            return connection;
        }
    }
}
