using System;
using System.Collections.Generic;
using SajamKnjiga.Core.Models;

namespace SajamKnjiga.CLI.Views
{
    // Po uzoru na VehicleConsoleView iz CRUDExample (vezbe 3)
    public class KnjigaConsoleView
    {
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
    }
}
