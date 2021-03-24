using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace zuowanhuijia
{
    class Dao
    {
        SqlConnection sc;
        public SqlConnection connect() { 
            string str = @"Data Source=LAPTOP-900ANCPN; Initial Catalog = lastwork; Integrated Security=true";//数据库连接字符串
            sc = new SqlConnection(str);//连接的对象
            sc.Open();
            return sc;
        }
        public SqlCommand command(string sql) {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql) {
            //更新操作
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql) {
            //读取操作
            return command(sql).ExecuteReader();
        }
        public void Daoclose() {
            sc.Close();//关闭数据库的连接
        }
    }

}
