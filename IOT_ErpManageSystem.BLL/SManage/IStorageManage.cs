using IOT_ErpManageSystem.BLL.ISManage;
using IOT_ErpManageSystem.DAL.IDBHelp;
using IOT_ErpManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Newtonsoft.Json;

namespace IOT_ErpManageSystem.BLL.SManage
{
    public class IStorageManage : IIStorageManage
    {
        private IDBHelper _dbhelp;
        public IStorageManage(IDBHelper dbhelp)
        {
            _dbhelp = dbhelp;
        }
        /// <summary>
        /// 获取入库信息
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="state">入库状态</param>
        /// <param name="cTime">创建时间</param>
        /// <param name="sName">供应商名称</param>
        /// <param name="bName">采购员名称</param>
        /// <returns></returns>
        public List<tb_InStorage> GetInStorageList(int pageIndex,int pageSize,int state,string cTime,string sName,ref int rowCount)
        {
            string procName = "proc_ISManage";
            string where = " where (1=1) ";
            if(state!=0)
            {
                where += $" and InStorageState={state}";
            }
            if(!string.IsNullOrEmpty(cTime))
            {
                where += $" and InStorageTime like '%{cTime}%'";
            }
            if(!string.IsNullOrEmpty(sName))
            {
                where += $" and DwName like '%{sName}%'";
            }
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter{ParameterName="@pageIndex",DbType= DbType.Int32,Direction= ParameterDirection.Input,Value=pageIndex},
                new SqlParameter{ParameterName="@pageSize",DbType= DbType.Int32,Direction= ParameterDirection.Input,Value=pageSize},
                new SqlParameter{ParameterName="@whereStr",DbType= DbType.String,Direction= ParameterDirection.Input,Value=where},
                new SqlParameter{ParameterName="@RowCount",DbType= DbType.Int32,Direction= ParameterDirection.Output},
            };
            DataTable tb = _dbhelp.ExecuteProc(procName, sqlParameters, ref rowCount);
            return JsonConvert.DeserializeObject<List<tb_InStorage>>(JsonConvert.SerializeObject(tb));
        }

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <returns></returns>
        public List<RBAC_Role> GetRoleList()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 修改入库状态
        /// </summary>
        /// <param name="isId"></param>
        /// <param name="isState"></param>
        /// <returns></returns>
        public int UpdateIStorageState(string isId)
        {
            string procName = "proc_UpdateState";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter{ParameterName="@isId", DbType= DbType.String,Direction= ParameterDirection.Input,Value=isId},
            };
            return _dbhelp.ExecuteNonQueryProc(procName,parameters);
        }   
        /// <summary>
        /// 修改收货员
        /// </summary>
        /// <returns></returns>
        public int UpdateIStorageSup()
        {
            throw new NotImplementedException();
        }
    }
}
