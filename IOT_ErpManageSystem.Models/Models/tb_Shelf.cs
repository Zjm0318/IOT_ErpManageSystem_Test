using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_ErpManageSystem.Models
{
    public class tb_Shelf
    {
        public Guid Id { get; set; }
        public string ShelfName { get; set; }
        public string AreaId { get; set; }
        public string ShelfNo { get; set; }
        public string StorageId { get; set; }
    }
}
