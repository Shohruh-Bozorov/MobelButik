using System;

namespace MobelButik
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen Till vår Webbshop!");

            Console.WriteLine("__________________________________________");
            bool quit = false;
            while (quit == false)
            {
                quit = Meny.MenyVal(quit);
            }

        }
    }
}
