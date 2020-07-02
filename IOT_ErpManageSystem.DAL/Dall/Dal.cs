using IOT_ErpManageSystem.DAL.IDall;
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

namespace IOT_ErpManageSystem.DAL.Dall
{
    public class Dal : IDal
    {
        private IDBHelper _db;
        public Dal(IDBHelper db)
        {
            _db = db;
        }
        /// <summary>
        /// jwt登录
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public Personal Log(Personal m)
        {
            SqlParameter[] paras = new SqlParameter[] {
                 new SqlParameter("@userName",m.UserName),
            new SqlParameter("@userPwd", m.Pwd)
        };
            return _db.GetList<Personal>("Pro_Loginn", paras).FirstOrDefault();
        }
        /// <summary>
        /// 个人信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<Personal> ShowPer(string uid)
        {
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@UId",uid)
            };
            return _db.GetList<Personal>("pro_Personal", paras);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Personal model)
        {
            string proName = "Pro_Update";
            SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter{ ParameterName="@UId",DbType=DbType.Guid,Direction=ParameterDirection.Input,Value=model.UID},
             new SqlParameter{ ParameterName="@UserPwd",DbType=DbType.String,Direction=ParameterDirection.Input,Value=model.Pwd},
            };
            return _db.ExecuteNonQueryProc(proName, parameters);
        }
        /// <summary>
        /// 修改用户名
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UserName(Personal model)
        {
            string proName = "ProUserName";
            SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter{ ParameterName="@UId",DbType=DbType.Guid,Direction=ParameterDirection.Input,Value=model.UID},
             new SqlParameter{ ParameterName="@UserName",DbType=DbType.String,Direction=ParameterDirection.Input,Value=model.UserName},
            };
            return _db.ExecuteNonQueryProc(proName, parameters);
        }
        /// <summary>
        /// 修改手机号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpIphone(Personal model)
        {
            string proName = "ProIphone";
            SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter{ ParameterName="@UId",DbType=DbType.Guid,Direction=ParameterDirection.Input,Value=model.UID},
             new SqlParameter{ ParameterName="@IPhone",DbType=DbType.String,Direction=ParameterDirection.Input,Value=model.IPhone},
            };
            return _db.ExecuteNonQueryProc(proName, parameters);
        }
        /// <summary>
        /// 显示订单报表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="ddh"></param>
        /// <param name="userName"></param>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public List<Order> ShowOrder(int pageIndex, int pageSize,string ddh,string userName,string time,int type,int from, ref int rowCount)
        {
            string proName = "Pro_Order";
            string where = " where (1=1) ";
            if(!string.IsNullOrEmpty(ddh))
            {
                where += $" and o.OrderId='{ddh}'";
            }
            if (!string.IsNullOrEmpty(userName))
            {
                where += $" and u.UserName='{userName}'";
            }
            if (!string.IsNullOrEmpty(time))
            {
                where += $" and o.SubmitTime= '{time}'";
            }
            if (type!=0)
            {
                where += $" and o.OrState='{type}'";
            }
            if (from!=0)
            {
                where += $" and o.OrFrom='{from}'";
            }
            SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter{ ParameterName="@pageIndex",DbType=DbType.Int32,Direction=ParameterDirection.Input,Value=pageIndex},
             new SqlParameter{ ParameterName="@pageSize",DbType=DbType.Int32,Direction=ParameterDirection.Input,Value=pageSize},
             new SqlParameter{ ParameterName="@where",DbType=DbType.String,Direction=ParameterDirection.Input,Value=where},
             new SqlParameter{ ParameterName="@Rowcount",DbType=DbType.Int32,Direction=ParameterDirection.Output},
            };
            DataTable tb = _db.ExecuteProc(proName, parameters,ref rowCount);
            return JsonConvert.DeserializeObject<List<Order>>(JsonConvert.SerializeObject(tb));
        }
        /// <summary>
        /// 显示订单来源
        /// </summary>
        /// <returns></returns>
        public List<OrderFrom> OrderFrom()
        {
            string proName = "ProOrderFrom";
            SqlParameter[] parameters = new SqlParameter[] {};
            return _db.GetList<OrderFrom>(proName,parameters);
        }
        /// <summary>
        /// 显示订单状态
        /// </summary>
        /// <returns></returns>
        public List<OrderState> OrderState()
        {
            string proName = "ProOrderState";
            SqlParameter[] parameters = new SqlParameter[] {};
            return _db.GetList<OrderState>(proName, parameters);
        }
        /// <summary>
        /// 删除订单表数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Dle(string id)
        {
            string proName = "DelOrder";
            SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter{ ParameterName="@Id",DbType=DbType.Int32,Direction=ParameterDirection.Input,Value=id},
            };
            return _db.ExecuteNonQueryProc(proName, parameters);
        }
        /// <summary>
        /// 显示商品表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="proBh"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public List<GoodsInfo> GoodsPrice(int pageIndex, int pageSize, string proBh, ref int rowCount)
        {
            string proName = "Pro_ProPrice";
            string where = " where (1=1) ";
            if (!string.IsNullOrEmpty(proBh))
            {
                where += $" and g.GoodsId='{proBh}'";
            }
            SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter{ ParameterName="@pageIndex",DbType=DbType.Int32,Direction=ParameterDirection.Input,Value=pageIndex},
             new SqlParameter{ ParameterName="@pageSize",DbType=DbType.Int32,Direction=ParameterDirection.Input,Value=pageSize},
             new SqlParameter{ ParameterName="@where",DbType=DbType.String,Direction=ParameterDirection.Input,Value=where},
             new SqlParameter{ ParameterName="@Rowcount",DbType=DbType.Int32,Direction=ParameterDirection.Output},
            };
            DataTable tb = _db.ExecuteProc(proName, parameters, ref rowCount);
            return JsonConvert.DeserializeObject<List<GoodsInfo>>(JsonConvert.SerializeObject(tb));
        }
        /// <summary>
        /// 显示添加的商品名称
        /// </summary>
        /// <returns></returns>
        public List<GoodsInfo> ShowPrice()
        {
            string proName = "ShowPrice";
            SqlParameter[] parameters = new SqlParameter[] { };
            return _db.GetList<GoodsInfo>(proName, parameters);
        }
        /// <summary>
        /// 添加商品表的数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPrice(GoodsPrice model)
        {
            string proName = "Pro_Price";
            SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter{ ParameterName="@Id",DbType=DbType.Guid,Direction=ParameterDirection.Input,Value=model.Id},
             new SqlParameter{ ParameterName="@JinHPrice",DbType=DbType.Decimal,Direction=ParameterDirection.Input,Value=model.JinHPrice},
            };
            return _db.ExecuteNonQueryProc(proName, parameters);
        }

        public int DleGoodsInfo(string id)
        {
            string proName = "DelGoodsInfo";
            SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter{ ParameterName="@Id",DbType=DbType.String,Direction=ParameterDirection.Input,Value=id},
            };
            return _db.ExecuteNonQueryProc(proName, parameters);
        }
        /// <summary>
        /// 编辑商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<GoodsInfo> GoodsThree(string id)
        {
            string proName = "ProS";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter{ ParameterName="@Id",DbType=DbType.String,Direction=ParameterDirection.Input,Value=id},
            };
            DataTable tb = _db.ExecuteProc(proName, parameters);
            return JsonConvert.DeserializeObject<List<GoodsInfo>>(JsonConvert.SerializeObject(tb));
        }
        /// <summary>
        /// 商品类型
        /// </summary>
        /// <returns></returns>
        public List<GoodsType> Type()
        {
            string proName = "GType";
            SqlParameter[] parameters = new SqlParameter[] { };
            return _db.GetList<GoodsType>(proName, parameters);
        }
        //修改商品信息
        public int UpGoods(GoodsInfo m)
        {
            string proName = "GoodsUpdate";
            SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter{ ParameterName="@Id",DbType=DbType.String,Direction=ParameterDirection.Input,Value=m.Id.ToString()},
             new SqlParameter{ ParameterName="@GoodsName",DbType=DbType.String,Direction=ParameterDirection.Input,Value=m.GoodsName},
             new SqlParameter{ ParameterName="@GoodsBrand",DbType=DbType.String,Direction=ParameterDirection.Input,Value=m.GoodsBrand},
             new SqlParameter{ ParameterName="@TypeId",DbType=DbType.Guid,Direction=ParameterDirection.Input,Value=m.TypeId},
             new SqlParameter{ ParameterName="@GoodsRule",DbType=DbType.String,Direction=ParameterDirection.Input,Value=m.GoodsRule},
             new SqlParameter{ ParameterName="@SKU",DbType=DbType.String,Direction=ParameterDirection.Input,Value=m.SKU},
             new SqlParameter{ ParameterName="@GoodsPrices",DbType=DbType.String,Direction=ParameterDirection.Input,Value=m.GoodsPrices},
             new SqlParameter{ ParameterName="@PId",DbType=DbType.String,Direction=ParameterDirection.Input,Value=m.PriceId},
             new SqlParameter{ ParameterName="@JinHPrice",DbType=DbType.String,Direction=ParameterDirection.Input,Value=m.JinHPrice},
            };
            return _db.ExecuteNonQueryProc(proName, parameters);
        }
    }
}
