using System;
namespace IOT_ErpManageSystem.Models
{
    public class RequisitionInfo
    {
        //���
        public Guid QgId { get; set; }
        //�빺��ϢID
        public Guid QId { get; set; }
        //��������
        public DateTime CreateDate { get; set; }
        //������ַ
        public string DhAddress { get; set; }
        //�빺��Ա
        public string QgName { get; set; }
        //���ڲ���
        public string DeptName { get; set; }
    }
}
