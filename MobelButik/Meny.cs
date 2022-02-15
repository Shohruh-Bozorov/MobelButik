using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobelButik
{
    class Meny
    {
        // 3 val väljer om man är kund, admin, exit
        public static bool huvudMeny(bool quit)
        {
            Console.WriteLine("Huvudmeny");

            Console.WriteLine(
            "1 = Kund \n" +
            "2 = Admin \n" +
            "3 = Exit ");

            int val = Convert.ToInt32(Console.ReadLine());

            switch (val)
            {
                case 1:
                    //tar dig till kund meny
                    Console.Clear();
                    quit = KundMeny(false);
                    return quit;

                case 2:
                    //tar dig till admin meny
                    Console.Clear();
                    quit = AdminMeny(false);
                    return quit;

                case 3:
                    //exit
                    Console.Clear();
                    Console.WriteLine("Välkommen åter");
                    return true;

                default:
                    Console.Clear();
                    Console.WriteLine("Wrong input, try again!");
                    break;

            }

            return false;

        }

        //kundmeny
        public static bool KundMeny(bool quit)
        {

            Console.WriteLine("Kundmeny");

            Console.WriteLine(
            "1 = Visa alla produkter \n" +
            "2 = Visa köks produkter \n" +
            "3 = Visa Sovrums produkter \n" +
            "4 = Visa vardagrums produkter \n" +
            "5 = sök på en produkt \n" +
            "6 = Lägg till produkt i kundkorgen \n" +
            "7 = gå till kundkorgen \n" +
            "8 = gå tillbaka till huvud meny \n" +
            "9 = Exit ");

            int val = Convert.ToInt32(Console.ReadLine());

            switch (val)
            {
                case 1:
                    //visa alla produkter
                    Console.Clear();
                    Methods.GetProducts();
                    Console.WriteLine();
                    KundMeny(false);
                    break;

                case 2:
                    //visa köksprodukter
                    Console.Clear();
                    Methods.GetKitchenProducts();
                    Console.WriteLine();
                    KundMeny(false);

                    break;

                case 3:
                    //visa sovrumprodukter
                    Console.Clear();
                    Methods.GetBedroomProducts();
                    Console.WriteLine();
                    KundMeny(false);
                    break;

                case 4:
                    //visa vardagsrummsprodukter
                    Console.Clear();
                    Methods.GetLivingRoomProducts();
                    Console.WriteLine();
                    KundMeny(false);
                    break;

                case 5:
                    //fritextsöskning produkter
                    Console.Clear();
                    Methods.searchProduct();
                    Console.WriteLine();
                    KundMeny(false);
                    break;

                case 6:
                    //lägger till produkter till kundkorgen
                    Console.Clear();
                    Methods.GetProducts();
                    Methods.InsertToKundKorg();
                    Console.WriteLine();
                    KundMeny(false);
                    break;

                case 7:
                    //går till kundkorg
                    Console.Clear();
                    quit = kundKorg(false);
                    return quit;

                case 8:
                    //tillbaka till huvud meny
                    Console.Clear();
                    quit = huvudMeny(false);
                    return quit;

                case 9:
                    //exit
                    Console.Clear();
                    Console.WriteLine("Välkommen åter");
                    return true;

                default:
                    Console.Clear();
                    Console.WriteLine("Wrong input, try again!");
                    KundMeny(false);
                    break;
            }

            return false;
        }

        //admin meny
        public static bool AdminMeny(bool quit)
        {
            Console.WriteLine(
            "1 = Visa produkt \n" +
            "2 = Visa kategori \n" +
            "3 = Lägg till produkt \n" +
            "4 = Lägg till kategori \n" +
            "5 = Ta bort produkt \n" +
            "6 = Ta bort kategori \n" +
            "7 = Visa orderhistorik \n" +
            "8 = Visa kunder \n" +
            "9 = Till huvudmeny \n" +
            "10 = Exit");

            int val = Convert.ToInt32(Console.ReadLine());
            switch (val)
            {
                case 1:
                    //visar produkter
                    Console.Clear();
                    Methods.GetProducts();
                    AdminMeny(false);
                    break;

                case 2:
                    //visar kategorier
                    Console.Clear();
                    Methods.GetCategories();
                    AdminMeny(false);
                    break;

                case 3:
                    //kunna lägga till produkt
                    Console.Clear();
                    Methods.GetProducts();
                    Methods.InsertProdukt();
                    AdminMeny(false);
                    break; 

                case 4:
                    Console.Clear();
                    Methods.GetCategories();
                    Methods.InsertCategory();
                    AdminMeny(false);
                    break;

                case 5:
                    //kunna ta bort produkt
                    Console.Clear();
                    Console.WriteLine();
                    Methods.GetProducts();
                    Methods.DeleteProdukt();
                    AdminMeny(false);
                    break;

                case 6:
                    Console.Clear();
                    Methods.GetCategories();
                    Methods.DeleteCategory();
                    AdminMeny(false);
                    break;

                case 7:
                    //se orderhistorik
                    Console.Clear();
                    Methods.ShowOrderHistorik();
                    AdminMeny(false);
                    break;

                case 8:
                    Console.Clear();
                    Methods.GetKund();
                    AdminMeny(false);
                    break;

                case 9:
                    //tillbaka till huvud meny
                    Console.Clear();
                    quit = huvudMeny(false);
                    return quit;

                case 10:
                    //exit
                    Console.Clear();
                    Console.WriteLine("Välkommen åter");
                    return true;

                default:
                    Console.Clear();
                    Console.WriteLine("Wrong input, try again!");
                    AdminMeny(false);
                    break;

            }

            return false;
        }

        //Kundkorg
        public static bool kundKorg(bool quit)
        {

            Methods.GetKundKorgProducts();
            Console.WriteLine("-----------------------------");

            Console.WriteLine(
            "1 = Köp valda produkter \n" +
            "2 = Ta bort från kundkorgen \n" +
            "3 = Töm kundkorgen \n" +
            "4 = Till huvudmeny \n" +
            "5 = Exit");

            int val = Convert.ToInt32(Console.ReadLine());

            switch (val)
            {
                case 1:
                    //Gå vidare/köpa produkter
                    Console.Clear();
                    Methods.InsertCustomer();

                    Methods.GetLeveransAlt();
                    Console.WriteLine("Välj en leverans alternativ, skriv in ett nummer:");
                    int levAlt = Convert.ToInt32(Console.ReadLine());

                    Methods.GetBetalningAlt();
                    Console.WriteLine("Välj en betalning alternativ, skriv in ett nummer:");
                    int betAlt = Convert.ToInt32(Console.ReadLine());

                    Methods.LeveransBekräftelse();
                    Methods.AddToOrderHistroik();
                   
                    Methods.EmptyCart();
                    kundKorg(false);
                    break;

                case 2:
                    //ta bort produkt från kundkorgen
                    Console.Clear();
                    Methods.DeleteFromKundKorg();
                    kundKorg(false);
                    break;                
                
                case 3:
                    //tömer kundkorgen
                    Console.Clear();
                    Methods.EmptyCart();
                    break;

                case 4:
                    // gå till huvudmeny
                    Console.Clear();
                    quit = huvudMeny(false);
                    return quit;

                case 5:
                    //exit
                    Console.Clear();
                    Console.WriteLine("Välkommen åter");
                    return true;

                default:
                    Console.Clear();
                    Console.WriteLine("Wrong input, try again!");
                    AdminMeny(false);
                    break;
            }

            return false;

        }
    }
}
