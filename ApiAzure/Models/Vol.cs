using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAzure.Models
{
    public class Vol
    {
        public int ID { get; set; }
        public string numVol { get; set; }
        public string code_comp { get; set; }
        public string numAvion { get; set; }
        public string dep { get; set; }
        public string arr { get; set; }
        public string  statu { get; set; }
    }
}
