using Dapper;
using System;
using System.Data.SqlClient;

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
                quit = Meny.huvudMeny(quit);
            }
        }
    }
}
