using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Entities
{
    [Table("palindrome_verifier", Schema = "PVS-BBDD")]
    public class PalindromeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Word")]
        public string Word { get; set; }
        [Column("IsPalindrome")]
        public bool IsPalindrome { get; set; }
        [Column("CreatedAt")]
        public DateTime Timestamp { get; set; }
    }
}
