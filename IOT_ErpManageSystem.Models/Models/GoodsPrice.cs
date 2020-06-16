using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class GoodsPrice
	 {
		 public Guid  PriceId { get; set; }
		 public string  GoodsId { get; set; }
		 public string  GoodsName { get; set; }
		 public string  GoodsBrand { get; set; }
		 public string  GoodsType { get; set; }
		 public string  GoodsRule { get; set; }
		 public string  GoodsUnit { get; set; }
		 public decimal  SellPrice { get; set; }
		 public decimal  JinHPrice { get; set; }
	 }
}
