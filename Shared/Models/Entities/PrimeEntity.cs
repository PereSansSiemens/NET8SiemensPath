using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Entities
{
    [Table("prime_number_verifier", Schema = "PVS-BBDD")]
    public class PrimeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Number")]
        public int Number { get; set; }
        [Column("IsPalindrome")]
        public bool IsPrime { get; set; }
        [Column("CreatedAt")]
        public DateTime Timestamp { get; set; }
    }
}
