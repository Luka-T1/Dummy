using System;
using System.Globalization;

namespace SajamKnjiga.CLI.Views
{
    // Po uzoru na ConsoleViewUtils iz CRUDExample (vezbe 3)
    public static class ConsoleViewUtils
    {
        public static string SafeInputText(string poruka)
        {
            Console.Write(poruka);
            string unos = Console.ReadLine() ?? string.Empty;
            while (unos.Trim() == "")
            {
                Console.Write("Polje ne sme biti prazno, unesite ponovo: ");
                unos = Console.ReadLine() ?? string.Empty;
            }
            return unos.Trim();
        }

        public static int SafeInputInt(string poruka)
        {
            Console.Write(poruka);
            int broj;
            while (!int.TryParse(Console.ReadLine(), out broj))
            {
                Console.Write("Unesite ceo broj: ");
            }
            return broj;
        }

        public static double SafeInputDouble(string poruka)
        {
            Console.Write(poruka);
            double broj;
            // dozvoljavamo i tacku i zarez
            while (!double.TryParse(Console.ReadLine()?.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out broj))
            {
                Console.Write("Unesite broj (npr. 1200.50): ");
            }
            return broj;
        }

        public static DateTime SafeInputDate(string poruka)
        {
            Console.Write(poruka);
            DateTime datum;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datum))
            {
                Console.Write("Datum mora biti u formatu dd.MM.yyyy (npr. 05.03.2001): ");
            }
            return datum;
        }

    }
}
