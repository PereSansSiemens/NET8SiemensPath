using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Response
{
    public class CircleResponse
    {
        public double CircleArea { get; set; }
        public double CirclePerimeter { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}
