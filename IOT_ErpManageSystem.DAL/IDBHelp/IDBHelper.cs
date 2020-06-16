﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IOT_ErpManageSystem.DAL.IDBHelp
{
    public interface IDBHelper
    {
        /// <summary>
        /// 执行存储过程 返回结果集
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public DataTable ExecuteProc(string procName, SqlParameter[] sqlParameters);
        /// <summary>
        /// 分页存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="sqlParameters"></param>
        /// <param name="RowsCount"></param>
        /// <returns></returns>
        public DataTable ExecuteProc(string procName, SqlParameter[] sqlParameters, ref int RowsCount);
        /// <summary>
        /// 存储过程返回受影响行数
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public int ExecuteNonQueryProc(string procName, SqlParameter[] sqlParameters);
    }
}
