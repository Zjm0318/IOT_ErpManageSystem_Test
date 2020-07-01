using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using IOT_ErpManageSystem.BLL.GoodsInfos;
using IOT_ErpManageSystem.DAL;
using IOT_ErpManageSystem.DAL.DBHelper;
using IOT_ErpManageSystem.DAL.IDBHelp;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Models;
using Newtonsoft.Json;

namespace IOT_ErpManageSystem.BLL.GoodsInfo
{
    public class GoodsBLL : IGoodsBLL
    {
        DBHelper dBHelper = new DBHelper();

        #region 商品列表模块

        #region 商品信息显示
        public List<Models.GoodsInfo> ShowGoodsInfo(Page m, ref int total)
        {
            string procName = "PageGoods";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@pageIndex", DbType= DbType.Int32, Direction= ParameterDirection.Input,Value=m.pageIndex },
                new SqlParameter{ ParameterName="@pageSize", DbType= DbType.Int32, Direction= ParameterDirection.Input,Value=m.pageSize },
                new SqlParameter{ ParameterName="@rowCount", DbType= DbType.Int32, Direction= ParameterDirection.Output},
                new SqlParameter{ ParameterName="@goodsId", DbType= DbType.String, Direction= ParameterDirection.Input,Value=m.goodsId },
                new SqlParameter{ ParameterName="@goodsName", DbType= DbType.String, Direction= ParameterDirection.Input,Value=m.goodsName },
                new SqlParameter{ ParameterName="@goodsBrand", DbType= DbType.String, Direction= ParameterDirection.Input,Value=m.goodsBrand }
            };
            DataTable tb = dBHelper.ExecuteProc(procName, param, ref total);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<IOT_ErpManageSystem.Models.GoodsInfo>>(json).ToList();
        }
        #endregion

