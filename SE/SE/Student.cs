using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE
{
    class Student
    {
        String name;
        String numZK;
        String facul;
        String group;

        RezDB rezult;

        public string Name { get => name; set => name = value; }
        public string NumZK { get => numZK; set => numZK = value; }
        public string Facul { get => facul; set => facul = value; }
        public string Group { get => group; set => group = value; }
        internal RezDB Rezult { get => rezult; set => rezult = value; }

        public Student()
        {

        }
        public Student(string name,string numZK,string facul,string group, RezDB rezult)
        {
            this.name = name;
            this.numZK = numZK;
            this.facul = facul;
            this.group = group;
            this.rezult = rezult;
        }
    }
}
