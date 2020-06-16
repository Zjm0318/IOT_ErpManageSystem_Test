using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class GoodsProperty
	 {
		 public Guid  Id { get; set; }
		 public Guid  GoodsId { get; set; }
		 public string  Color { get; set; }
		 public string  Size { get; set; }
	 }
}
