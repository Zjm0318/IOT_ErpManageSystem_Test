using IOT_ErpManageSystem.DAL.IDBHelp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IOT_ErpManageSystem.DAL.DBHelper
{
    public class DBHelper : IDBHelper
    {
        private string Connection = "Data Source=192.168.0.190;Initial Catalog=ERP;User ID=sa;pwd=1234";
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
                    if (sqlParameters!=null)
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
    }
}