        #region 修改商品状态
        public int UpdateState(string Id)
        {
            string procName = "UpdateState";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Id", DbType= DbType.String, Direction= ParameterDirection.Input,Value=Id }
            };
            return dBHelper.ExecuteNonQueryProc(procName, param);
        }
        #endregion

        #region 删除商品信息
        public int DelGoodsInfo(string Id)
        {
            string procName = "DelGoodsInfo";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Id", DbType= DbType.String, Direction= ParameterDirection.Input,Value=Id }
            };
            return dBHelper.ExecuteNonQueryProc(procName, param);
        }
        #endregion

        #endregion

        #region 商品添加模块

        #region 添加商品信息

        #region 添加商品信息
        public int AddGoodsInfo(Models.GoodsInfo m)
        {
            string procName = "AddGoodsInfo";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@GoodsId", DbType= DbType.String, Direction= ParameterDirection.Input,Value=m.GoodsId },
                new SqlParameter{ ParameterName="@GoodsName", DbType= DbType.String, Direction= ParameterDirection.Input,Value=m.GoodsName },
                new SqlParameter{ ParameterName="@GoodsImg", DbType= DbType.String, Direction= ParameterDirection.Input,Value=m.GoodsImg },
                new SqlParameter{ ParameterName="@GoodsPrice", DbType= DbType.Decimal, Direction= ParameterDirection.Input,Value=m.GoodsPrices },
                new SqlParameter{ ParameterName="@GoodsBrand", DbType= DbType.String, Direction= ParameterDirection.Input,Value=m.GoodsBrand },
                new SqlParameter{ ParameterName="@GoodsStock", DbType= DbType.Int32, Direction= ParameterDirection.Input,Value=m.GoodsStock },
                new SqlParameter{ ParameterName="@TypeId", DbType= DbType.Guid, Direction= ParameterDirection.Input,Value=m.TypeId },
                new SqlParameter{ ParameterName="@StockYJ", DbType= DbType.Int32, Direction= ParameterDirection.Input,Value=m.StockYJ },
                new SqlParameter{ ParameterName="@UpTime", DbType= DbType.Date, Direction= ParameterDirection.Input,Value=m.UpTime },
                 new SqlParameter{ ParameterName="@GoodsRule", DbType= DbType.String, Direction= ParameterDirection.Input,Value=m.GoodsRule },
                  new SqlParameter{ ParameterName="@SKU", DbType= DbType.String, Direction= ParameterDirection.Input,Value=m.SKU },
                new SqlParameter{ ParameterName="@GoodsState", DbType= DbType.Int32, Direction= ParameterDirection.Input,Value=m.GoodsState }
            };
            return dBHelper.ExecuteNonQueryProc(procName, param);
        }
        #endregion

        #region 绑定一级分类
        public List<GoodsType> BindInfo()
        {
            string procName = "SelectType";
            DataTable tb = dBHelper.ExecuteProc(procName, null);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<GoodsType>>(json).ToList();
        }
        #endregion

        #region 绑定一级分类
        public List<GoodsType> BindTwoInfo(int TypeId)
        {
            string procName = "SelectTwoType";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter { ParameterName="@TypeId", DbType= DbType.Int32, Direction= ParameterDirection.Input,Value=TypeId }
            };

            DataTable tb = dBHelper.ExecuteProc(procName, param);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<GoodsType>>(json).ToList();
        }
        #endregion

        #endregion

        #region 添加商品属性

        #region 显示商品名称
        public List<Models.GoodsInfo> ShowName()
        {
            string procName = "SelectInfo";
            DataTable tb = dBHelper.ExecuteProc(procName, null);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<IOT_ErpManageSystem.Models.GoodsInfo>>(json).ToList();
        }
        #endregion

        #region 显示尺码
        public List<Sizes> ShowSize()
        {
            string procName = "SelectSize";
            DataTable tb = dBHelper.ExecuteProc(procName, null);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<Sizes>>(json).ToList();
        }

        #endregion

        #region 显示颜色
        public List<Colors> ShowColor()
        {
            string procName = "SelectColor";
            DataTable tb = dBHelper.ExecuteProc(procName, null);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<Colors>>(json).ToList();
        }
        #endregion

        #region 添加属性
        public int AddProperty(GoodsProperty m)
        {
            string procName = "AddProperty";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@GoodsId", DbType= DbType.Guid, Direction= ParameterDirection.Input,Value=m.GoodsId },
                 new SqlParameter{ ParameterName="@SId", DbType= DbType.Guid, Direction= ParameterDirection.Input,Value=m.SId },
                  new SqlParameter{ ParameterName="@CId", DbType= DbType.Guid, Direction= ParameterDirection.Input,Value=m.CId }
            };
            return dBHelper.ExecuteNonQueryProc(procName, param);
        }
        #endregion

        #region 添加颜色
        public int AddColors(Colors m)
        {
            string procName = "AddColor";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@color", DbType= DbType.String, Direction= ParameterDirection.Input,Value=m.Color },
            };
            return dBHelper.ExecuteNonQueryProc(procName, param);
        }
        #endregion

        #region 删除颜色
        public int DelColors(string CId)
        {
            string procName = "DelColor";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@CId", DbType= DbType.String, Direction= ParameterDirection.Input,Value=CId },
            };
            return dBHelper.ExecuteNonQueryProc(procName, param);
        }
        #endregion

        #region 显示商品颜色+尺码
        public List<Models.GoodsInfo> ShowGoodsSC(string Id)
        {
            string procName = "ShowGoodsSC";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Id", DbType= DbType.String, Direction= ParameterDirection.Input,Value=Id },
            };
            DataTable tb = dBHelper.ExecuteProc(procName, param);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<IOT_ErpManageSystem.Models.GoodsInfo>>(json).ToList();
        }



        #endregion

        #region 删除商品属性信息
        public int DelPreperty(string PId)
        {
            string procName = "DelProperty";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@PId", DbType= DbType.String, Direction= ParameterDirection.Input,Value=PId },
            };
            return dBHelper.ExecuteNonQueryProc(procName, param);
        }
        #endregion

        #endregion

        #endregion

        #region 商品价格本模块

        #region 显示价格本信息
        public List<GoodsPrice> ShowGoodsPrice(PagePrice m,ref int total)
        {
            string procName = "PagePrice";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@pageIndex", DbType= DbType.Int32, Direction= ParameterDirection.Input,Value=m.pageIndex },
                new SqlParameter{ ParameterName="@pageSize", DbType= DbType.Int32, Direction= ParameterDirection.Input,Value=m.pageSize },
                new SqlParameter{ ParameterName="@rowCount", DbType= DbType.Int32, Direction= ParameterDirection.Output},
                new SqlParameter{ ParameterName="@goodsId", DbType= DbType.String, Direction= ParameterDirection.Input,Value=m.goodsId }
            };
            DataTable tb = dBHelper.ExecuteProc(procName, param,ref total);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<GoodsPrice>>(json).ToList();
        }
        #endregion

        #region 添加商品价格本
        public int AddPrice(GoodsPrice m)
        {
            string procName = "AddPrice";
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter{ ParameterName="@Id", DbType= DbType.Guid, Direction= ParameterDirection.Input,Value=m.Id },
                new SqlParameter{ ParameterName="@JinHPrice", DbType= DbType.Decimal, Direction= ParameterDirection.Input,Value=m.JinHPrice }
            };
            return dBHelper.ExecuteNonQueryProc(procName, param);
        }

        #endregion

        #region 根据条件查询价格信息
        public GoodsPrice SelectPrice(string priceId)
        {
            string procName = "SelectPrice";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@PriceId", DbType= DbType.String, Direction= ParameterDirection.Input,Value=priceId }
            };
            DataTable table = dBHelper.ExecuteProc(procName, param);
            string json = JsonConvert.SerializeObject(table);
            return JsonConvert.DeserializeObject<List<GoodsPrice>>(json).FirstOrDefault();
        }
        #endregion

        #region 修改价格本

        public int UpdatePrice(GoodsPrice m)
        {
            string procName = "UpdatePrice";
            SqlParameter[] param = new SqlParameter[]
           {
                new SqlParameter{ ParameterName="@PriceId", DbType= DbType.Guid, Direction= ParameterDirection.Input,Value=m.PriceId },
                new SqlParameter{ ParameterName="@Id", DbType= DbType.String, Direction= ParameterDirection.Input,Value=m.Id },
                new SqlParameter{ ParameterName="@JinHPrice", DbType= DbType.Decimal, Direction= ParameterDirection.Input,Value=m.JinHPrice }
           };
            return dBHelper.ExecuteNonQueryProc(procName, param);
        }
        #endregion

        #endregion
    }
}
