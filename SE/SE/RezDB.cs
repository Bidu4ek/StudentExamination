using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE
{
    class RezDB
    {
        List<Rez> rb;

        public RezDB()
        {
            Rb = new List<Rez>();
        }

        internal List<Rez> Rb { get => rb; set => rb = value; }
    }
}
