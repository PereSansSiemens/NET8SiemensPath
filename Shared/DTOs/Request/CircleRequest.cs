using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Request
{
    public class CircleRequest
    {
        public double Radius { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}
