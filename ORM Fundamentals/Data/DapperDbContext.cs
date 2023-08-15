using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Fundamentals.Data
{
    public class DapperDbContext
    {
        private readonly IDbConnection _connection;

        public DapperDbContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public IDbConnection Connection => _connection;
    }
}
