using System;
 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {



            var lst = new List<double>();

            lst.Add(2);
            lst.Add(22);
            lst.Add(222);
            //lst.AddToStart(3);

            //lst.RemoveAt(lst.Count-1);



            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }



            //lst.WriteToConsole();

            Console.ReadLine();

        }
    }
}
