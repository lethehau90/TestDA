using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Web.Models
{
    public class CustomHeaderViewModel
    {
        public int ID { set; get; }
        public string Type { set; get; }
        public string Color { set; get; }
        public string Content { set; get; }

        public DateTime? CreatedDate { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string CreatedBy { set; get; }
        public string UpdateBy { set; get; }
        public bool Status { set; get; }
        public int PaddingTop { set; get; }
        public int Height { set; get; }
    }
}