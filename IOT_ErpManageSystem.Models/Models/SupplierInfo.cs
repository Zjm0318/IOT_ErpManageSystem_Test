using System;
namespace IOT_ErpManageSystem.Models
{
    public class SupplierInfo
    {
        public Guid GysId { get; set; }
        public string YJfzr { get; set; }
        public string GID { get; set; }
        public string GLaiYuan { get; set; }
        public string DwName { get; set; }
        public string GDesc { get; set; }
        public string PinPai { get; set; }
        public string JYRange { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid LxrId { get; set; }
    }
}
