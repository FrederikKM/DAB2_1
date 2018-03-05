using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABHandin2._1
{
    class HelpClass
    {
        public String Type { get; set; }
        public Adress Adress { get; set; }

        public HelpClass(Adress adress, String type)
        {
            Type = type;
            Adress = adress;
        }
    }
}
