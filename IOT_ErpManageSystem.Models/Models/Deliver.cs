using System;
namespace IOT_ErpManageSystem.Models
{
    public class Deliver
    {
        public Guid ArtNo { get; set; }
        public string ProName { get; set; }
        public decimal Price { get; set; }
        public string Property { get; set; }
        public int Number { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Postage { get; set; }
        public string Payment { get; set; }
    }
}
