using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Brand
    {
        public int Id;
        public string Description;
        public override string ToString()
        {
            return Description;
        }
    }
}
