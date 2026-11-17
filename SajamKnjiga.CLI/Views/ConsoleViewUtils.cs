using System;

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
    }
}
