using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Model.Abstract;

namespace DoAn.Model.Models
{
    [Table("Donations")]
    public class Donation  : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        public string Class { set; get; }
        public decimal? Price { set; get; }
        public  string Address { set; get; }
        public string Note { set; get; }

    }
}
