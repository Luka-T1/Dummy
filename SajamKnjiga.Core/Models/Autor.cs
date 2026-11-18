using System;
using System.Collections.Generic;
using System.Globalization;
using SajamKnjiga.Core.Interfaces;

namespace SajamKnjiga.Core.Models
{
    public class Autor : ISerializable
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

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Ime,
                Prezime,
                DatumRodjenja.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                Adresa.Ulica,
                Adresa.Broj,
                Adresa.Grad,
                Adresa.Drzava,
                Telefon,
                Email,
                BrojLicneKarte,
                GodineIskustva.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Ime = values[0];
            Prezime = values[1];
            DatumRodjenja = DateTime.ParseExact(values[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Adresa = new Adresa(values[3], values[4], values[5], values[6]);
            Telefon = values[7];
            Email = values[8];
            BrojLicneKarte = values[9];
            GodineIskustva = int.Parse(values[10]);
        }
        public override string ToString()
        {
            return $"| Ime: {Ime} | Prezime: {Prezime} | Datum rodjenja: {DatumRodjenja:dd.MM.yyyy.} | Adresa: {Adresa} | Telefon: {Telefon} | Email: {Email} | Licna karta: {BrojLicneKarte} | Iskustvo: {GodineIskustva} | Knjige: {Knjige.Count} |";
        }
    }
}
