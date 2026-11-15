using System;

namespace SajamKnjiga.Core.Models
{
    public class Kupovina
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

        public override string ToString()
        {
            string posetilac = Posetilac == null ? "-" : $"{Posetilac.Prezime} {Posetilac.Ime}";
            string knjiga = Knjiga == null ? "-" : Knjiga.Naziv;
            return $"| Posetilac: {posetilac} | Knjiga: {knjiga} | Datum: {DatumKupovine:dd.MM.yyyy.} | Ocena: {Ocena} | Komentar: {Komentar} |";
        }
    }
}