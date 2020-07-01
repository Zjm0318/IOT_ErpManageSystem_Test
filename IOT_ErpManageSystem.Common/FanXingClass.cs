using IOT_ErpManageSystem.DAL.IDBHelp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json;

namespace IOT_ErpManageSystem.Common
{
    public class FanXingClass
    {
        private IDBHelper _dbhelp;
        public FanXingClass(IDBHelper dbhelp)
        {
            _dbhelp = dbhelp;
        }
        public List<T> GetDateList<T>(string tbName) where T:class
        {
            string procName = "proc_Select";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter{ParameterName="",DbType= DbType.String,Direction= ParameterDirection.Input,Value=tbName },
            };
            DataTable tb = _dbhelp.ExecuteProc(procName,sqlParameters);
            return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(tb));
        }
    }
}
