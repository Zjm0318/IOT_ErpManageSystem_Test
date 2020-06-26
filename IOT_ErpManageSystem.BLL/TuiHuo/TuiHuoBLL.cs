﻿using IOT_ErpManageSystem.DAL.IDBHelp;
using IOT_ErpManageSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IOT_ErpManageSystem.BLL.TuiHuo
{
    public class TuiHuoBLL : ITuiHuoBLL
    {
        private IDBHelper _db;
        public TuiHuoBLL(IDBHelper db)
        {
            _db = db;
        }

        //显示退货单
        public List<TuiHuo> GetTuiHuos(TuiHuoModel m,ref int rowCount)
        {
            //存储过程名称
            string proc = "TH_TuiHuo";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter{ ParameterName="@State",Value=m.States,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@CreateTime",Value=m.CreateDate,DbType=DbType.DateTime,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@GysName",Value=m.DwName,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@CangKu",Value=m.StorageName,DbType=DbType.String,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@PageIndex",Value=m.PageIndex,DbType=DbType.Int32,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@PageSize",Value=m.PageSize,DbType=DbType.Int32,Direction=ParameterDirection.Input },
                new SqlParameter{ ParameterName="@rowCount",DbType=DbType.Int32,Direction=ParameterDirection.Output },
            };

            DataTable tb = _db.ExecuteProc(proc, parameters, ref rowCount);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<TuiHuo>>(json);
        }

        //显示仓库
        public List<tb_Storage> GetStorage()
        {
            //存储过程名称
            string proc = "TH_CangKu";
            DataTable tb = _db.ExecuteProc(proc, null);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<tb_Storage>>(json);
        }

        //审核
        public int ShenHe(string id, string sta)
        {
            //存储过程名称
            string proc = "TH_TuiHuo_Edit";
            SqlParameter[] parameters = new SqlParameter[] { 
            new SqlParameter{ParameterName="@Id",Value=id,DbType=DbType.String,Direction=ParameterDirection.Input },
            new SqlParameter{ParameterName="@Sta",Value=sta,DbType=DbType.String,Direction=ParameterDirection.Input },
            };
            return _db.ExecuteNonQueryProc(proc,parameters);
        }

        //显示供应商
        public List<SupplierInfo> GetSuppliers()
        {
            //存储过程名称
            string proc = "TH_GongYingShang";
            DataTable tb = _db.ExecuteProc(proc, null);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<SupplierInfo>>(json);
        }

        //显示商品
        public List<GoodsModel> GetGoods()
        {
            //存储过程名称
            string proc = "proc_Goods";
            DataTable tb = _db.ExecuteProc(proc, null);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<GoodsModel>>(json);
        }

        //添加商品
        public int AddGoods(string id)
        {
            //存储过程名称
            string proc = "TH_AddGoods";
            SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter{ParameterName="@id",Value=id,DbType=DbType.String,Direction=ParameterDirection.Input },
            };
            return _db.ExecuteNonQueryProc(proc, parameters);
        }

        //显示退货商品
        public List<GoodsModel> GetShowGoods()
        {
            //存储过程名称
            string proc = "TH_ShowGoods";
            DataTable tb = _db.ExecuteProc(proc, null);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<GoodsModel>>(json);
        }

        //添加退货表信息
        public int AddTuiHuo(TuiHouInfo m)
        {
            //存储过程名称
            string proc = "TH_AddTuiHuo";
            SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter{ParameterName="@CreateDate",Value=m.CreateTime,DbType=DbType.DateTime,Direction=ParameterDirection.Input },
            new SqlParameter{ParameterName="@TuiHuoDate",Value=m.TuiHuoTime,DbType=DbType.DateTime,Direction=ParameterDirection.Input },
            new SqlParameter{ParameterName="@Gysid",Value=m.GysID.ToString(),DbType=DbType.String,Direction=ParameterDirection.Input },
            new SqlParameter{ParameterName="@CangKuid",Value=m.TCangKu.ToString(),DbType=DbType.String,Direction=ParameterDirection.Input },
            new SqlParameter{ParameterName="@TuiHuoFqr",Value=m.THFqr,DbType=DbType.String,Direction=ParameterDirection.Input },
            new SqlParameter{ParameterName="@Sta",Value=m.States,DbType=DbType.String,Direction=ParameterDirection.Input }
            };
            return _db.ExecuteNonQueryProc(proc, parameters);
        }

        //删除退货商品
        public int DeleteGoods(string id)
        {
            //存储过程名称
            string proc = "TH_DelGoods";
            SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter{ParameterName="@id",Value=id,DbType=DbType.String,Direction=ParameterDirection.Input },
            };
            return _db.ExecuteNonQueryProc(proc, parameters);
        }
    }
}
