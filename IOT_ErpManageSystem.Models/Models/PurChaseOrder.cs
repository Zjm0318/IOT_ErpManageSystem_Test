using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class PurChaseOrder
	 {
		 public Guid  ID { get; set; }
		 public Guid  CID { get; set; }
		 public int  IsState { get; set; }
		 public string  CGClr { get; set; }
		 public string  CGShr { get; set; }
		 public string  CWShr { get; set; }
	 }
}
