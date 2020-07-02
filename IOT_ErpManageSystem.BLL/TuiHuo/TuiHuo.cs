using System;

namespace IOT_ErpManageSystem.BLL.TuiHuo
{
    public class TuiHuo
    {
        public DateTime CreateTime { get; set; }
        public DateTime TuiHuoTime { get; set; }
        public Guid ID { get; set; }
        public string States { get; set; }
        public string DwName { get; set; }
        public string THFqr { get; set; }
        public string StorageName { get; set; }
        public string LxrName { get; set; }
    }
}
