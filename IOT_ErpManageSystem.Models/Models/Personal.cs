using System;
namespace IOT_ErpManageSystem.Models
{
    public class Personal
    {
        public Guid UID { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string IPhone { get; set; }
        public string Photo { get; set; }
        public int LoginNum { get; set; }
    }
}
