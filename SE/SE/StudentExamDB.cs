using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE
{
    class StudentExamDB
    {
        List<Student> db;

        public StudentExamDB()
        {
            Db = new List<Student>();
        }

        internal List<Student> Db { get => db; set => db = value; }
    }
}
