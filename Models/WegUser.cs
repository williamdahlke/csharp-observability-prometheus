using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfPocAPI.Models
{
    public class WegUser
    {
        public WegUser(string name, string unity)
        {
            Name = name;
            Unity = unity;
        }

        public string Name { get; set; }
        public string Unity { get; set; }
    }
}
