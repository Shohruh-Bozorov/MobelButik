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
        "6 = gå tillbaka till huvud meny \n" +
        "Mata in ett nummer.");

            int val = Convert.ToInt32(Console.ReadLine());
            switch (val)
            {
                case 1:
                    //visa alla produkter
                    Console.Clear();
                    Methods.GetProducts();
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

                    break;

                case 6:
                    //tillbaka till huvud meny

                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;

            }

            return false;
        }

        public static bool AdminMeny(bool quit)
        {

            Console.WriteLine(
            "1 = Lägg till produkt \n" +
            "2 = Ta bort produkt \n" +
            "3 = Ändra tabell \n" +
            "4 = gå tillbaka till huvud meny \n" +
            "5 = exit");

            int val = Convert.ToInt32(Console.ReadLine());
            switch (val)
            {
                case 1:
                    //kunna lägga till produkt
                    Methods.InsertProdukt();
                    break;

                case 2:
                    Console.Clear();
                    Methods.GetProducts();
                    Methods.DeleteProdukt();
                    //kunna ta bort produkt
                    break;

                case 3:
                    //kunna ändra tabbell

                    break;

                case 4:
                    //tillbaka till huvud meny
                    break;

                case 5:
                    //kunna göra exit
                    return true;

            }

            return false;

        }

        public static bool Meny1(bool quit)
        {

            Console.WriteLine(
        "1 = Kundmeny \n" +
        "2 = huvudmeny \n" +
        "3 = Exit \n" +
        "Mata in ett nummer.");

            int val = Convert.ToInt32(Console.ReadLine());

            switch (val)
            {
                case 1:
                    Console.Clear();
                    KundMeny(false);
                    break;

                case 2:
                    huvudMeny(false);
                    break;
                case 3:
                    return true;



                default:
                    Console.WriteLine("fel input");
                    break;

            }

            return false;

        }


    }
}
