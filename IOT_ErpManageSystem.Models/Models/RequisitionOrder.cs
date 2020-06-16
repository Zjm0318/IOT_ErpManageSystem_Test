using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class RequisitionOrder
	 {
		 public Guid  QgId { get; set; }
		 public Guid  QId { get; set; }
		 public Guid  SId { get; set; }
		 public int  Num { get; set; }
		 public int  States { get; set; }
	 }
}
