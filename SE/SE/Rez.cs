using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE
{
    class Rez
    {
        String name;
        String sub;
        int assessment;

        public string Name { get => name; set => name = value; }
        public string Sub { get => sub; set => sub = value; }
        public int Assessment { get => assessment; set => assessment = value; }

        public Rez()
        {
        }

        public Rez(string name, string sub, int assessment)
        {
            this.name = name;
            this.sub = sub;
            this.assessment = assessment;
        }

    }
}
