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
    [Table("Laudatories")]
    public class Laudatory : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        public string Class { set; get; }
        public string Appellation { set; get; }
        public int CountBook { set; get; }
        public string Note { set; get; }
    }
}
