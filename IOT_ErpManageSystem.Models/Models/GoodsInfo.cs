using System;
namespace IOT_ErpManageSystem.Models
{
    public class GoodsInfo
    {
        public Guid Id { get; set; }
        public string PId { get; set; }
        public string GoodsId { get; set; }
        public string GoodsName { get; set; }
        public string GoodsImg { get; set; }
        public decimal GoodsPrices { get; set; }
        public string GoodsBrand { get; set; }
        public Guid PropertyId { get; set; }
        public int GoodsStock { get; set; }
        public Guid TypeId { get; set; }
        public int StockYJ { get; set; }
        public DateTime UpTime { get; set; }
        public int GoodsState { get; set; }
        public string GoodsRule { get; set; }
        public string SKU { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string PriceId { get; set; }
        public string TypeName { get; set; }
        public decimal JinHPrice { get; set; }

    }
}
