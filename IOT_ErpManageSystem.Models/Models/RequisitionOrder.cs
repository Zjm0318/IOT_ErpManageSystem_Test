using System;
namespace IOT_ErpManageSystem.Models
{
    public class RequisitionOrder
    {
        //���
        public Guid QgId { get; set; }
        //�빺����Ϣid ���
        public Guid QId { get; set; }
        //״̬  0-������ 1-���ͨ�� 2-���δͨ��
        public string States { get; set; }
        //�빺������
        public Guid RId { get; set; }
        //�빺�����
        public string QGShr { get; set; }
        //��������
        public DateTime CreateDate { get; set; }
        //�빺��Ա
        public string QgName { get; set; }
        //Ա������
        public string Role_Name { get; set; }

    }
}
