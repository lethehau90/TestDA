using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Web.Models
{
    public class CustomImageViewModel
    {
        public int ID { set; get; }
        public string Type { set; get; }
        public string Images { set; get; }

        public DateTime? CreatedDate { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string CreatedBy { set; get; }
        public string UpdateBy { set; get; }
        public bool Status { set; get; }
        public string BgColor { set; get; }
        public int Height { set; get; }
    }
}