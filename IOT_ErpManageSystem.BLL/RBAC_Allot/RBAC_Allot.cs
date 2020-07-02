using IOT_ErpManageSystem.BLL.InRBAC_Role;
using IOT_ErpManageSystem.DAL.DBHelper;
using IOT_ErpManageSystem.DAL.IDBHelp;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IOT_ErpManageSystem.BLL.RBAC_Allot
{
    public class RBAC_Allot : AllotInterface
    {
        DBHelper _idbhelper = new DBHelper();

        //添加权限分配
        public int AddAllot(RBAC_Allots model)
        {
            string ProName = "pro_Add_Allot";
            SqlParameter[] parametr = new SqlParameter[] {

                new SqlParameter{ParameterName="@Allot_Code",Value=model.Allot_Code, DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@Allot_Name",Value=model.Allot_Name,DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@Allot_Grade",Value=model.Allot_Grade,DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@Allot_BaoId",Value=model.Allot_BaoId,DbType= DbType.String,Direction= ParameterDirection.Input },
            };
            return _idbhelper.ExecuteNonQueryProc(ProName, parametr);
        }

        //权限的显示
        public List<RBAC_Allots> GetAllot(int PageIndex, int PageSize, string DepName, ref int RowsCount)
        {
            string proName = "prc_RBAC_Allot";
            string wherestr = " where (1=1)";
            if (!string.IsNullOrEmpty(DepName))
            {
                wherestr += $" and d.Dep_Name='{DepName}'";
            }
            SqlParameter[] parametr = new SqlParameter[] {
                new SqlParameter{ParameterName="@wherestr",DbType= DbType.String,Direction= ParameterDirection.Input,Value=wherestr },
                new SqlParameter{ParameterName="@pageIndex",DbType= DbType.Int32,Direction= ParameterDirection.Input,Value=PageIndex },
                new SqlParameter{ParameterName="@PagieSize",DbType= DbType.Int32,Direction= ParameterDirection.Input,Value=PageSize },
                new SqlParameter{ParameterName="@Rowcount",DbType= DbType.Int32,Direction= ParameterDirection.Output },
              };

            DataTable tb = _idbhelper.ExecuteProc(proName, parametr, ref RowsCount);
            //转成字符串类型
            return JsonConvert.DeserializeObject<List<RBAC_Allots>>(JsonConvert.SerializeObject(tb)).ToList();
        }

        //权限绑定
        public List<RBAC_Quan> GetAllots(string Uid)
        {
            string proName = "Pro_Allot";
            SqlParameter[] parametr = new SqlParameter[] {
          new SqlParameter{ParameterName="@JodId",DbType= DbType.String,Direction= ParameterDirection.Input,Value=Uid },

            };
            return _idbhelper.GetList<RBAC_Quan>(proName, parametr);
        }
        //绑定部门下拉框
        public List<RBAC_Dep> GetDep()
        {       
                string proName = "proc_Dep";
                SqlParameter[] parametr = new SqlParameter[] { };
                return _idbhelper.GetList<RBAC_Dep>(proName, parametr);

        }

        //反填查询数据
        public RBAC_Allots Quan(string id)
        {
            string proName = "Quan_Id";
            SqlParameter[] parametr = new SqlParameter[] {
          new SqlParameter{ParameterName="@Quanid",DbType= DbType.String,Direction= ParameterDirection.Input,Value=id },

            };
            DataTable tb = _idbhelper.ExecuteProc(proName, parametr);
            return JsonConvert.DeserializeObject<List<RBAC_Allots>>(JsonConvert.SerializeObject(tb)).FirstOrDefault();
        }

        //获取所有菜单信息
        public List<RBAC_Quan> ShowQuanInfo()
        {
            string procName = "SelectQuan";
            DataTable tb = _idbhelper.ExecuteProc(procName, null);
            return JsonConvert.DeserializeObject<List<RBAC_Quan>>(JsonConvert.SerializeObject(tb)).ToList();
        }

        //编辑权限
        public int UpdaAllot(RBAC_Allots model)
        {

            string ProName = "pro_Quan_upda";
            SqlParameter[] parametr = new SqlParameter[] {

                new SqlParameter{ParameterName="@Allot_Code ",Value=model.Allot_Code, DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@Allot_Name",Value=model.Allot_Name,DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@Allot_Grade",Value=model.Allot_Grade,DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@Allot_BaoId",Value=model.Allot_BaoId,DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@Qid",Value=model.ID,DbType= DbType.String,Direction= ParameterDirection.Input },
      
            };
            return _idbhelper.ExecuteNonQueryProc(ProName, parametr);
        }

        //用户权限
        //public RBAC_Allots UserQuanInfo(Guid UId)
        //{
        //    string procName = "UserQuan";
        //    SqlParameter[] param = new SqlParameter[]
        //    {
        //        new SqlParameter{ ParameterName="@UId", DbType= DbType.Guid, Direction= ParameterDirection.Input,Value=UId }
        //    };
        //    DataTable tb = _idbhelper.ExecuteProc(procName, param);
        //    return JsonConvert.DeserializeObject<List<RBAC_Allots>>(JsonConvert.SerializeObject(tb)).FirstOrDefault();
        //}
    }
}
