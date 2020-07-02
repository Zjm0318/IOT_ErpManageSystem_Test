using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_ErpManageSystem.BLL.GoodsInfo;
using IOT_ErpManageSystem.BLL.GoodsInfos;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IOT_ErpManageSystem.API.Controllers.GoodsInfo
{
    [Route("api/[controller]/[action]")]
    public class GoodsController : Controller
    {

        #region 依赖注入

        IWebHostEnvironment hosting;
        private IGoodsBLL goodsBLL;
        public GoodsController(IGoodsBLL _goodsBLL, IWebHostEnvironment environment)
        {
            goodsBLL = _goodsBLL;
            hosting = environment;
        }
        #endregion

        #region 显示商品信息

        [HttpPost]
        public async Task<ShowInfo> ShowGoodsInfo([FromForm]Page m)
        {
            int total=0;
            ShowInfo slist = new ShowInfo();
            slist.list= goodsBLL.ShowGoodsInfo(m, ref total);
            slist.count = (total / m.pageSize) + (total % m.pageSize > 0 ? 1 : 0);

            ShowInfo info = await Task.Run(() => { return slist; });
            return info;
        }

        //修改商品状态
        [HttpGet]
        public int UpdateState(string Id)
        {
            return goodsBLL.UpdateState(Id);
        }

        //删除商品信息
        [HttpGet]
        public int DelGoodsInfo(string Id)
        {
            return goodsBLL.DelGoodsInfo(Id);
        }
        #endregion

        #region 添加商品

        #region 添加商品信息
        [HttpPost]
        public int AddGoodsInfo(string obj)
        {
            Models.GoodsInfo m = JsonConvert.DeserializeObject<Models.GoodsInfo>(obj);

            //上传图片
            if (Request.Form.Files.Count > 0)
            {
                // tp://localhost:49233/Files/%E6%96%B0%E5%BB%BA%E6%96%87%E6%9C%AC%E6%96%87%E6%A1%A3.html
                //获取物理路径 webtootpath
                string path = hosting.WebRootPath + "\\Img\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var file = Request.Form.Files[0];
                //拼接路径
                path += $"{file.FileName}";

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
                m.GoodsImg = "/Img/" +file.FileName;
            }

            return goodsBLL.AddGoodsInfo(m);
        }

        //显示一级绑定
        [HttpGet]
        public List<GoodsType> BindInfo()
        {
            return goodsBLL.BindInfo();
        }

        //显示二级分类
        [HttpGet]
        public List<GoodsType> BindTwoInfo(int TypeId)
        {
            return goodsBLL.BindTwoInfo(TypeId);
        }

        #endregion

        #region 添加商品属性

        //显示商品名称
        [HttpGet]
        public async Task<List<Models.GoodsInfo>> ShowName()
        {
            List<Models.GoodsInfo> list = await Task.Run(() => { return goodsBLL.ShowName(); });
            return list;
        }

        //显示尺码
        [HttpGet]
        public async Task<List<Sizes>> ShowSize()
        {
            List<Sizes> slist = await Task.Run(() => { return goodsBLL.ShowSize(); });
            return slist;
        }

        //显示颜色
        [HttpGet]
        public async Task<List<Colors>> ShowColors()
        {
            List<Colors> clist = await Task.Run(() => { return goodsBLL.ShowColor(); });
            return clist;            
        }

        //添加属性
        [HttpPost]
        public int AddProperty([FromForm]GoodsProperty m)
        {
            return goodsBLL.AddProperty(m);
        }

        //添加颜色
        [HttpPost]
        public int AddColors([FromForm]Colors m)
        {
            return goodsBLL.AddColors(m);
        }

        //删除颜色
        [HttpGet]
        public int DelColors(string CId)
        {
            return goodsBLL.DelColors(CId);
        }

        //显示商品尺码+颜色
        [HttpGet]
        public async Task<List<Models.GoodsInfo>> ShowGoodsSC(string Id)
        {
            List<Models.GoodsInfo> list = await Task.Run(() => { return goodsBLL.ShowGoodsSC(Id); });
            return list;          
        }

        //删除商品属性信息
        [HttpGet]
        public int DelPreperty(string PId)
        {
            return goodsBLL.DelPreperty(PId);
        }
        #endregion

        #endregion

        #region 商品价格本

        //显示价格本信息
        [HttpPost]
        public async Task<ShowInfo> ShowGoodsPrice([FromForm]PagePrice m)
        {
            int total = 0;
            ShowInfo slist = new ShowInfo();
            slist.plist = goodsBLL.ShowGoodsPrice(m, ref total);
            slist.count = (total / m.pageSize) + (total % m.pageSize > 0 ? 1 : 0);

            ShowInfo info = await Task.Run(() => { return slist; });
            return info;
        }

        //添加商品价格本
        [HttpPost]
        public int AddPrice([FromForm]GoodsPrice m)
        {
            return goodsBLL.AddPrice(m);
        }

        //根据条件查询价格信息
        [HttpGet]
        public GoodsPrice SelectPrice(string priceId)
        {
            return goodsBLL.SelectPrice(priceId);
        }

        //修改价格本
        [HttpPost]
        public int UpdatePrice([FromForm]GoodsPrice m)
        {
            return goodsBLL.UpdatePrice(m);
        }

        //判断价格本中是否已有此商品
        [HttpGet]
        public List<GoodsPrice> PricesInfo()
        {
            return goodsBLL.PricesInfo();
        }
        #endregion
    }
}
