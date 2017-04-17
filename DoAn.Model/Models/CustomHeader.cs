using DoAn.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Model.Models
{
    [Table("CustomHeaders")]
    public class CustomHeader : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(50)]
        public string Type { set; get; }
        [MaxLength(50)]
        public string Color { set; get; }
        public string Content { set; get; }
    }
}
