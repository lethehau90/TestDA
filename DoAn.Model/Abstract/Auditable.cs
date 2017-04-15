using System;

namespace DoAn.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { set; get; }
        DateTime? UpdateDate { set; get; }
        string CreatedBy { set; get; }
        string UpdateBy { set; get; }
        bool Status { set; get; }
    }

    public class Auditable : IAuditable
    {
        public DateTime? CreatedDate { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string CreatedBy { set; get; }
        public string UpdateBy { set; get; }
        public bool Status { set; get; }
    }
}