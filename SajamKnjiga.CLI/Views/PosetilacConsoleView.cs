using System;
using System.Collections.Generic;
using SajamKnjiga.Core.DAO;
using SajamKnjiga.Core.Models;


namespace SajamKnjiga.CLI.Views
{
    // Po uzoru na VehicleConsoleView iz CRUDExample (vezbe 3)
    public class PosetilacConsoleView
    {
         private readonly PosetilacDAO _posetilacDao;

        public PosetilacConsoleView(PosetilacDAO posetilacDao)
        {
            _posetilacDao = posetilacDao;
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
            Console.WriteLine("--- POSETIOCI ---");
            Console.WriteLine("1: Prikaz svih posetilaca");
            Console.WriteLine("2: Dodavanje posetioca");
            Console.WriteLine("3: Izmena posetioca");
            Console.WriteLine("4: Brisanje posetioca");
            Console.WriteLine("0: Nazad");
            Console.Write(">> ");
        }

        private void HandleMenuInput(string unos)
        {
            switch (unos)
            {
                case "1":
                    PrintPosetioci(_posetilacDao.GetAllPosetioci());
                    break;
                case "2":
                    DodajPosetioca();
                    break;
                case "3":
                    IzmeniPosetioca();
                    break;
                case "4":
                    ObrisiPosetioca();
                    break;
                default:
                    Console.WriteLine("Nepostojeca opcija.");
                    break;
            }
        }

        private void DodajPosetioca()
        {
            Posetilac posetilac = InputPosetilac();
            if (_posetilacDao.AddPosetilac(posetilac) == null)
            {
                Console.WriteLine("Posetilac sa tom clanskom kartom vec postoji.");
                return;
            }
            Console.WriteLine("Posetilac je dodat.");
        }

         private void IzmeniPosetioca()
        {
            string brojKarte = ConsoleViewUtils.SafeInputText("Broj clanske karte posetioca za izmenu: ");
            Posetilac stari = _posetilacDao.GetPosetilacByBrojClanskeKarte(brojKarte);
            if (stari == null)
            {
                Console.WriteLine("Ne postoji posetilac sa tom clanskom kartom.");
                return;
            }

            Console.WriteLine("Trenutni podaci: " + stari);
            Console.WriteLine("Unesite nove podatke:");
            Posetilac novi = new Posetilac();
            novi.BrojClanskeKarte = brojKarte;
            UnesiPodatke(novi);

            _posetilacDao.UpdatePosetilac(novi);
            Console.WriteLine("Posetilac je izmenjen.");
        }

         private void ObrisiPosetioca()
        {
            string brojKarte = ConsoleViewUtils.SafeInputText("Broj clanske karte posetioca za brisanje: ");
            Posetilac obrisan = _posetilacDao.RemovePosetilac(brojKarte);
            if (obrisan == null)
            {
                Console.WriteLine("Ne postoji posetilac sa tom clanskom kartom.");
                return;
            }
            Console.WriteLine("Obrisan posetilac: " + obrisan.Ime + " " + obrisan.Prezime);
        }

        public Posetilac InputPosetilac()
        {
            Posetilac posetilac = new Posetilac();
            posetilac.BrojClanskeKarte = ConsoleViewUtils.SafeInputText("Broj clanske karte (npr. SK-1-2023): ");
            UnesiPodatke(posetilac);
            return posetilac;
        }

        // sve osim clanske karte, da bi moglo da se koristi i kod izmene
        private void UnesiPodatke(Posetilac posetilac)
        {
            posetilac.Ime = ConsoleViewUtils.SafeInputText("Ime: ");
            posetilac.Prezime = ConsoleViewUtils.SafeInputText("Prezime: ");
            posetilac.DatumRodjenja = ConsoleViewUtils.SafeInputDate("Datum rodjenja (dd.MM.yyyy): ");
            posetilac.Adresa.Ulica = ConsoleViewUtils.SafeInputText("Ulica: ");
            posetilac.Adresa.Broj = ConsoleViewUtils.SafeInputText("Broj: ");
            posetilac.Adresa.Grad = ConsoleViewUtils.SafeInputText("Grad: ");
            posetilac.Adresa.Drzava = ConsoleViewUtils.SafeInputText("Drzava: ");
            posetilac.KontaktTelefon = ConsoleViewUtils.SafeInputText("Kontakt telefon: ");
            posetilac.Email = ConsoleViewUtils.SafeInputText("Email: ");
            posetilac.TrenutnaGodinaClanstva = ConsoleViewUtils.SafeInputInt("Trenutna godina clanstva: ");

            string status = ConsoleViewUtils.SafeInputText("Status (R - redovan, V - VIP): ").ToUpper();
            while (status != "R" && status != "V")
            {
                status = ConsoleViewUtils.SafeInputText("Unesite R ili V: ").ToUpper();
            }
            posetilac.Status = (Status)Enum.Parse(typeof(Status), status);
        }

        public void PrintPosetioci(List<Posetilac> posetioci)
        {
            if (posetioci.Count == 0)
            {
                Console.WriteLine("Nema posetilaca.");
                return;
            }

            Console.WriteLine("Posetioci:");
            foreach (Posetilac posetilac in posetioci)
            {
                Console.WriteLine(posetilac);
            }
        }

    }
}
