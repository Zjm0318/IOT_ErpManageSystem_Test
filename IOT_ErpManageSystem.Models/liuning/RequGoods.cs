using System;

namespace IOT_ErpManageSystem.Models
{
    public class RequGoods
    {
        //中间表ID
        public int RPGID { get; set; }
        //商品ID
        public Guid Id { get; set; }
        //商品编号
        public string GoodsId { get; set; }
        //商品名称
        public string GoodsName { get; set; }
        //商品品牌
        public string GoodsBrand { get; set; }
        //规格
        public string GoodsRule { get; set; }
        //单位
        public string SKU { get; set; }
        //购买数量
        public int BuyNum { get; set; }
        //可用量
        public int KYNum { get; set; }
        //现存量
        public int GoodsStock { get; set; }
        //商品市场价
        public decimal GoodsPrices { get; set; }
        //商品进货价
        public decimal JinHPrice { get; set; }


    }
}
