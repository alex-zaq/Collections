using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {


            var lst = new List<int>();

            lst.Add(2);
            lst.Add(22);
            lst.Add(222);
            lst.Add(2222);
            lst.Add(22222);


            foreach (var item in lst)
            {

                Console.WriteLine(item);

            }




            Console.ReadLine();

        }
    }
}
