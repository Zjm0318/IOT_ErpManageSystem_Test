using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class Order
	 {
		 public string  OrderId { get; set; }
		 public DateTime  SubmitTime { get; set; }
		 public DateTime  EndTime { get; set; }
		 public int  UId { get; set; }
		 public string  Linkman { get; set; }
		 public decimal  OrMoney { get; set; }
		 public string  Payment { get; set; }
		 public int  OrFrom { get; set; }
		 public int  OrState { get; set; }
	 }
}
