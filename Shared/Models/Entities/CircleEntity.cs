using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Entities
{
    [Table("circle_data", Schema = "PVS-BBDD")]
    public class CircleEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Radius")]
        public double Radius { get; set; }
        [Column("Color")]
        public string Color { get; set; }
        [Column("Perimeter")]
        public double Perimeter { get; set; }
        [Column("Area")]
        public double Area { get; set; }
        [Column("CreatedAt")]
        public DateTime Timestamp { get; set; }
    }
}
