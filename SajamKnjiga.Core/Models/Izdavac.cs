using System;
using System.Collections.Generic;

namespace SajamKnjiga.Core.Models
{
    public class Izdavac
    {
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public Autor SefIzdavaca { get; set; }
        public List<Autor> Autori { get; set; }
        public List<Knjiga> Knjige { get; set; }

        public Izdavac()
        {
            Sifra = string.Empty;
            Naziv = string.Empty;
            SefIzdavaca = null;
            Autori = new List<Autor>();
            Knjige = new List<Knjiga>();
        }

        public Izdavac(string sifra, string naziv) : this()
        {
            Sifra = sifra;
            Naziv = naziv;
        }

        public override string ToString()
        {
            string sef = SefIzdavaca == null ? "-" : $"{SefIzdavaca.Prezime} {SefIzdavaca.Ime}";
            return $"| Sifra: {Sifra} | Naziv: {Naziv} | Sef: {sef} | Autori: {Autori.Count} | Knjige: {Knjige.Count} |";
        }
    }
}