using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobelButik
{
    class Meny
    {

        public static bool huvudMeny(bool quit) // 3 val väljer om man är kund elle admin eller exit , 3 val
        {

            Console.WriteLine("Huvudmeny");
            Console.WriteLine(
                "1 = Kundmeny \n" +
                "2 = admin meny \n" +
                "3 = Exit \n" +
                "Mata in ett nummer.");

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
                    AdminMeny(false);
                    break;

                case 3:
                    //exit
                    return true;

                default:
                    Console.WriteLine("Wrong input");
                    break;

            }

            return false;

        }

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
        "7 = gå tillbaka till huvud meny \n" +
        "Mata in ett nummer.");

            int val = Convert.ToInt32(Console.ReadLine());
            switch (val)
            {
                case 1:
                    //visa alla produkter
                    Console.Clear();
                    Methods.GetProducts();

                    Console.WriteLine("\n");
                        KundMeny(false);
                    break;

                case 2:
                    //visa köksprodukter
                     Methods.GetKitchenProducts();
                   
                    break;

                case 3:
                    //visa sovrumprodukter
                    Methods.GetBedroomProducts();
                    break;

                case 4:
                    //visa vardagsrummsprodukter
                    Methods.GetLivingRoomProducts();
                    break;

                case 5:
                    //fritextsöskning produkter
                    Methods.searchProduct();
                    break;

                case 6:
                    //lägger till produkter till kundkorgen

                    break;

                case 7:
                    //tillbaka till huvud meny
                    huvudMeny(false);
                    break;
          

            }

            return false;
        }

        public static bool AdminMeny(bool quit)
        {

            Console.WriteLine(
            "1 = Visa produkt \n" +
            "2 = Visa kategori \n" +
            "3 = Lägg till produkt \n" +
            "4 = Lägg till kategori \n" +
            "5 = Ta bort produkt \n" +
            "6 = Ta bort kategori \n" +
            "7 = gå tillbaka till huvud meny \n" +
            "8 = exit");

            int val = Convert.ToInt32(Console.ReadLine());
            switch (val)
            {
                case 1:
                    //visar produkter
                    Methods.GetProducts();
                    break;
                case 2:
                    //visar produkter
                    Methods.GetCategories();
                    break;
                case 3:
                    //kunna lägga till produkt
                    Methods.GetProducts();
                    Methods.InsertProdukt();
                    break; 

                case 4:
                    Methods.GetCategories();
                    Methods.InsertCategory();
                    
                    break;

                case 5:
                    //kunna ta bort produkt
                    Console.Clear();
                    Console.WriteLine("\n");
                    Methods.GetProducts();
                    Methods.DeleteProdukt();

                    break;

                case 6:
                    Methods.GetCategories();
                    Methods.DeleteCategory();
                    break;

                case 7:
                    //tillbaka till huvud meny
                    huvudMeny(false);
                    break;
                    

                case 8:
                    //kunna göra exit
                    return true;

            }

            return false;

        }

        public static bool kundKorg(bool quit)
        {
            Methods.GetKundKorg();

            Console.WriteLine(
            "1 = Kundmeny \n" +
            "2 = huvudmeny \n" +
            "3 = Exit \n" +
            "Mata in ett nummer.");

            int val = Convert.ToInt32(Console.ReadLine());

            switch (val)
            {
                case 1:
                    //Gå vidare/köpa produkter

                    break;

                case 2:
                    //ta bort produkt från kundkorgen

                    break;

                case 3:
                    // gå till huvudmeny
                    huvudMeny(false);
                    break;
                case 4:
                    //exit
                    return true;



                default:
                    Console.WriteLine("fel input");
                    break;

            }

            return false;

        }


    }
}
