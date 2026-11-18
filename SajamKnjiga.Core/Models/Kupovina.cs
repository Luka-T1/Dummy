using System;
using System.Globalization;
using SajamKnjiga.Core.Interfaces;

namespace SajamKnjiga.Core.Models
{
    public class Kupovina : ISerializable
    {
        public Posetilac Posetilac { get; set; }
        public Knjiga Knjiga { get; set; }
        public DateTime DatumKupovine { get; set; }
        public int Ocena { get; set; }
        public string Komentar { get; set; }

        public Kupovina()
        {
            Posetilac = null;
            Knjiga = null;
            DatumKupovine = DateTime.Today;
            Ocena = 1;
            Komentar = string.Empty;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Posetilac.BrojClanskeKarte,
                Knjiga.ISBN,
                DatumKupovine.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                Ocena.ToString(),
                Komentar
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Posetilac = new Posetilac();
            Posetilac.BrojClanskeKarte = values[0];
            Knjiga = new Knjiga();
            Knjiga.ISBN = values[1];
            DatumKupovine = DateTime.ParseExact(values[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Ocena = int.Parse(values[3]);
            Komentar = values[4];
        }
        public override string ToString()
        {
            string posetilac = Posetilac == null ? "-" : $"{Posetilac.Prezime} {Posetilac.Ime}";
            string knjiga = Knjiga == null ? "-" : Knjiga.Naziv;
            return $"| Posetilac: {posetilac} | Knjiga: {knjiga} | Datum: {DatumKupovine:dd.MM.yyyy.} | Ocena: {Ocena} | Komentar: {Komentar} |";
        }
    }
}