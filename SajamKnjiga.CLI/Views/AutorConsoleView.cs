using System;
using System.Collections.Generic;
using SajamKnjiga.Core.DAO;
using SajamKnjiga.Core.Models;

namespace SajamKnjiga.CLI.Views
{
    // Po uzoru na VehicleConsoleView iz CRUDExample (vezbe 3)
    public class AutorConsoleView
    {
         private readonly AutorDAO _autorDao;

        public AutorConsoleView(AutorDAO autorDao)
        {
            _autorDao = autorDao;
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
            Console.WriteLine("--- AUTORI ---");
            Console.WriteLine("1: Prikaz svih autora");
            Console.WriteLine("2: Dodavanje autora");
            Console.WriteLine("3: Izmena autora");
            Console.WriteLine("4: Brisanje autora");
            Console.WriteLine("0: Nazad");
            Console.Write(">> ");
        }

        private void HandleMenuInput(string unos)
        {
            switch (unos)
            {
                case "1":
                    PrintAutori(_autorDao.GetAllAutori());
                    break;
                case "2":
                    DodajAutora();
                    break;
                case "3":
                    IzmeniAutora();
                    break;
                case "4":
                    ObrisiAutora();
                    break;
                default:
                    Console.WriteLine("Nepostojeca opcija.");
                    break;
            }
        }

        private void DodajAutora()
        {
            Autor autor = InputAutor();
            if (_autorDao.AddAutor(autor) == null)
            {
                Console.WriteLine("Autor sa tim brojem licne karte vec postoji.");
                return;
            }
            Console.WriteLine("Autor je dodat.");
        }

        private void IzmeniAutora()
        {
            string brojLk = ConsoleViewUtils.SafeInputText("Broj licne karte autora za izmenu: ");
            Autor stari = _autorDao.GetAutorByBrojLicneKarte(brojLk);
            if (stari == null)
            {
                Console.WriteLine("Ne postoji autor sa tim brojem licne karte.");
                return;
            }

            Console.WriteLine("Trenutni podaci: " + stari);
            Console.WriteLine("Unesite nove podatke:");
            Autor novi = new Autor();
            novi.BrojLicneKarte = brojLk;
            UnesiPodatke(novi);

            _autorDao.UpdateAutor(novi);
            Console.WriteLine("Autor je izmenjen.");
        }

        private void ObrisiAutora()
        {
            string brojLk = ConsoleViewUtils.SafeInputText("Broj licne karte autora za brisanje: ");
            Autor obrisan = _autorDao.RemoveAutor(brojLk);
            if (obrisan == null)
            {
                Console.WriteLine("Ne postoji autor sa tim brojem licne karte.");
                return;
            }
            Console.WriteLine("Obrisan autor: " + obrisan.Ime + " " + obrisan.Prezime);
        }

        public Autor InputAutor()
        {
            Autor autor = new Autor();
            autor.BrojLicneKarte = ConsoleViewUtils.SafeInputText("Broj licne karte: ");
            UnesiPodatke(autor);
            return autor;
        }

        private void UnesiPodatke(Autor autor)
        {
            autor.Ime = ConsoleViewUtils.SafeInputText("Ime: ");
            autor.Prezime = ConsoleViewUtils.SafeInputText("Prezime: ");
            autor.DatumRodjenja = ConsoleViewUtils.SafeInputDate("Datum rodjenja (dd.MM.yyyy): ");
            autor.Adresa.Ulica = ConsoleViewUtils.SafeInputText("Ulica: ");
            autor.Adresa.Broj = ConsoleViewUtils.SafeInputText("Broj: ");
            autor.Adresa.Grad = ConsoleViewUtils.SafeInputText("Grad: ");
            autor.Adresa.Drzava = ConsoleViewUtils.SafeInputText("Drzava: ");
            autor.Telefon = ConsoleViewUtils.SafeInputText("Telefon: ");
            autor.Email = ConsoleViewUtils.SafeInputText("Email: ");
            autor.GodineIskustva = ConsoleViewUtils.SafeInputInt("Godine iskustva: ");
        }

        public void PrintAutori(List<Autor> autori)
        {
            if (autori.Count == 0)
            {
                Console.WriteLine("Nema autora.");
                return;
            }

            Console.WriteLine("Autori:");
            foreach (Autor autor in autori)
            {
                Console.WriteLine(autor);
            }
        }

    }
}
