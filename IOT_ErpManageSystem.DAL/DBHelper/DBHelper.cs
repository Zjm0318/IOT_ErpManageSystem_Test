using IOT_ErpManageSystem.DAL.IDBHelp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IOT_ErpManageSystem.DAL.DBHelper
{
    public class DBHelper : IDBHelper
    {
        private string Connection = "Data Source=192.168.0.190;Initial Catalog=ERP;User ID=sa;pwd=1234";
        /// <summary>
        /// 登录存储过程
        /// <param name="procName"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public int LoginProc(string procName, SqlParameter[] sqlParameters)
        {
            int code = 0;
            using (SqlConnection con = new SqlConnection(Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(procName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameters);
                    cmd.ExecuteNonQuery();
                    code = int.Parse(cmd.Parameters["@LoginState"].Value.ToString());

                }
            }
            return code;
        }
        /// <summary>
        /// 执行存储过程，返回受影响行数
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public int ExecuteNonQueryProc(string procName, SqlParameter[] sqlParameters)
        {
            int code = 0;
            using (SqlConnection con = new SqlConnection(Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(procName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameters);
                    code = cmd.ExecuteNonQuery();
                }
            }
            return code;
        }
        /// <summary>
        /// 执行存储过程，返回结果集
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public DataTable ExecuteProc(string procName, SqlParameter[] sqlParameters)
        {
            DataTable tb = new DataTable();
            using (SqlConnection con = new SqlConnection(Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(procName, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (sqlParameters != null)
                    {
                        cmd.Parameters.AddRange(sqlParameters);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tb);
                }
            }
            return tb;
        }
        /// <summary>
        /// 分页存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="sqlParameters"></param>
        /// <param name="RowsCount"></param>
        /// <returns></returns>
        public DataTable ExecuteProc(string procName, SqlParameter[] sqlParameters, ref int rowCount)
        {
            DataTable tb = new DataTable();
            using (SqlConnection con = new SqlConnection(Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(procName, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tb);
                    rowCount = int.Parse(cmd.Parameters["@rowCount"].Value.ToString());
                }
            }
            return tb;
        }
        /// <summary>
        /// 执行存储过程的方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public DataTable Do_Proc(string name, SqlParameter[] paras)
        {
            //创建数据库连接对象，放在using里面是为了当这个链接对象用完之后，会自动销毁，并释放内存
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                SqlCommand cmd = conn.CreateCommand();//使用连接对象的CreateCommand()方法创建命令对象
                cmd.CommandType = CommandType.StoredProcedure;//指定要执行的是存储过程
                cmd.CommandText = name;//为命令对象指定要执行的存储过程的名称
                cmd.Parameters.AddRange(paras);//将参数数组添加到命令对象的参数列表中

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);//使用命令对象创建一个适配器对象
                sda.Fill(dt);

                return dt;
            }
        }
        /// <summary>
        /// 利用存储过程的执行方法，得到对应的List泛型集合数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public List<T> GetList<T>(string name, SqlParameter[] paras)
        {
            DataTable dt = Do_Proc(name, paras);
            var str = JsonConvert.SerializeObject(dt);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(str);
            return list;
        }
    }
}
