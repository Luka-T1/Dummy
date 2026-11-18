using System;
using System.Collections.Generic;
using System.Globalization;
using SajamKnjiga.Core.Interfaces;

namespace SajamKnjiga.Core.Models
{
    public class Posetilac : ISerializable
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Adresa Adresa { get; set; }
        public string KontaktTelefon { get; set; }
        public string Email { get; set; }
        public string BrojClanskeKarte { get; set; }
        public int TrenutnaGodinaClanstva { get; set; }
        public Status Status { get; set; }
        public double ProsecnaOcenaRecenzija { get; set; }
        public List<Kupovina> ListaKupovina { get; set; }
        public List<Knjiga> ListaZelja { get; set; }

        public Posetilac()
        {
            Ime = string.Empty;
            Prezime = string.Empty;
            DatumRodjenja = DateTime.Today;
            Adresa = new Adresa();
            KontaktTelefon = string.Empty;
            Email = string.Empty;
            BrojClanskeKarte = string.Empty;
            TrenutnaGodinaClanstva = 1;
            Status = Status.R;
            ProsecnaOcenaRecenzija = 0;
            ListaKupovina = new List<Kupovina>();
            ListaZelja = new List<Knjiga>();
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
                KontaktTelefon,
                Email,
                BrojClanskeKarte,
                TrenutnaGodinaClanstva.ToString(),
                Status.ToString(),
                ProsecnaOcenaRecenzija.ToString(CultureInfo.InvariantCulture)
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Ime = values[0];
            Prezime = values[1];
            DatumRodjenja = DateTime.ParseExact(values[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Adresa = new Adresa(values[3], values[4], values[5], values[6]);
            KontaktTelefon = values[7];
            Email = values[8];
            BrojClanskeKarte = values[9];
            TrenutnaGodinaClanstva = int.Parse(values[10]);
            Status = (Status)Enum.Parse(typeof(Status), values[11]);
            ProsecnaOcenaRecenzija = double.Parse(values[12], CultureInfo.InvariantCulture);
        }
        public override string ToString()
        {
            return $"| Ime: {Ime} | Prezime: {Prezime} | Datum rodjenja: {DatumRodjenja:dd.MM.yyyy.} | Adresa: {Adresa} | Telefon: {KontaktTelefon} | Email: {Email} | Clanska karta: {BrojClanskeKarte} | Godina clanstva: {TrenutnaGodinaClanstva} | Status: {Status} | Prosek recenzija: {ProsecnaOcenaRecenzija:F2} | Kupovine: {ListaKupovina.Count} | Zelje: {ListaZelja.Count} |";
        }
    }
}