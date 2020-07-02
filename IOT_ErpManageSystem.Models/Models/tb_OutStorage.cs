using System;
namespace IOT_ErpManageSystem.Models
{
    public class tb_OutStorage
    {
        public Guid Id { get; set; }
        public DateTime OutTime { get; set; }
        public string OrderNo { get; set; }
        public string OStorageNo { get; set; }
        public string DispatchingId { get; set; }
        public string Consignee { get; set; }
        public string CPhoneNum { get; set; }
        public string DispatchingArea { get; set; }
        public string OutStorageId { get; set; }
        public string DBMan { get; set; }
        public int OutState { get; set; }


        public string StorageMan { get; set; }
        public string Dispatching { get; set; }
        public string StorageName { get; set; }
    }
}
