using System;
using System.Collections.Generic;

namespace SajamKnjiga.Core.Models
{
    public class Autor
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Adresa Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string BrojLicneKarte { get; set; }
        public int GodineIskustva { get; set; }
        public List<Knjiga> Knjige { get; set; }

        public Autor()
        {
            Ime = string.Empty;
            Prezime = string.Empty;
            DatumRodjenja = DateTime.Today;
            Adresa = new Adresa();
            Telefon = string.Empty;
            Email = string.Empty;
            BrojLicneKarte = string.Empty;
            GodineIskustva = 0;
            Knjige = new List<Knjiga>();
        }

        public override string ToString()
        {
            return $"| Ime: {Ime} | Prezime: {Prezime} | Datum rodjenja: {DatumRodjenja:dd.MM.yyyy.} | Adresa: {Adresa} | Telefon: {Telefon} | Email: {Email} | Licna karta: {BrojLicneKarte} | Iskustvo: {GodineIskustva} | Knjige: {Knjige.Count} |";
        }
    }
}
