using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class tb_InStorage
	 {
		 public Guid  Id { get; set; }
		 public DateTime  InStorageTime { get; set; }
		 public string  InStorageNo { get; set; }
		 public string  BuyListNo { get; set; }
		 public int  InStorageState { get; set; }
		 public int  InStorageType { get; set; }
		 public string  SupplierNo { get; set; }
		 public Guid  InThingStorage { get; set; }
		 public string  Consignee { get; set; }
		 public string  StorageMan { get; set; }
	 }
}
