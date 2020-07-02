using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using IOT_ErpManageSystem.DAL;
using IOT_ErpManageSystem.DAL.IDBHelp;
using IOT_ErpManageSystem.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
namespace IOT_ErpManageSystem.BLL
{
   public class RBAC_RoleBll:RoleInterface
    {
        private IDBHelper _idbhelper;

          public RBAC_RoleBll(IDBHelper idbhelper)
        {
            _idbhelper = idbhelper;
        }
        //添加信息
        public int AddRole(RBAC_Role model)
        {
            string ProName = "pro_Role_Add";
            SqlParameter[] parametr = new SqlParameter[] {

                new SqlParameter{ParameterName="@RoleName",Value=model.Role_Name, DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@Role_Code",Value=model.Role_Account,DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@RoleSex",Value=model.RoleSex,DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@RoleTel",Value=model.Role_Tel,DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@Job_ID",Value=model.Job_ID,DbType= DbType.String,Direction= ParameterDirection.Input },

            };
             return  _idbhelper.ExecuteNonQueryProc(ProName,parametr);
       
        }
        //绑定部门
     
        public List<RBAC_Dep> GetDep()
        {
            string proName = "Pro_Dep";
            SqlParameter[] parametr = new SqlParameter[] { };
            return _idbhelper.GetList<RBAC_Dep>(proName,parametr);
        }
        
        public List<RBAC_Job> GetJob(string CodeId)
        {
            string proName = "Pro_Job";
            SqlParameter[] parametr = new SqlParameter[] {
          new SqlParameter{ParameterName="@JodId",DbType= DbType.String,Direction= ParameterDirection.Input,Value=CodeId },

            };
            return _idbhelper.GetList<RBAC_Job>(proName, parametr);
        }

        //绑定职位
        public List<RBAC_Job> GetAJob()
        {
            string proName = "Pro_Jobs";
            SqlParameter[] parametr = new SqlParameter[] { };
            return _idbhelper.GetList<RBAC_Job>(proName, parametr);
        }


        //显示员工管理
        public List<RBAC_Role> GetRole(int PageIndex, int PageSize, string Role_Account, string RoleName, string RoleJob, int RoleState, ref int RowsCount)
        {
            string proName = "prc_RBAC_Role";
            string wherestr = " where (1=1)";
            if(!string.IsNullOrEmpty(Role_Account))
            {
                wherestr += $" and b.Role_Account='{Role_Account}'";
            }
            if(!string.IsNullOrEmpty(RoleName))
            {
                wherestr += $" and b.Role_Name like '%{RoleName}%'";
            }
             if(!string.IsNullOrEmpty(RoleJob))
           {
                wherestr += $" and g.Job_ID='{RoleJob}'";
           }
            if(RoleState!=-1)
            {
                wherestr += $" and b.Role_State={RoleState}";
            }
               SqlParameter[] parametr = new SqlParameter[] {
                new SqlParameter{ParameterName="@wherestr",DbType= DbType.String,Direction= ParameterDirection.Input,Value=wherestr },
                new SqlParameter{ParameterName="@pageIndex",DbType= DbType.Int32,Direction= ParameterDirection.Input,Value=PageIndex },
                new SqlParameter{ParameterName="@PagieSize",DbType= DbType.Int32,Direction= ParameterDirection.Input,Value=PageSize },
                new SqlParameter{ParameterName="@Rowcount",DbType= DbType.Int32,Direction= ParameterDirection.Output },
              };

            DataTable tb = _idbhelper.ExecuteProc(proName, parametr,ref RowsCount);
            //转成字符串类型
           return  JsonConvert.DeserializeObject<List<RBAC_Role>>(JsonConvert.SerializeObject(tb)).ToList();
                 
        }
        //编辑
        public int UpdateRole(RBAC_Role model)
        {

            string ProName = "pro_Role_upda";
            SqlParameter[] parametr = new SqlParameter[] {

                new SqlParameter{ParameterName="@RoleName",Value=model.Role_Name, DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@Role_Code",Value=model.Role_Account,DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@RoleSex",Value=model.RoleSex,DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@RoleTel",Value=model.Role_Tel,DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@Job_ID",Value=model.Job_ID,DbType= DbType.String,Direction= ParameterDirection.Input },
                new SqlParameter{ParameterName="@RoleId",Value=model.ID,DbType= DbType.String,Direction= ParameterDirection.Input },
            };
            return _idbhelper.ExecuteNonQueryProc(ProName, parametr);
        }

        //反填数据
        public RBAC_Role role(string id)
        {
            string proName = "Role_Id";
            SqlParameter[] parametr = new SqlParameter[] {
          new SqlParameter{ParameterName="@roleid",DbType= DbType.String,Direction= ParameterDirection.Input,Value=id },

            };
            DataTable tb = _idbhelper.ExecuteProc(proName, parametr);
            return JsonConvert.DeserializeObject<List<RBAC_Role>>(JsonConvert.SerializeObject(tb)).FirstOrDefault();
        }
    }

}
