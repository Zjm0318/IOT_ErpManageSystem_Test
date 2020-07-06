using System;
namespace IOT_ErpManageSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public DateTime SubmitTime { get; set; }
        public string UId { get; set; }
        public string OrMoney { get; set; }
        public string Payment { get; set; }
        public int OrFrom { get; set; }
        public int OrState { get; set; }
        public int State { get; set; }

        public string UserName { get; set; }
        public string FromName { get; set; }
        public string StateName { get; set; }
        public string Time { get; set; }


    }
}
