using System;
using System.Collections.Generic;
using SajamKnjiga.Core.Interfaces;

namespace SajamKnjiga.Core.Models
{
    public class Izdavac : ISerializable
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

        public string[] ToCSV()
        {
            string sef = SefIzdavaca == null ? "" : SefIzdavaca.BrojLicneKarte;
            string[] csvValues = { Sifra, Naziv, sef };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Sifra = values[0];
            Naziv = values[1];
            if (values[2] != "")
            {
                SefIzdavaca = new Autor();
                SefIzdavaca.BrojLicneKarte = values[2];
            }
        }
        public override string ToString()
        {
            string sef = SefIzdavaca == null ? "-" : $"{SefIzdavaca.Prezime} {SefIzdavaca.Ime}";
            return $"| Sifra: {Sifra} | Naziv: {Naziv} | Sef: {sef} | Autori: {Autori.Count} | Knjige: {Knjige.Count} |";
        }
    }
}