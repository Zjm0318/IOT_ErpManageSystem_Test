using System;
using System.Collections.Generic;
using System.Text;
using IOT_ErpManageSystem.BLL.GoodsInfos;
using IOT_ErpManageSystem.DAL;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Models;

namespace IOT_ErpManageSystem.BLL.GoodsInfo
{
    public interface IGoodsBLL
    {
        #region 商品列表接口

        //显示商品信息
        List<IOT_ErpManageSystem.Models.GoodsInfo> ShowGoodsInfo(Page m,ref int total);

        //修改状态
        int UpdateState(string Id);

        //删除信息
        int DelGoodsInfo(string Id);

        #endregion

        #region 商品添加接口

        #region 商品添加信息接口
        //添加商品
        int AddGoodsInfo(Models.GoodsInfo m);

        //绑定分类
        List<GoodsType> BindInfo();

        //绑定二级分类
        List<GoodsType> BindTwoInfo(int TypeId);

        #endregion

        #region 商品添加属性接口

        //显示商品名称
        List<Models.GoodsInfo> ShowName();

        //显示尺码
        List<Sizes> ShowSize();

        //显示颜色
        List<Colors> ShowColor();

        //添加属性
        int AddProperty(GoodsProperty m);

        //添加颜色
        int AddColors(Colors m);

        //删除颜色
        int DelColors(string CId);

        //显示商品尺码+颜色
        List<Models.GoodsInfo> ShowGoodsSC(string Id);

        //删除属性信息
        int DelPreperty(string PId);

        #endregion

        #endregion

        #region 商品价格本接口
        //显示价格本信息
        List<GoodsPrice> ShowGoodsPrice(PagePrice m,ref int total);

        //添加商品价格本
        int AddPrice(GoodsPrice m);

        //根据条件查询价格信息
        GoodsPrice SelectPrice(string priceId);

        //修改价格本
        int UpdatePrice(GoodsPrice m);

        #endregion
    }
}
