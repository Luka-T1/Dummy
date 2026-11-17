using System;
using System.Collections.Generic;
using SajamKnjiga.Core.Models;

namespace SajamKnjiga.CLI.Views
{
    // Po uzoru na VehicleConsoleView iz CRUDExample (vezbe 3)
    public class KupovinaConsoleView
    {
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
