using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_ErpManageSystem.Models.Models
{
  public  class RequPurGood
    {
        public int RPGID { get; set; }
        //请购单ID 采购单ID
        public Guid QPId { get; set; }
        //商品ID
        public Guid GId { get; set; }
        //购买数量
        public int BuyNum { get; set; }
        //可用数量
        public int KYNum { get; set; }
    }
}
