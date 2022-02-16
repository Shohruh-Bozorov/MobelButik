using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using MobelButik;


namespace MobelButik
{
    class Methods
    {
        public static void GetProducts()
        {
            Console.WriteLine($"ID \t Namn \t\t Pris ");
            using (var db = new MobelButik.Models.NewtonContext())
            {
                var product = db.Produkts;
                foreach (var item in product)
                {

                    Console.WriteLine($"{item.Id,-8} {item.ProduktNamn,-15} {item.Pris}");
                }
            }
        }
        public static void GetCategories()
        {
            using (var db = new MobelButik.Models.NewtonContext())
            {
                var category = db.Kategoris;
                foreach (var item in category)
                {
                    Console.WriteLine(item.Id + "\t" + item.Namn);
                }
            }
        }

        public static void GetKundKorg()
        {
            using (var db = new MobelButik.Models.NewtonContext())
            {
                var kundKorg = db.Kundkorgs;
                Console.WriteLine("Id");
                foreach (var item in kundKorg)
                {
                    Console.WriteLine(item.ProduktId);
                }
            }
        }

        public static void GetKund()
        {
            using (var db = new MobelButik.Models.NewtonContext())
            {
                var kund = db.Kunds;
                foreach (var item in kund)
                {
                    Console.WriteLine(item.Id + "\t" + item.Förnamn + "\t" + item.Efternamn);
                }
            }
        }

        public static void GetBetalningAlt()
        {
            using (var db = new MobelButik.Models.NewtonContext())
            {
                var bAlt = db.BetalningsAlternativs;
                foreach (var item in bAlt)
                {
                    Console.WriteLine(item.Id + "\t" + item.Namn);
                }
            }
        }

        public static void GetLeveransAlt()
        {
            using (var db = new MobelButik.Models.NewtonContext())
            {
                var lAlt = db.LeveransAlternativs;
                foreach (var item in lAlt)
                {
                    Console.WriteLine(item.Id + "\t" + item.Namn + "\t" + item.Pris);
                }
            }
        }




        public static void GetKitchenProducts()
        {

            Console.WriteLine($"ID \t Namn \t\t Pris ");
            using (var db = new MobelButik.Models.NewtonContext())
            {
                var result = from
                             Produkts in db.Produkts
                             where Produkts.KategoriId == 1
                             select new Queries { ProduktName = Produkts.ProduktNamn, ProduktPris = (double)Produkts.Pris, ProduktId = Produkts.Id };
                //group Produkts by Produkts.ProduktNamn;

                foreach (var product in result)
                {
                    Console.WriteLine($"{product.ProduktId,-8} {product.ProduktName,-15} {product.ProduktPris}");
                }


            }
        }

        public static void GetBedroomProducts()
        {
            Console.WriteLine($"ID \t Namn \t\t Pris ");

            using (var db = new MobelButik.Models.NewtonContext())
            {
                var result = from
                             Produkts in db.Produkts
                             where Produkts.KategoriId == 2
                             select new Queries { ProduktName = Produkts.ProduktNamn, ProduktPris = (double)Produkts.Pris, ProduktId = Produkts.Id };
                //group Produkts by Produkts.ProduktNamn;

                foreach (var product in result)
                {
                    Console.WriteLine($"{product.ProduktId,-8} {product.ProduktName,-15} {product.ProduktPris}");
                }


            }
        }

        public static void GetLivingRoomProducts()
        {

            Console.WriteLine($"ID \t Namn \t\t Pris ");
            using (var db = new MobelButik.Models.NewtonContext())
            {
                var result = from
                             Produkts in db.Produkts
                             where Produkts.KategoriId == 3
                             select new Queries { ProduktName = Produkts.ProduktNamn, ProduktPris = (double)Produkts.Pris, ProduktId = Produkts.Id };
                //group Produkts by Produkts.ProduktNamn;

                foreach (var product in result)
                {
                    Console.WriteLine($"{product.ProduktId,-8} {product.ProduktName,-15} {product.ProduktPris}");
                }


            }


        }

        public static int InsertProdukt()
        {
            var affectedRows = 0;

            var connString = "Server=tcp:mobelbutik.database.windows.net,1433;Initial Catalog=Newton;Persist Security Info=False;User ID=vidrusen;Password=troll100!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var produkt = new MobelButik.Models.Produkt();
            produkt = AddProdukt();
            var sql = $"Insert into Produkt(Id, ProduktNamn, TillverkareId, KategoriId, Färg, Material, Pris) values('{produkt.Id}', '{produkt.ProduktNamn}', '{produkt.TillverkareId}', '{produkt.KategoriId}', '{produkt.Färg}', '{produkt.Material}', '{produkt.Pris}')";


            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                    Console.WriteLine("Din produkt blev tillagd");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return affectedRows;

        }

