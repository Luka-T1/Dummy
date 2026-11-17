using System;
using System.Collections.Generic;
using SajamKnjiga.Core.Models;

namespace SajamKnjiga.CLI.Views
{
    // Po uzoru na VehicleConsoleView iz CRUDExample (vezbe 3)
    public class AutorConsoleView
    {
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
    }
}
