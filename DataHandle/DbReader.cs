using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace DataHandle
{
    public class DbReader
    {
        private static DbInfo _info;

        private IDbConnection _conn;

        public static DbReader Instance=> Create();

        public DbReader(IDbConnection conn){
            _conn = conn;
        }

        public static void Init(DbInfo info)
        {
            _info = info;
        }

        public static DbReader Create()
        {
            switch (_info.Type)
            {
                case DbType.MSSql:
                    return new DbReader(new SqlConnection(_info.ConString));
                case DbType.Mysql:
                    return new DbReader(new MySqlConnection(_info.ConString));
                default:
                    throw new ArgumentException("暂不支持该种数据库");
            }
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return _conn.Query<T>(sql);
        }

    }
}
