using System;
using System.Collections.Generic;
using SajamKnjiga.Core.Models;

namespace SajamKnjiga.CLI.Views
{
    // Po uzoru na VehicleConsoleView iz CRUDExample (vezbe 3)
    public class IzdavacConsoleView
    {
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
