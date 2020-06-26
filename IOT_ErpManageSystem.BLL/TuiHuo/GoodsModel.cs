using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_ErpManageSystem.BLL.TuiHuo
{
    public class GoodsModel
    {
        public Guid PriceId { get; set; }
        public string GoodsId { get; set; }
        public string GoodsName { get; set; }
        public string GoodsRule { get; set; }
        public string SKU { get; set; }
        public decimal JinHPrice { get; set; }
        public int GoodsStock { get; set; }
    }
}
