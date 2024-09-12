using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfPocAPI.Models.Enums;

namespace wpfPocAPI.Models
{
    public class WegUnity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public WegUnities Unity { get; set; }
    }
}
