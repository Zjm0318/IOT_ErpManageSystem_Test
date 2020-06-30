using IOT_ErpManageSystem.BLL.ISManage;
using IOT_ErpManageSystem.DAL.IDBHelp;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json;

namespace IOT_ErpManageSystem.BLL.SManage
{
    public class OStorageManage : IOStorageManage
    {
        private IDBHelper _helper;
        public OStorageManage(IDBHelper helper)
        {
            _helper = helper;
        }
        /// <summary>
        /// 获取出库信息
        /// </summary>
        /// <param name="dId"></param>
        /// <param name="oTime"></param>
        /// <param name="oStorageId"></param>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public List<tb_OutStorage> GetOSMShowList(int pageIndex,int pageSize,string dId, string oTime, string oStorageId, string orderNo,ref int RowCount)
        {
            string procName = "proc_OSManage";
            string where = " where (1=1) ";
           if(!string.IsNullOrEmpty(dId))
            {
                where += $" and d.id='{dId}'";
            }
            if (!string.IsNullOrEmpty(oTime))
            {
                where += $" and o.outtime like '%{oTime}%'";
            }
            if (!string.IsNullOrEmpty(oStorageId))
            {
                where += $" and s.id ='{oStorageId}'";
            }
            if (!string.IsNullOrEmpty(orderNo))
            {
                where += $" and o.OrderNo like '%{orderNo}%'";
            }
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter{ParameterName="@pageIndex",DbType= DbType.Int32,Direction= ParameterDirection.Input,Value=pageIndex},
                new SqlParameter{ParameterName="@pageSize",DbType= DbType.Int32,Direction= ParameterDirection.Input,Value=pageSize},
                new SqlParameter{ParameterName="@whereStr",DbType= DbType.String,Direction= ParameterDirection.Input,Value=where},
                new SqlParameter{ParameterName="@RowCount",DbType= DbType.Int32,Direction= ParameterDirection.Output},
            };
            DataTable tb = _helper.ExecuteProc(procName, sqlParameters, ref RowCount);
            return JsonConvert.DeserializeObject<List<tb_OutStorage>>(JsonConvert.SerializeObject(tb));
        }

        /// <summary>
        /// 获取配送方式
        /// </summary>
        /// <returns></returns>
        public List<tb_DisPatching> GetTb_DisList(string tbName)
        {
            string procName = "proc_Select";
            SqlParameter[] sqlParameters = new SqlParameter[] { 
                new SqlParameter{ParameterName="@table",DbType= DbType.String,Direction= ParameterDirection.Input,Value=tbName}
            };
            DataTable tb = _helper.ExecuteProc(procName, sqlParameters);
            return JsonConvert.DeserializeObject<List<tb_DisPatching>>(JsonConvert.SerializeObject(tb));
        }

        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <returns></returns>
        public List<tb_Storage> GetTb_StoragesList(string tbName)
        {
            string procName = "proc_Select";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter{ParameterName="@table",DbType= DbType.String,Direction= ParameterDirection.Input,Value=tbName}
            };
            DataTable tb = _helper.ExecuteProc(procName, sqlParameters);
            return JsonConvert.DeserializeObject<List<tb_Storage>>(JsonConvert.SerializeObject(tb));
        }
        /// <summary>
        /// 修改出库状态
        /// </summary>
        /// <param name="oId">出库表Id</param>
        /// <returns></returns>
        public int UpdateState(string oId)
        {
            string procName = "proc_UpdateOutState";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter{ParameterName="@outId",DbType= DbType.String,Direction= ParameterDirection.Input,Value=oId },
            };
            return _helper.ExecuteNonQueryProc(procName, sqlParameters);
        }

        public int AddOutStorage(tb_OutStorage model)
        {
            string procName = "proc_AddOutStorage";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter{ParameterName="@OutTime",DbType= DbType.Date,Direction= ParameterDirection.Input,Value= model.OutTime},
                new SqlParameter{ParameterName="@OrderNo",DbType= DbType.String,Direction= ParameterDirection.Input,Value= model.OrderNo},
                new SqlParameter{ParameterName="@OStorageNo",DbType= DbType.String,Direction= ParameterDirection.Input,Value=model.OStorageNo },
                new SqlParameter{ParameterName="@DispatchingId",DbType= DbType.String,Direction= ParameterDirection.Input,Value=model.DispatchingId },
                new SqlParameter{ParameterName="@Consignee",DbType= DbType.String,Direction= ParameterDirection.Input,Value= model.Consignee},
                new SqlParameter{ParameterName="@CPhoneNum",DbType= DbType.String,Direction= ParameterDirection.Input,Value= model.CPhoneNum},
                new SqlParameter{ParameterName="@DispatchingArea",DbType= DbType.String,Direction= ParameterDirection.Input,Value= model.DispatchingArea},
                new SqlParameter{ParameterName="@OutStorageId",DbType= DbType.String,Direction= ParameterDirection.Input,Value= model.OutStorageId},
                new SqlParameter{ParameterName="@DBMan",DbType= DbType.String,Direction= ParameterDirection.Input,Value= model.DBMan},
                new SqlParameter{ParameterName="@OutState",DbType= DbType.Int32,Direction= ParameterDirection.Input,Value= model.OutState},
            };
            return _helper.ExecuteNonQueryProc(procName,sqlParameters);
        }
    }
}
