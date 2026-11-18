using System;
using System.Collections.Generic;
using SajamKnjiga.Core.DAO;
using SajamKnjiga.Core.Models;

namespace SajamKnjiga.CLI.Views
{
    // Po uzoru na VehicleConsoleView iz CRUDExample (vezbe 3)
    public class KnjigaConsoleView
    {
        private readonly KnjigaDAO _knjigaDao;
        private readonly AutorDAO _autorDao;
        private readonly IzdavacDAO _izdavacDao;

        public KnjigaConsoleView(KnjigaDAO knjigaDao, AutorDAO autorDao, IzdavacDAO izdavacDao)
        {
            _knjigaDao = knjigaDao;
            _autorDao = autorDao;
            _izdavacDao = izdavacDao;
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
            Console.WriteLine("--- KNJIGE ---");
            Console.WriteLine("1: Prikaz svih knjiga");
            Console.WriteLine("2: Dodavanje knjige");
            Console.WriteLine("3: Izmena knjige");
            Console.WriteLine("4: Brisanje knjige");
            Console.WriteLine("0: Nazad");
            Console.Write(">> ");
        }

        private void HandleMenuInput(string unos)
        {
            switch (unos)
            {
                case "1":
                    PrintKnjige(_knjigaDao.GetAllKnjige());
                    break;
                case "2":
                    DodajKnjigu();
                    break;
                case "3":
                    IzmeniKnjigu();
                    break;
                case "4":
                    ObrisiKnjigu();
                    break;
                default:
                    Console.WriteLine("Nepostojeca opcija.");
                    break;
            }
        }

        private void DodajKnjigu()
        {
            Knjiga knjiga = InputKnjiga();
            PoveziSaPostojecim(knjiga);
            if (_knjigaDao.AddKnjiga(knjiga) == null)
            {
                Console.WriteLine("Knjiga sa tim ISBN-om vec postoji.");
                return;
            }
            Console.WriteLine("Knjiga je dodata.");
        }

        // posle unosa imamo samo sifru izdavaca i licne karte autora, ovde nadjemo prave objekte
        private void PoveziSaPostojecim(Knjiga knjiga)
        {
            if (knjiga.Izdavac != null)
            {
                Izdavac izdavac = _izdavacDao.GetIzdavacBySifra(knjiga.Izdavac.Sifra);
                if (izdavac == null)
                {
                    Console.WriteLine("Izdavac " + knjiga.Izdavac.Sifra + " ne postoji, knjiga ostaje bez izdavaca.");
                }
                knjiga.Izdavac = izdavac;
            }

            List<Autor> autori = new List<Autor>();
            foreach (Autor a in knjiga.Autori)
            {
                Autor autor = _autorDao.GetAutorByBrojLicneKarte(a.BrojLicneKarte);
                if (autor == null)
                {
                    Console.WriteLine("Autor sa LK " + a.BrojLicneKarte + " ne postoji, preskacem ga.");
                    continue;
                }
                autori.Add(autor);
            }
            knjiga.Autori = autori;
        }

        private void IzmeniKnjigu()
        {
            string isbn = ConsoleViewUtils.SafeInputText("ISBN knjige za izmenu: ");
            Knjiga stara = _knjigaDao.GetKnjigaByISBN(isbn);
            if (stara == null)
            {
                Console.WriteLine("Ne postoji knjiga sa tim ISBN-om.");
                return;
            }

            Console.WriteLine("Trenutni podaci: " + stara);
            Console.WriteLine("Unesite nove podatke:");
            Knjiga nova = new Knjiga();
            nova.ISBN = isbn;
            UnesiPodatke(nova);
            PoveziSaPostojecim(nova);

            _knjigaDao.UpdateKnjiga(nova);
            Console.WriteLine("Knjiga je izmenjena.");
        }

        private void ObrisiKnjigu()
        {
            string isbn = ConsoleViewUtils.SafeInputText("ISBN knjige za brisanje: ");
            Knjiga obrisana = _knjigaDao.RemoveKnjiga(isbn);
            if (obrisana == null)
            {
                Console.WriteLine("Ne postoji knjiga sa tim ISBN-om.");
                return;
            }
            Console.WriteLine("Obrisana knjiga: " + obrisana.Naziv);
        }

        public Knjiga InputKnjiga()
        {
            Knjiga knjiga = new Knjiga();
            knjiga.ISBN = ConsoleViewUtils.SafeInputText("ISBN: ");
            UnesiPodatke(knjiga);
            return knjiga;
        }

        private void UnesiPodatke(Knjiga knjiga)
        {
            knjiga.Naziv = ConsoleViewUtils.SafeInputText("Naziv: ");
            knjiga.Zanr = ConsoleViewUtils.SafeInputText("Zanr: ");
            knjiga.GodinaIzdanja = ConsoleViewUtils.SafeInputInt("Godina izdanja: ");
            knjiga.Cena = ConsoleViewUtils.SafeInputDouble("Cena: ");
            knjiga.BrojStrana = ConsoleViewUtils.SafeInputInt("Broj strana: ");

            string sifra = ConsoleViewUtils.SafeInputText("Sifra izdavaca (- ako nema): ");
            if (sifra != "-")
            {
                knjiga.Izdavac = new Izdavac();
                knjiga.Izdavac.Sifra = sifra;
            }

            string licneKarte = ConsoleViewUtils.SafeInputText("Licne karte autora, odvojene zarezom: ");
            foreach (string lk in licneKarte.Split(','))
            {
                if (lk.Trim() != "")
                {
                    Autor autor = new Autor();
                    autor.BrojLicneKarte = lk.Trim();
                    knjiga.Autori.Add(autor);
                }
            }
        }

        public void PrintKnjige(List<Knjiga> knjige)
        {
            if (knjige.Count == 0)
            {
                Console.WriteLine("Nema knjiga.");
                return;
            }

            Console.WriteLine("Knjige:");
            foreach (Knjiga knjiga in knjige)
            {
                Console.WriteLine(knjiga);
            }
        }

    }
}
