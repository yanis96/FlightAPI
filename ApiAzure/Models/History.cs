using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAzure.Models
{
    public class History
    {
        public int ID { get; set; }
        public string numVol { get; set; }
        public string dateHist { get; set; }
        public float lat { get; set; }
        public float longe { get; set; }
        public int speed { get; set; }
    }
}