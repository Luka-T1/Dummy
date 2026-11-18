using System;
using System.Collections.Generic;
using SajamKnjiga.Core.DAO;
using SajamKnjiga.Core.Models;

namespace SajamKnjiga.CLI.Views
{
    // Po uzoru na VehicleConsoleView iz CRUDExample (vezbe 3)
    public class IzdavacConsoleView
    {
        private readonly IzdavacDAO _izdavacDao;
        private readonly AutorDAO _autorDao;

        public IzdavacConsoleView(IzdavacDAO izdavacDao, AutorDAO autorDao)
        {
            _izdavacDao = izdavacDao;
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
            Console.WriteLine("--- IZDAVACI ---");
            Console.WriteLine("1: Prikaz svih izdavaca");
            Console.WriteLine("2: Dodavanje izdavaca");
            Console.WriteLine("0: Nazad");
            Console.Write(">> ");
        }

        private void HandleMenuInput(string unos)
        {
            switch (unos)
            {
                case "1":
                    PrintIzdavaci(_izdavacDao.GetAllIzdavaci());
                    break;
                case "2":
                    DodajIzdavaca();
                    break;
                default:
                    Console.WriteLine("Nepostojeca opcija.");
                    break;
            }
        }

        private void DodajIzdavaca()
        {
            Izdavac izdavac = InputIzdavac();
            PostaviSefa(izdavac);
            if (_izdavacDao.AddIzdavac(izdavac) == null)
            {
                Console.WriteLine("Izdavac sa tom sifrom vec postoji.");
                return;
            }
            Console.WriteLine("Izdavac je dodat.");
        }

        // sef mora biti postojeci autor sa bar 5 godina iskustva
        private void PostaviSefa(Izdavac izdavac)
        {
            if (izdavac.SefIzdavaca == null)
            {
                return;
            }

            Autor sef = _autorDao.GetAutorByBrojLicneKarte(izdavac.SefIzdavaca.BrojLicneKarte);
            if (sef == null)
            {
                Console.WriteLine("Autor ne postoji, izdavac ostaje bez sefa.");
            }
            else if (sef.GodineIskustva < 5)
            {
                Console.WriteLine("Autor ima manje od 5 godina iskustva i ne moze biti sef.");
                sef = null;
            }
            izdavac.SefIzdavaca = sef;
        }

        public Izdavac InputIzdavac()
        {
            Izdavac izdavac = new Izdavac();
            izdavac.Sifra = ConsoleViewUtils.SafeInputText("Sifra: ");
            UnesiPodatke(izdavac);
            return izdavac;
        }

        private void UnesiPodatke(Izdavac izdavac)
        {
            izdavac.Naziv = ConsoleViewUtils.SafeInputText("Naziv: ");
            string lk = ConsoleViewUtils.SafeInputText("Licna karta sefa (- ako jos nema): ");
            if (lk != "-")
            {
                izdavac.SefIzdavaca = new Autor();
                izdavac.SefIzdavaca.BrojLicneKarte = lk;
            }
        }

        public void PrintIzdavaci(List<Izdavac> izdavaci)
        {
            if (izdavaci.Count == 0)
            {
                Console.WriteLine("Nema izdavaca.");
                return;
            }

            Console.WriteLine("Izdavaci:");
            foreach (Izdavac izdavac in izdavaci)
            {
                Console.WriteLine(izdavac);
            }
        }
    }
}