        public static MobelButik.Models.Produkt AddProdukt()
        {



            Console.WriteLine("Skriv in id");
            int prduktId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Skriv in namn");
            string namn = Console.ReadLine();

            Console.WriteLine(
            "Skriv in tillverkarID\n" +
            "1 = Ikea \n" +
            "2 = Mio \n" +
            "3 = FCompany \n" +
            "4 = testTable");
            int tillVerkareID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(
            "Skriv in kategoriID\n" +
            "1 = kök \n" +
            "2 = Sovrum \n" +
            "3 = vardagsrum \n" +
            "4 = Badrum");
            int kategoriID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(
            "Skriv in materialID\n" +
            "1 = Trä \n" +
            "2 = Metall \n" +
            "3 = Plast \n" +
            "4 = Blandat\n" +
            "5 = Bomull");
            int materialID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(
            "Skriv in färgID\n" +
            "1 = Svart \n" +
            "2 = Brun \n" +
            "3 = Vit \n" +
            "4 = Blå\n" +
            "5 = Grön \n" +
            "6 = Gul \n" +
            "7 = Röd \n" +
            "8 = Ofärgat");
            int färgID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Skriv in pris (ex: 150.50)");
            //float pris = float.Parse(Console.ReadLine());
            bool result = float.TryParse(Console.ReadLine(), out float pris);

            var newProdukt = new MobelButik.Models.Produkt()
            {
                Id = prduktId,
                ProduktNamn = namn,
                TillverkareId = tillVerkareID,
                KategoriId = kategoriID,
                Färg = färgID,
                Material = materialID,
                Pris = pris
            };

            return newProdukt;
        }

        public static int DeleteProdukt()
        {
            Console.WriteLine("Vilken produkt vill du ta bort? Skriv in id");
            var deleteId = Convert.ToInt32(Console.ReadLine());
            var affectedRows = 0;

            //var connString = "data source=.\\SQLEXPRESS; initial catalog=MöbelButik; persist security info=true; Integrated Security=true";
            var connString = "Server=tcp:mobelbutik.database.windows.net,1433;Initial Catalog=Newton;Persist Security Info=False;User ID=vidrusen;Password=troll100!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";



            var sql = $" DELETE FROM Produkt WHERE id = {deleteId} ";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                    Console.WriteLine("Din produkt blev borttagen");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return affectedRows;

        }

        public static MobelButik.Models.Kategori AddCategory()
        {

            Console.WriteLine("Skriv in id");
            int kategoriId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Skriv in namn");
            string kategoriNamn = Console.ReadLine();

            var newCategory = new MobelButik.Models.Kategori()
            {
                Id = kategoriId,
                Namn = kategoriNamn

            };

            return newCategory;
        }

        public static int InsertCategory()
        {
            var affectedRows = 0;

            var connString = "Server=tcp:mobelbutik.database.windows.net,1433;Initial Catalog=Newton;Persist Security Info=False;User ID=vidrusen;Password=troll100!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var category = new MobelButik.Models.Kategori();
            category = AddCategory();
            var sql = $"Insert into Kategori(Id, Namn) values('{category.Id}', '{category.Namn}')";


            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                    Console.WriteLine("Din kategori blev tillagd");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }


            return affectedRows;

        }

        public static int DeleteCategory()
        {
            Console.WriteLine("Vilken kategori vill du ta bort? Skriv in id");
            var deleteId = Convert.ToInt32(Console.ReadLine());
            var affectedRows = 0;

            //var connString = "data source=.\\SQLEXPRESS; initial catalog=MöbelButik; persist security info=true; Integrated Security=true";
            var connString = "Server=tcp:mobelbutik.database.windows.net,1433;Initial Catalog=Newton;Persist Security Info=False;User ID=vidrusen;Password=troll100!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";



            var sql = $" DELETE FROM Kategori WHERE id = {deleteId} ";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                    Console.WriteLine("Din kategori blev borttagen");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return affectedRows;

        }


        public static void searchProduct()
        {
            Console.WriteLine("Skriv in den produkt du vill söka efter");
            var search = Console.ReadLine();

            using (var db = new MobelButik.Models.NewtonContext())
            {
                var products = db.Produkts;
                var searchProd = products.Where(find => find.ProduktNamn.Contains(search));

                Console.WriteLine("--------------------------");

                foreach (var prod in searchProd)
                {
                    Console.WriteLine($"{prod.Id,-5} {prod.ProduktNamn,-25} {prod.Pris} kr");
                }
                Console.WriteLine("--------------------------");
            }



        }

        public static int InsertToKundKorg()
        {
            var affectedRows = 0;

            Console.WriteLine("Skriv in ID på den produkt du vill lägga till");
            var idToAdd = Convert.ToInt32(Console.ReadLine());

            var connString = "Server=tcp:mobelbutik.database.windows.net,1433;Initial Catalog=Newton;Persist Security Info=False;User ID=vidrusen;Password=troll100!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var sql = $" insert into Kundkorg select id from Produkt WHERE id = {idToAdd}";


            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                    Console.WriteLine("Din vara finns nu på kundkorgen");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return affectedRows;
        }

