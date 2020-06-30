using IOT_ErpManageSystem.DAL.IDBHelp;
using IOT_ErpManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace IOT_ErpManageSystem.BLL.Supplier
{
    public class SupplierBLL : ISupplierBLL
    {
        private IDBHelper _db;
        public SupplierBLL(IDBHelper db)
        {
            _db = db;
        }

        //添加
        public int AddSupplier(SupplierInfo supplier, ContactsInfo contacts)
        {
            //存储过程名称
            string proc = "SP_Sup_Con";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter{ ParameterName="@GysBianHao",Value=supplier.GID,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@LaiYuan",Value=supplier.GLaiYuan,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@FuZeRen",Value=supplier.YJfzr,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@DanWei",Value=supplier.DwName,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@PinPai",Value=supplier.PinPai,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@GDesc",Value=supplier.GDesc,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@FanWei",Value=supplier.JYRange,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@Date",Value=supplier.CreateDate,DbType=DbType.DateTime,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@LxrName",Value=contacts.LxrName,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@LJob",Value=contacts.LJob,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@Phone",Value=contacts.Phone,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@Email",Value=contacts.Email,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@GDphone",Value=contacts.GDphone,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@ChuanZhen",Value=contacts.ChuanZhen,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@QQ",Value=contacts.QQ,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@WeiXin",Value=contacts.WeiXin,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@Addresss",Value=contacts.Addresss,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@Url",Value=contacts.Url,DbType=DbType.String,Direction=ParameterDirection.Input },
            };
            return _db.ExecuteNonQueryProc(proc, parameters);
        }

        //修改
        public int EditSupplier(SupplierInfo supplier, ContactsInfo contacts)
        {
            string Gysid = supplier.GysId.ToString();
            string Lxrid = contacts.LxrId.ToString();
            //存储过程名称
            string proc = "SP_Sup_Con_Edit";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter{ ParameterName="@GysBianHao",Value=supplier.GID,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@LaiYuan",Value=supplier.GLaiYuan,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@FuZeRen",Value=supplier.YJfzr,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@DanWei",Value=supplier.DwName,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@PinPai",Value=supplier.PinPai,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@GDesc",Value=supplier.GDesc,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@FanWei",Value=supplier.JYRange,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@GysId",Value=Gysid,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@LxrName",Value=contacts.LxrName,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@LxrId",Value=Lxrid,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@LJob",Value=contacts.LJob,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@Phone",Value=contacts.Phone,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@Email",Value=contacts.Email,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@GDphone",Value=contacts.GDphone,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@ChuanZhen",Value=contacts.ChuanZhen,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@QQ",Value=contacts.QQ,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@WeiXin",Value=contacts.WeiXin,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@Addresss",Value=contacts.Addresss,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@Url",Value=contacts.Url,DbType=DbType.String,Direction=ParameterDirection.Input },
            };
            return _db.ExecuteNonQueryProc(proc, parameters);
        }

        //显示
        public List<SupplierInfo> GetSupplier(SupperModel m, ref int rowCount)
        {
            //存储过程名称
            string proc = "SP_Supplier";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter{ ParameterName="@GysBianHao",Value=m.GID,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@LaiYuan",Value=m.GLaiYuan,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@FuZeRen",Value=m.YJfzr,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@DanWei",Value=m.DwName,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@PinPai",Value=m.PinPai,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@FanWei",Value=m.JYRange,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@Date",Value=m.CreateDate,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@PageIndex",Value=m.PageIndex,DbType=DbType.Int32,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@PageSize",Value=m.PageSize,DbType=DbType.Int32,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@rowCount",DbType=DbType.Int32,Direction=ParameterDirection.Output },
            };

            DataTable tb = _db.ExecuteProc(proc, parameters,ref rowCount);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<SupplierInfo>>(json);
        }

        //获取反填数据
        public SupAndCon ShowSupAndCon(string id)
        {
            //存储过程名称
            string proc = "SP_SupAndCon";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter{ ParameterName="@GId",Value=id,DbType=DbType.String,Direction=ParameterDirection.Input },
            };
            DataTable tb= _db.ExecuteProc(proc,parameters);
            string json = JsonConvert.SerializeObject(tb);
            List<SupAndCon> list= JsonConvert.DeserializeObject<List<SupAndCon>>(json);
            //循环获取值
            SupAndCon m = list.FirstOrDefault();
            return m;
        }

    }
}
