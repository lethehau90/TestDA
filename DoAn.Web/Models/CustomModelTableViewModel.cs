using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Web.Models
{
    public class CustomModelTableViewModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Class { set; get; }
        public decimal? Price { set; get; }
        public string Address { set; get; }
        public string Note { set; get; }

        public string Appellation { set; get; }
        public int CountBook { set; get; }

        public DateTime? CreatedDate { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string CreatedBy { set; get; }
        public string UpdateBy { set; get; }
        public bool Status { set; get; }
    }
}