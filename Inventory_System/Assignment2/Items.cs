using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment2
{
    class Items
    {
        
        public string Name;
        public int Code;
        public int Rate;
        public int Stock;
        public int Lead;
        public Items(string nm, int cd, int rt, int st, int ld)
        {
            Name = nm;
            Code = cd;
            Rate = rt;
            Stock = st;
            Lead = ld;
        }
        public void PrintRow()
        {
            Console.WriteLine("{0,-20}{1,6}{2,6}{3,7}{4,6}",
                Name,Code,Rate,Stock,Lead);
        }
        public void PrintHeader()
        {
            Console.WriteLine("{0,-20}{1,6}{2,6}{3,7}{4,6}",
                "Name", "Code", "Rate", "Stock", "Lead");
        }
        public void PrintHeaderUnit()
        {
            Console.WriteLine("{0,-20}{1,6}{2,6}{3,7}{4,6}{5,6}", 
                "Name", "Code", "Rate", "Stock", "Lead", "Unit");
        }

    }
}
