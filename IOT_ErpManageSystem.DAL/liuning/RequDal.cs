using IOT_ErpManageSystem.DAL.IDBHelp;
using IOT_ErpManageSystem.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IOT_ErpManageSystem.DAL.liuning
{
    public class RequDal : IRequDal
    {
        //依赖注入 dbhelp层
        private IDBHelper _dBHelper;
        public RequDal(IDBHelper dBHelper)
        {
            _dBHelper = dBHelper;
        }

        #region  预购单模块

        #region 预购单显示
        public List<RequisitionOrder> GetRequList(string state, string time, string qgren, string shren, int pageindex, int pagesize, ref int rowcount)
        {
            SqlParameter[] param = new SqlParameter[] {
                 new SqlParameter{ParameterName="@state",SqlDbType=SqlDbType.VarChar,Value=state,Direction=ParameterDirection.Input },
                 new SqlParameter{ParameterName="@createtime",SqlDbType=SqlDbType.DateTime,Value=time,Direction=ParameterDirection.Input },
                 new SqlParameter{ParameterName="@qgren",SqlDbType=SqlDbType.VarChar,Value=qgren,Direction=ParameterDirection.Input },
                 new SqlParameter{ParameterName="@shren",SqlDbType=SqlDbType.VarChar,Value=shren,Direction=ParameterDirection.Input },
                 new SqlParameter{ParameterName="@pageindex",SqlDbType=SqlDbType.Int,Value=pageindex,Direction=ParameterDirection.Input },
                 new SqlParameter{ParameterName="@pagesize",SqlDbType=SqlDbType.Int,Value=pagesize,Direction=ParameterDirection.Input },
                 new SqlParameter{ParameterName="@rowCount",SqlDbType=SqlDbType.Int,Direction=ParameterDirection.Output },
            };
            DataTable tb = _dBHelper.ExecuteProc("RequProc", param, ref rowcount);
            string json = JsonConvert.SerializeObject(tb);
            List<RequisitionOrder> list = JsonConvert.DeserializeObject<List<RequisitionOrder>>(json);
            return list;
        }
        #endregion

        #region 获取员工表的信息
        public List<RoleModel> GetRoleList(string rolename, string rolecode)
        {
            SqlParameter[] param = new SqlParameter[] {
                 new SqlParameter{ ParameterName="@RoleName",SqlDbType=SqlDbType.VarChar,Value=rolename,Direction=ParameterDirection.Input},
                 new SqlParameter{ ParameterName="@RoleCode",SqlDbType=SqlDbType.VarChar,Value=rolecode,Direction=ParameterDirection.Input},
            };
            DataTable tb = _dBHelper.ExecuteProc("RoleProc", param);
            string json = JsonConvert.SerializeObject(tb);
            List<RoleModel> list = JsonConvert.DeserializeObject<List<RoleModel>>(json);
            return list;
        }
        #endregion

        #region 修改状态
        //审核通过
        public int UpdRequState(string Id)
        {
            SqlParameter[] param = new SqlParameter[] {
                 new SqlParameter{ParameterName="@Id",SqlDbType=SqlDbType.VarChar,Value=Id,Direction=ParameterDirection.Input }
            };
            return _dBHelper.ExecuteNonQueryProc("UpdState", param);
        }

        // 审核未通过
        public int UpdRequState2(string Id)
        {
            SqlParameter[] param = new SqlParameter[] {
                 new SqlParameter{ParameterName="@Id",SqlDbType=SqlDbType.VarChar,Value=Id,Direction=ParameterDirection.Input }
            };
            return _dBHelper.ExecuteNonQueryProc("UpdState2", param);
        }
        #endregion

        #region 指派请购员工
        public int UpdRole(string RId, string QgId)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@RId",SqlDbType=SqlDbType.VarChar,Value=RId,Direction=ParameterDirection.Input },
                new SqlParameter{ParameterName="@QgId",SqlDbType=SqlDbType.VarChar,Value=QgId,Direction=ParameterDirection.Input },
            };

            return _dBHelper.ExecuteNonQueryProc("ZhiPaiProc", param);
        }
        #endregion

        #region 撤回请购员工
        public int DelRole(string QgId)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@QgId",SqlDbType=SqlDbType.VarChar,Value=QgId,Direction=ParameterDirection.Input }
        };
            return _dBHelper.ExecuteNonQueryProc("CheHuiProc", param);
        }
        #endregion

        #region 根据ID反填预购单的信息
        public List<RequisitionInfo> FanTRequ(string QId)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@QId",SqlDbType=SqlDbType.VarChar,Value=QId,Direction=ParameterDirection.Input }
        };
            DataTable tb = _dBHelper.ExecuteProc("FanTRequ", param);
            string json = JsonConvert.SerializeObject(tb);
            List<RequisitionInfo> list = JsonConvert.DeserializeObject<List<RequisitionInfo>>(json);
            return list;
        }
        #endregion

        #region 添加请购单信息
        public int AddRequ(RequisitionInfo m)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ ParameterName="@CreateDate",SqlDbType=SqlDbType.DateTime,Value=m.CreateDate,Direction=ParameterDirection.Input},
                new SqlParameter{ ParameterName="@DhAddress",SqlDbType=SqlDbType.VarChar,Value=m.DhAddress,Direction=ParameterDirection.Input},
                new SqlParameter{ ParameterName="@QgName",SqlDbType=SqlDbType.VarChar,Value=m.QgName,Direction=ParameterDirection.Input},
                new SqlParameter{ ParameterName="@DeptName",SqlDbType=SqlDbType.VarChar,Value=m.DeptName,Direction=ParameterDirection.Input},
            };
            return _dBHelper.ExecuteNonQueryProc("AddRequ", param);
        }
        #endregion

        #region 查询商品信息
          public List<RequGoods> SelectGoods()
        {
            DataTable tb = _dBHelper.ExecuteProc("SelectGoods", null);
            string json = JsonConvert.SerializeObject(tb);
            List<RequGoods> list = JsonConvert.DeserializeObject<List<RequGoods>>(json);
            return list;
        }
        #endregion

        #region 显示请购单商品信息
        public List<RequGoods> GetRequGoods(string Id)
        {
            SqlParameter[] param = new SqlParameter[] {
                 new SqlParameter{ParameterName="@QgId",SqlDbType=SqlDbType.VarChar,Value=Id,Direction=ParameterDirection.Input  }
            };
            DataTable tb = _dBHelper.ExecuteProc("RequGoods", param);
            string json = JsonConvert.SerializeObject(tb);
            List<RequGoods> list = JsonConvert.DeserializeObject<List<RequGoods>>(json);
            return list;
        }
        #endregion

        #region 修改请购单信息
        public int UpdateRequ(RequisitionInfo m)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@DhAddress",SqlDbType=SqlDbType.VarChar,Value=m.DhAddress,Direction=ParameterDirection.Input },
                new SqlParameter{ParameterName="@QgName",SqlDbType=SqlDbType.VarChar,Value=m.QgName,Direction=ParameterDirection.Input },
                new SqlParameter{ParameterName="@DeptName",SqlDbType=SqlDbType.VarChar,Value=m.DeptName,Direction=ParameterDirection.Input },
                new SqlParameter{ParameterName="@QId",SqlDbType=SqlDbType.UniqueIdentifier,Value=m.QId,Direction=ParameterDirection.Input },
                new SqlParameter{ParameterName="@QGId",SqlDbType=SqlDbType.UniqueIdentifier,Value=m.QgId,Direction=ParameterDirection.Input }
            };
            return _dBHelper.ExecuteNonQueryProc("UpdRequInfo", param);
        }
        #endregion

        #region 查询员工名称 查询部门名称
          public List<RBAC_Role> SelectRole()
        {
            DataTable tb = _dBHelper.ExecuteProc("SelectRole", null);
            string json = JsonConvert.SerializeObject(tb);
            List<RBAC_Role> list = JsonConvert.DeserializeObject<List<RBAC_Role>>(json);
            return list;
        }

        public List<RBAC_Dep> SelectDep()
        {
            DataTable tb = _dBHelper.ExecuteProc("SelectDep", null);
            string json = JsonConvert.SerializeObject(tb);
            List<RBAC_Dep> list = JsonConvert.DeserializeObject<List<RBAC_Dep>>(json);
            return list;
        }
        #endregion

        #endregion

        #region  添加请购单,采购单与商品的中间表数据2
        public int AddRequGood(string GId,int Num)
        {
            //获取数据
            string[] ids = GId.Split(',');
            int s = ids.Length;
            int code = 0;

            //循环
            for (int i = 0; i < ids.Length; i++)
            {
                string gid = ids[i];
                SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@GId",SqlDbType=SqlDbType.VarChar,Value=gid,Direction=ParameterDirection.Input },
                new SqlParameter{ParameterName="@Bynum",SqlDbType=SqlDbType.Int,Value=Num,Direction=ParameterDirection.Input }
               };
                int flag= _dBHelper.ExecuteNonQueryProc("AddRequGoods", param);

                if(flag>0)
                {
                    code += flag;
                }
            }

            if(code==s)
            {
                return 1;
            }
            else
            {
                //删除
                int a = _dBHelper.ExecuteNonQueryProc("DeleRequPurGood", null);
                if(a>0)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            
        }
        #endregion


        #region 采购单模块

        #region 采购单显示
        public List<PurChaseOrder> GetPurList(string state, string time, string gname, string bgname, int pageindex, int pagesize, ref int rowcount)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@state",SqlDbType=SqlDbType.VarChar,Value=state,Direction=ParameterDirection.Input },
                 new SqlParameter{ParameterName="@time",SqlDbType=SqlDbType.DateTime,Value=time,Direction=ParameterDirection.Input },
                  new SqlParameter{ParameterName="@Gname",SqlDbType=SqlDbType.VarChar,Value=gname,Direction=ParameterDirection.Input },
                   new SqlParameter{ParameterName="@bgname",SqlDbType=SqlDbType.VarChar,Value=bgname,Direction=ParameterDirection.Input },
                    new SqlParameter{ParameterName="@pageindex",SqlDbType=SqlDbType.Int,Value=pageindex,Direction=ParameterDirection.Input },
                     new SqlParameter{ParameterName="@pagesize",SqlDbType=SqlDbType.Int,Value=pagesize,Direction=ParameterDirection.Input },
                      new SqlParameter{ParameterName="@rowCount",SqlDbType=SqlDbType.Int,Direction=ParameterDirection.Output },
            };
            DataTable tb = _dBHelper.ExecuteProc("PurShowProc", param, ref rowcount);
            string json = JsonConvert.SerializeObject(tb);
            List<PurChaseOrder> list = JsonConvert.DeserializeObject<List<PurChaseOrder>>(json);
            return list;
        }
        #endregion

        #region  修改状态
        //审核通过
        public int UpdPurState1(string Id)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@Id",SqlDbType=SqlDbType.VarChar,Value=Id,Direction=ParameterDirection.Input }
            };
            return _dBHelper.ExecuteNonQueryProc("UpdPurState", param);
        }

        //审核未通过
        public int UpdPurState2(string Id)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@Id",SqlDbType=SqlDbType.VarChar,Value=Id,Direction=ParameterDirection.Input }
            };
            return _dBHelper.ExecuteNonQueryProc("UpdPurState2", param);
        }
        #endregion

        #region  指派采购处理人
        public int ZhiPaiPur(string Id, string Cgclr)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@Id",SqlDbType=SqlDbType.VarChar,Value=Id,Direction=ParameterDirection.Input },
                new SqlParameter{ParameterName="@Cgclr",SqlDbType=SqlDbType.VarChar,Value=Cgclr,Direction=ParameterDirection.Input }
            };
            return _dBHelper.ExecuteNonQueryProc("ZhiPaiPurProc", param);
        }
        #endregion

        #region  撤回采购处理人
        public int DelPurRole(string Id)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@Id",SqlDbType=SqlDbType.VarChar,Value=Id,Direction=ParameterDirection.Input }
            };
            return _dBHelper.ExecuteNonQueryProc("CheHuiPurProc", param);
        }
        #endregion

        #region  反填采购单信息
        public List<PurChaseInfo> FanTPur(string CId)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@CId",SqlDbType=SqlDbType.VarChar,Value=CId,Direction=ParameterDirection.Input }
             };
            DataTable tb = _dBHelper.ExecuteProc("FanTPur", param);
            string json = JsonConvert.SerializeObject(tb);
            List<PurChaseInfo> list = JsonConvert.DeserializeObject<List<PurChaseInfo>>(json);
            return list;
        }
        #endregion

        #region  查询请购单ID
        public List<RequisitionOrder> SelectQgIdProc()
        {
            DataTable tb = _dBHelper.ExecuteProc("selectQgIdProc", null);
            string json = JsonConvert.SerializeObject(tb);
            List<RequisitionOrder> list = JsonConvert.DeserializeObject<List<RequisitionOrder>>(json);
            return list;
        }
        #endregion

        #region  查询供应商ID
        public List<SupplierInfo> SelectGysIdProc()
        {
            DataTable tb = _dBHelper.ExecuteProc("selectGysIdProc", null);
            string json = JsonConvert.SerializeObject(tb);
            List<SupplierInfo> list = JsonConvert.DeserializeObject<List<SupplierInfo>>(json);
            return list;
        }
        #endregion

        #region  添加采购单信息
        public int AddPur(PurChaseInfo m)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@CreateTime",SqlDbType=SqlDbType.DateTime,Value=m.CreateTime,Direction=ParameterDirection.Input },
                new SqlParameter{ParameterName="@QID",SqlDbType=SqlDbType.UniqueIdentifier,Value=m.QID,Direction=ParameterDirection.Input },
                new SqlParameter{ParameterName="@GysId",SqlDbType=SqlDbType.UniqueIdentifier,Value=m.GysId,Direction=ParameterDirection.Input },
                new SqlParameter{ParameterName="@IsShui",SqlDbType=SqlDbType.Int,Value=m.IsShui,Direction=ParameterDirection.Input },
                 new SqlParameter{ParameterName="@ShuiLv",SqlDbType=SqlDbType.VarChar,Value=m.ShuiLv,Direction=ParameterDirection.Input },
                 new SqlParameter{ParameterName="@Address",SqlDbType=SqlDbType.VarChar,Value=m.Address,Direction=ParameterDirection.Input },
                 new SqlParameter{ParameterName="@BgName",SqlDbType=SqlDbType.VarChar,Value=m.BgName,Direction=ParameterDirection.Input },
                 new SqlParameter{ParameterName="@BgDept",SqlDbType=SqlDbType.VarChar,Value=m.BgDept,Direction=ParameterDirection.Input }
            };

            return _dBHelper.ExecuteNonQueryProc("AddPur", param);
        }
        #endregion

        #region  显示采购单商品信息
        public List<RequGoods> GetPurGoods(string Id)
        {
            SqlParameter[] param = new SqlParameter[] {
                 new SqlParameter{ParameterName="@Id",SqlDbType=SqlDbType.VarChar,Value=Id,Direction=ParameterDirection.Input  }
            };
            DataTable tb = _dBHelper.ExecuteProc("PurGoods", param);
            string json = JsonConvert.SerializeObject(tb);
            List<RequGoods> list = JsonConvert.DeserializeObject<List<RequGoods>>(json);
            return list;
        }
        #endregion

        #region  查询商品ID
        public List<GoodsInfo> GetGoodsId()
        {
            DataTable tb = _dBHelper.ExecuteProc("ChaGoodsID", null);
            string json = JsonConvert.SerializeObject(tb);
            List<GoodsInfo> list = JsonConvert.DeserializeObject<List<GoodsInfo>>(json);
            return list;
        }
        #endregion

        #region  根据ID删除相关的商品信息
        public int DeleteGoods(int RpgId)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@RpgId",SqlDbType=SqlDbType.Int,Value=RpgId,Direction=ParameterDirection.Input }
            };
            return _dBHelper.ExecuteNonQueryProc("DelRequPurGood", param);
        }
        #endregion

        #region  修改采购单信息
        public int UpdatePurInfo(PurChaseInfo m)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter{ParameterName="@ID",SqlDbType=SqlDbType.UniqueIdentifier,Value=m.ID,Direction=ParameterDirection.Input },
                new SqlParameter{ParameterName="@IsShui",SqlDbType=SqlDbType.Int,Value=m.IsShui,Direction=ParameterDirection.Input },
                 new SqlParameter{ParameterName="@ShuiLv",SqlDbType=SqlDbType.VarChar,Value=m.ShuiLv,Direction=ParameterDirection.Input },
                  new SqlParameter{ParameterName="@Address",SqlDbType=SqlDbType.VarChar,Value=m.Address,Direction=ParameterDirection.Input },
                   new SqlParameter{ParameterName="@BgName",SqlDbType=SqlDbType.VarChar,Value=m.BgName,Direction=ParameterDirection.Input },
                    new SqlParameter{ParameterName="@BgDept",SqlDbType=SqlDbType.VarChar,Value=m.BgDept,Direction=ParameterDirection.Input }
            };
            return _dBHelper.ExecuteNonQueryProc("UpdatePueInfo", param);
        }
        #endregion

        #endregion
    }
}
