using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techshopadodata.DbConn
{
    public class DataConnector
    {
        private readonly string _connectionString;
        public DataConnector(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}
