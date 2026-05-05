using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Book
    {
        public int Isbn { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int PageNum { get; set; }
    }
}
