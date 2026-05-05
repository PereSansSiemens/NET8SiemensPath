using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Entities
{
    [Table("triangle_data", Schema = "PVS-BBDD")]
    public class TriangleEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Base")]
        public float Base { get; set; }
        [Column("Height")]
        public float Height { get; set; }
        [Column("Area")]
        public float Area { get; set; }
        [Column("CreatedAt")]
        public DateTime Timestamp { get; set; }
    }
}
