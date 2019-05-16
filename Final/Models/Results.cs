using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Models
{
    public partial class Results
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Cpu { get; set; }
        public string Result { get; set; }
    }
}
