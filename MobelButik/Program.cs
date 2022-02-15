using Dapper;
using System;
using System.Data.SqlClient;

namespace MobelButik
{
    class Program
    {
        static void Main(string[] args)
        {
            var connString = "Server=tcp:mobelbutik.database.windows.net,1433;Initial Catalog=Newton;Persist Security Info=False;User ID=vidrusen;Password=troll100!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var sql = $"select COUNT(id) as 'Antal färger' from Färg";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    var num = connection.Query<int>(sql);
                    Console.WriteLine(num.AsList()[0]);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }



            }

            /*using (var db = new MobelButik.Models.NewtonContext())
            {


                var data = (from f in db.Färgs
                            
                            select new
                            {
                                Antal = f.Count()

                            }).ToList();


                foreach (var prod in data)
                {
                    Console.WriteLine($"{prod.Id,-5} {prod.Namn,-10} {prod.Pris}");
                }

            }*/
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