        public static int DeleteFromKundKorg()
        {
            var affectedRows = 0;

            Console.WriteLine("Skriv in ID på den produkt du vill ta bort från kundkorgen");
            var id = Convert.ToInt32(Console.ReadLine());

            var connString = "Server=tcp:mobelbutik.database.windows.net,1433;Initial Catalog=Newton;Persist Security Info=False;User ID=vidrusen;Password=troll100!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var sql = $"delete from kundkorg WHERE ProduktID = {id};";


            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                    Console.WriteLine($"Din produkt med id: {id} är nu borttagen från kundkorgen");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return affectedRows;
        }

        public static MobelButik.Models.Kund AddCustomer()
        {
            var connString = "Server=tcp:mobelbutik.database.windows.net,1433;Initial Catalog=Newton;Persist Security Info=False;User ID=vidrusen;Password=troll100!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var sql = $"select COUNT(id) as 'AntalKunder' from Kund";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                /*try
                {
                    var num = connection.Query<int>(sql);
                    //Console.WriteLine(num.AsList()[0]);
                    int kundId = num.AsList()[0];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }*/


                var num = connection.Query<int>(sql);
                int kundId = num.AsList()[0] + 1;





                Console.WriteLine("Skriv in förnamn");
                string fnamn = Console.ReadLine();

                Console.WriteLine("Skriv in efternamn");
                string enamn = Console.ReadLine();

                Console.WriteLine("Skriv in gatunamn");
                string adress = Console.ReadLine();

                Console.WriteLine("Skriv in ort");
                string ort = Console.ReadLine();

                Console.WriteLine("Skriv in postnummer");
                int postnr = Convert.ToInt32(Console.ReadLine());


                var newCustomer = new MobelButik.Models.Kund()
                {
                    Id = kundId,
                    Förnamn = fnamn,
                    Efternamn = enamn,
                    Adress = adress,
                    Ort = ort,
                    Postnummer = postnr
                };

                return newCustomer;
            }
        }

        public static int InsertCustomer()
        {
            var affectedRows = 0;

            var connString = "Server=tcp:mobelbutik.database.windows.net,1433;Initial Catalog=Newton;Persist Security Info=False;User ID=vidrusen;Password=troll100!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var customer = new MobelButik.Models.Kund();
            customer = AddCustomer();
            var sql = $"insert into Kund(Id, Förnamn, Efternamn, Adress, Ort, Postnummer) values({customer.Id}, '{customer.Förnamn}','{customer.Efternamn}','{customer.Adress}','{customer.Ort}',{customer.Postnummer})";


            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                    Console.WriteLine("Du är nu kund hos oss!");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return affectedRows;



        }

        public static void EmptyCart()
        {

            var connString = "Server=tcp:mobelbutik.database.windows.net,1433;Initial Catalog=Newton;Persist Security Info=False;User ID=vidrusen;Password=troll100!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var sql = $"delete from Kundkorg";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {

                    connection.Execute(sql);
                    Console.WriteLine("Kundkorgen har tömts!");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }

        public static void LeveransBekräftelse()
        {
            Console.WriteLine("Din order är nu påväg till dig");
            var rnd = new Random();
            int orderNummer = rnd.Next(100000, 999999);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Ditt order nhummer är: {orderNummer}");
        }
        public static void GetKundKorgProducts()
        {
            using (var db = new MobelButik.Models.NewtonContext())
            {

                Console.WriteLine("KundKorg:");

                var data = (from k in db.Kundkorgs
                            join p in db.Produkts
                            on k.ProduktId equals p.Id
                            select new
                            {
                                Id = k.ProduktId,
                                Namn = p.ProduktNamn,
                                Pris = p.Pris

                            }).ToList();


                foreach (var prod in data)
                {
                    Console.WriteLine($"{prod.Id,-5} {prod.Namn,-10} {prod.Pris}");
                }

            }
        }

        public static void AddToOrderHistroik()
        {
            using (var db = new MobelButik.Models.NewtonContext())
            {
                var data = (from korg in db.Kundkorgs
                            select new { Produkt = korg.ProduktId }).ToList();
                var connString = "Server=tcp:mobelbutik.database.windows.net,1433;Initial Catalog=Newton;Persist Security Info=False;User ID=vidrusen;Password=troll100!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                var sql = $"select COUNT(id) as 'AntalKunder' from Kund";

                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();

                    var num = connection.Query<int>(sql);
                    int kundId = num.AsList()[0];




                    foreach (var prod in data)
                    {
                        var sql2 = $"select COUNT(id) as 'AntalID' from OrderHistorik";
                        var num1 = connection.Query<int>(sql2);
                        int OHId = num1.AsList()[0] + 1;
                        var sql1 = $"insert into OrderHistorik values ({OHId}, {kundId}, {prod.Produkt})";
                        connection.Execute(sql1);

                    }
                }
            }
        }
        public static void ShowOrderHistorik()
        {
            Console.WriteLine($"KundID \t ProductID");
            using (var db = new MobelButik.Models.NewtonContext())
            {
                var result = from
                             orderHistorik in db.OrderHistoriks
                             select new { KundID = orderHistorik.KundId, ProduktId = orderHistorik.ProduktId };

                foreach (var product in result)
                {
                    Console.WriteLine($"{product.KundID,-8} {product.ProduktId,-15}");
                }


            }
        }

    }
}
