using System;

namespace IOT_ErpManageSystem.Models
{
    public class ISMShowModel
    {
        public Guid Id { get; set; }
        public string InStorageTime { get; set; }
        public string InStorageNo { get; set; }
        public string BuyListNo { get; set; }
        public string InStorageState { get; set; }
        public string InStorageType { get; set; }
        public string StorageName { get; set; }
        public string Consignee { get; set; }
        public string StorageMan { get; set; }
        public string GID { get; set; }
    }
}
