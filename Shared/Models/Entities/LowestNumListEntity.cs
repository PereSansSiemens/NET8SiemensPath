using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Entities
{
    [Table("lowest_num_list", Schema = "PVS-BBDD")]
    public class LowestNumListEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("OriginalList")]
        public List<int> OriginalList { get; set; }
        [Column("LowestNumber")]
        public int LowestNumber { get; set; }
        [Column("CreatedAt")]
        public DateTime Timestamp { get; set; }
    }
}
