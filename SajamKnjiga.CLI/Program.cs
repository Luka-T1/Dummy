using System;
using System.Text;
using SajamKnjiga.CLI.Views;
using SajamKnjiga.Core.DAO;
using SajamKnjiga.Core.Utils;

namespace SajamKnjiga.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            // da bi se lepo prikazivala nasa slova
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // DAO objekti se prave jednom i dele izmedju pogleda
            PosetilacDAO posetilacDao = new PosetilacDAO();
            AutorDAO autorDao = new AutorDAO();
            KnjigaDAO knjigaDao = new KnjigaDAO();
            IzdavacDAO izdavacDao = new IzdavacDAO();
            KupovinaDAO kupovinaDao = new KupovinaDAO();

            Povezivanje.Povezi(posetilacDao, autorDao, knjigaDao, izdavacDao, kupovinaDao);
            PosetilacConsoleView posetilacView = new PosetilacConsoleView(posetilacDao);
            AutorConsoleView autorView = new AutorConsoleView(autorDao);
            KnjigaConsoleView knjigaView = new KnjigaConsoleView(knjigaDao, autorDao, izdavacDao);
            KupovinaConsoleView kupovinaView = new KupovinaConsoleView(kupovinaDao, posetilacDao, knjigaDao);
            IzdavacConsoleView izdavacView = new IzdavacConsoleView(izdavacDao, autorDao);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== SAJAM KNJIGA =====");
                Console.WriteLine("1: Posetioci");
                Console.WriteLine("2: Autori");
                Console.WriteLine("3: Knjige");
                Console.WriteLine("4: Kupovine");
                Console.WriteLine("5: Izdavaci");
                Console.WriteLine("0: Izlaz");
                Console.Write(">> ");

                string unos = Console.ReadLine() ?? "0";
                if (unos == "0")
                {
                    break;
                }

                switch (unos)
                {
                    case "1":
                        posetilacView.RunMenu();
                        break;
                    case "2":
                        autorView.RunMenu();
                        break;
                    case "3":
                        knjigaView.RunMenu();
                        break;
                    case "4":
                        kupovinaView.RunMenu();
                        break;
                    case "5":
                        izdavacView.RunMenu();
                        break;
                    default:
                        Console.WriteLine("Nepostojeca opcija.");
                        break;
                }
            }

            Console.WriteLine("Dovidjenja!");
        }
    }
}