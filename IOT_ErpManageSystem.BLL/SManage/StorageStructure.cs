using IOT_ErpManageSystem.BLL.ISManage;
using IOT_ErpManageSystem.DAL.IDBHelp;
using IOT_ErpManageSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IOT_ErpManageSystem.BLL.SManage
{
    public class StorageStructure : IStorageStructure
    {
        private IDBHelper _helper;
        public StorageStructure(IDBHelper helper)
        {
            _helper = helper;
        }
        /// <summary>
        /// 添加区域
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddArea(tb_Area model)
        {
            string procName = "proc_AddArea";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter{ParameterName="@Area",DbType= DbType.String,Direction= ParameterDirection.Input,Value=model.Area },
                new SqlParameter{ParameterName="@StorageId",DbType= DbType.String,Direction= ParameterDirection.Input,Value=model.StorageId }
            };
            return _helper.ExecuteNonQueryProc(procName, sqlParameters);
        }
        /// <summary>
        /// 添加货架
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddShelf(tb_Shelf model)
        {
            string procName = "proc_AddShelf";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter{ParameterName="@shelfName",DbType= DbType.String,Direction= ParameterDirection.Input,Value=model.ShelfName },
                new SqlParameter{ParameterName="@AreaId",DbType= DbType.String,Direction= ParameterDirection.Input,Value= model.AreaId},
                new SqlParameter{ParameterName="@ShelfNo",DbType= DbType.String,Direction= ParameterDirection.Input,Value=model.ShelfNo },
                new SqlParameter{ParameterName="@StorageId",DbType= DbType.String,Direction= ParameterDirection.Input,Value=model.StorageId },
            };
            int code = _helper.ExecuteNonQueryProc(procName, sqlParameters);
            return code;
        }

        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <returns></returns>
        public List<tb_Area> GetAreaList(string tbName)
        {
            string procName = "proc_Select";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter{ ParameterName="@table",DbType= DbType.String,Direction= ParameterDirection.Input,Value=tbName },
            };
            DataTable tb = _helper.ExecuteProc(procName, sqlParameters);
            return JsonConvert.DeserializeObject<List<tb_Area>>(JsonConvert.SerializeObject(tb));
        }

        /// <summary>
        /// 仓库结构分页显示
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="RowCount"></param>
        /// <returns></returns>
        public List<tb_Storage> GetSotrageList(int pageIndex, int pageSize, ref int RowCount)
        {
            string procName = "prco_StorageStruct";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter{ParameterName="@pageIndex",DbType= DbType.Int32,Direction= ParameterDirection.Input,Value=pageIndex },
                new SqlParameter{ParameterName="@pageSize",DbType= DbType.Int32,Direction= ParameterDirection.Input,Value=pageSize },
                new SqlParameter{ParameterName="@rowCount",DbType= DbType.Int32,Direction= ParameterDirection.Output }
            };
            DataTable tb = _helper.ExecuteProc(procName, sqlParameters, ref RowCount);
            return JsonConvert.DeserializeObject<List<tb_Storage>>(JsonConvert.SerializeObject(tb));
        }
        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <returns></returns>
        public List<tb_Storage> GetStorList(string tbName)
        {
            string procName = "proc_Select";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter{ ParameterName="@table",DbType= DbType.String,Direction= ParameterDirection.Input,Value=tbName },
            };
            DataTable tb = _helper.ExecuteProc(procName, sqlParameters);
            return JsonConvert.DeserializeObject<List<tb_Storage>>(JsonConvert.SerializeObject(tb));
        }
        /// <summary>
        /// 获取货架数量
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public int GetShelfCount(string tbName)
        {
            string procName = "proc_Select";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter{ ParameterName="@table",DbType= DbType.String,Direction= ParameterDirection.Input,Value=tbName },
            };
            DataTable tb = _helper.ExecuteProc(procName, sqlParameters);
            return tb.Rows.Count;
        }
    }
}
