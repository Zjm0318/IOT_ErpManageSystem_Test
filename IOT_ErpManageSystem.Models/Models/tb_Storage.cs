using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class tb_Storage
	 {
		 public Guid  Id { get; set; }
		 public string  StorageName { get; set; }
		 public string  StorageLocation { get; set; }
		public string StorageMan { get; set; }


		public int Rid { get; set; }
		public int areaNum { get; set; }
		public int shelfNum { get; set; }
		public int seatNum { get; set; }
	}
}
