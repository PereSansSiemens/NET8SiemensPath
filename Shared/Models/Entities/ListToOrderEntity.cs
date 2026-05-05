using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Entities
{
    [Table("order_list_data", Schema = "PVS-BBDD")]
    public class ListToOrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("OriginalList")]
        public List<int> OriginalList { get; set; }
        [Column("OrderedList")]
        public List<int> OrderedList { get; set; }
        [Column("CreatedAt")]
        public DateTime Timestamp { get; set; }
    }
}
