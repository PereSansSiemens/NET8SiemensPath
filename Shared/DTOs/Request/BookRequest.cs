using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Request
{
    public class BookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageNum { get; set; }
    }
}
