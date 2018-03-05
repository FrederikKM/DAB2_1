using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABHandin2._1
{
    class Country
    {
        public List<Adress> Adresses { get; set; }

        public Country(List<Adress> adresses)
        {
            Adresses = adresses;
        }
    }
}
