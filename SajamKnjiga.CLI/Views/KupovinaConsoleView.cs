using System;
using System.Collections.Generic;
using SajamKnjiga.Core.DAO;
using SajamKnjiga.Core.Models;

namespace SajamKnjiga.CLI.Views
{
    // Po uzoru na VehicleConsoleView iz CRUDExample (vezbe 3)
    public class KupovinaConsoleView
    {
        private readonly KupovinaDAO _kupovinaDao;
        private readonly PosetilacDAO _posetilacDao;
        private readonly KnjigaDAO _knjigaDao;

        public KupovinaConsoleView(KupovinaDAO kupovinaDao, PosetilacDAO posetilacDao, KnjigaDAO knjigaDao)
        {
            _kupovinaDao = kupovinaDao;
            _posetilacDao = posetilacDao;
            _knjigaDao = knjigaDao;
        }

        public void RunMenu()
        {
            while (true)
            {
                ShowMenu();
                string unos = Console.ReadLine() ?? "0";
                if (unos == "0")
                {
                    break;
                }
                HandleMenuInput(unos);
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("--- KUPOVINE ---");
            Console.WriteLine("1: Prikaz svih kupovina");
            Console.WriteLine("2: Dodavanje kupovine");
            Console.WriteLine("3: Izmena kupovine");
            Console.WriteLine("4: Brisanje kupovine");
            Console.WriteLine("0: Nazad");
            Console.Write(">> ");
        }

        private void HandleMenuInput(string unos)
        {
            switch (unos)
            {
                case "1":
                    PrintKupovine(_kupovinaDao.GetAllKupovine());
                    break;
                case "2":
                    DodajKupovinu();
                    break;
                case "3":
                    IzmeniKupovinu();
                    break;
                case "4":
                    ObrisiKupovinu();
                    break;
                default:
                    Console.WriteLine("Nepostojeca opcija.");
                    break;
            }
        }

        private void DodajKupovinu()
        {
            Kupovina kupovina = InputKupovina();

            Posetilac posetilac = _posetilacDao.GetPosetilacByBrojClanskeKarte(kupovina.Posetilac.BrojClanskeKarte);
            Knjiga knjiga = _knjigaDao.GetKnjigaByISBN(kupovina.Knjiga.ISBN);
            if (posetilac == null || knjiga == null)
            {
                Console.WriteLine("Posetilac ili knjiga ne postoje, kupovina nije dodata.");
                return;
            }
            kupovina.Posetilac = posetilac;
            kupovina.Knjiga = knjiga;

            if (_kupovinaDao.AddKupovina(kupovina) == null)
            {
                Console.WriteLine("Posetilac je vec kupio ovu knjigu.");
                return;
            }
            Console.WriteLine("Kupovina je dodata.");
        }

         private void IzmeniKupovinu()
        {
            string brojKarte = ConsoleViewUtils.SafeInputText("Broj clanske karte posetioca: ");
            string isbn = ConsoleViewUtils.SafeInputText("ISBN knjige: ");
            Kupovina stara = _kupovinaDao.GetKupovina(brojKarte, isbn);
            if (stara == null)
            {
                Console.WriteLine("Ta kupovina ne postoji.");
                return;
            }

            Console.WriteLine("Trenutni podaci: " + stara);
            Console.WriteLine("Unesite nove podatke:");
            Kupovina nova = new Kupovina();
            nova.Posetilac = stara.Posetilac;
            nova.Knjiga = stara.Knjiga;
            UnesiPodatke(nova);

            _kupovinaDao.UpdateKupovina(nova);
            Console.WriteLine("Kupovina je izmenjena.");
        }

        private void ObrisiKupovinu()
        {
            string brojKarte = ConsoleViewUtils.SafeInputText("Broj clanske karte posetioca: ");
            string isbn = ConsoleViewUtils.SafeInputText("ISBN knjige: ");
            if (_kupovinaDao.RemoveKupovina(brojKarte, isbn) == null)
            {
                Console.WriteLine("Ta kupovina ne postoji.");
                return;
            }
            Console.WriteLine("Kupovina je obrisana.");
        }

        public Kupovina InputKupovina()
        {
            Kupovina kupovina = new Kupovina();

            // za sada samo kljucevi, posetilac i knjiga se traze posle unosa
            kupovina.Posetilac = new Posetilac();
            kupovina.Posetilac.BrojClanskeKarte = ConsoleViewUtils.SafeInputText("Broj clanske karte posetioca: ");
            kupovina.Knjiga = new Knjiga();
            kupovina.Knjiga.ISBN = ConsoleViewUtils.SafeInputText("ISBN knjige: ");

            UnesiPodatke(kupovina);
            return kupovina;
        }

        private void UnesiPodatke(Kupovina kupovina)
        {
            kupovina.DatumKupovine = ConsoleViewUtils.SafeInputDate("Datum kupovine (dd.MM.yyyy): ");
            int ocena = ConsoleViewUtils.SafeInputInt("Ocena (1-5): ");
            while (ocena < 1 || ocena > 5)
            {
                ocena = ConsoleViewUtils.SafeInputInt("Ocena mora biti od 1 do 5: ");
            }
            kupovina.Ocena = ocena;
            Console.Write("Komentar: ");
            kupovina.Komentar = Console.ReadLine() ?? string.Empty;
        }

        public void PrintKupovine(List<Kupovina> kupovine)
        {
            if (kupovine.Count == 0)
            {
                Console.WriteLine("Nema kupovina.");
                return;
            }

            Console.WriteLine("Kupovine:");
            foreach (Kupovina kupovina in kupovine)
            {
                Console.WriteLine(kupovina);
            }
        }
    }
}
