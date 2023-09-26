using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetURL
{
    internal class Main
    {

        public static void mainTask()
        {
            Console.WriteLine("Please enter the URL: ");
            String URL = Console.ReadLine();
            Application app = new Application();
            Console.WriteLine("Entered URL: " + URL);
            app.GetList(URL);
            // Now you can use subURL in other methods or parts of your program
           
        }
    }
}
