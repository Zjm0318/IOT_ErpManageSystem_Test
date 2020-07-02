using System;
namespace IOT_ErpManageSystem.Models
{
    public class GoodsPrice
    {
        public Guid PriceId { get; set; }
        public Guid Id { get; set; }
        public string GoodsId { get; set; }
        public string GoodsName { get; set; }
        public string GoodsBrand { get; set; }
        public string TypeId { get; set; }
        public string TypeName { get; set; }
        public string GoodsRule { get; set; }
        public string SKU { get; set; }
        public decimal GoodsPrices { get; set; }
        public decimal JinHPrice { get; set; }
    }
}
