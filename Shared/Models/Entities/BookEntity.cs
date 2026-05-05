using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Entities
{
    [Table("book_data", Schema = "PVS-BBDD")]
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Title")]
        public string Title { get; set; }
        [Column("Author")]
        public string Author { get; set; }
        [Column("PageNum")]
        public int PageNum { get; set; }
        [Column("CreatedAt")]
        public DateTime Timestamp { get; set; }
    }
}
