using System;
using System.Collections.Generic;
using SajamKnjiga.Core.Models;

namespace SajamKnjiga.CLI.Views
{
    // Po uzoru na VehicleConsoleView iz CRUDExample (vezbe 3)
    public class PosetilacConsoleView
    {
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
    }
}
