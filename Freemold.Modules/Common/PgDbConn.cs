using Npgsql;
using System.Data;

namespace Freemold.Modules.Common
{
    public class PgDbConn
    {
        private readonly string _cs;
        public PgDbConn(string cs) => _cs = cs;

        public NpgsqlConnection Open()
        {
            var conn = new NpgsqlConnection(_cs);
            conn.Open();
            return conn;
        }
    }
}
