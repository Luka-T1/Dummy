using System;
using System.Collections.Generic;
using System.Globalization;
using SajamKnjiga.Core.Interfaces;

namespace SajamKnjiga.Core.Models
{
    public class Knjiga : ISerializable
    {
        public string ISBN { get; set; }
        public string Naziv { get; set; }
        public string Zanr { get; set; }
        public int GodinaIzdanja { get; set; }
        public double Cena { get; set; }
        public int BrojStrana { get; set; }
        public List<Autor> Autori { get; set; }
        public Izdavac Izdavac { get; set; }
        public List<Posetilac> Kupci { get; set; }
        public List<Posetilac> PosetiociZelja { get; set; }

        public Knjiga()
        {
            ISBN = string.Empty;
            Naziv = string.Empty;
            Zanr = string.Empty;
            GodinaIzdanja = 0;
            Cena = 0;
            BrojStrana = 0;
            Autori = new List<Autor>();
            Izdavac = null;
            Kupci = new List<Posetilac>();
            PosetiociZelja = new List<Posetilac>();
        }

        public string[] ToCSV()
        {
            // u fajl se cuvaju samo kljucevi izdavaca i autora, ne ceo objekat
            string sifraIzdavaca = Izdavac == null ? "" : Izdavac.Sifra;
            List<string> licneKarte = new List<string>();
            foreach (Autor autor in Autori)
            {
                licneKarte.Add(autor.BrojLicneKarte);
            }

            string[] csvValues =
            {
                ISBN,
                Naziv,
                Zanr,
                GodinaIzdanja.ToString(),
                Cena.ToString(CultureInfo.InvariantCulture),
                BrojStrana.ToString(),
                sifraIzdavaca,
                string.Join(",", licneKarte)
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            ISBN = values[0];
            Naziv = values[1];
            Zanr = values[2];
            GodinaIzdanja = int.Parse(values[3]);
            Cena = double.Parse(values[4], CultureInfo.InvariantCulture);
            BrojStrana = int.Parse(values[5]);

            // ovde pravimo "prazne" objekte samo sa kljucem, pravi objekti se povezu posle ucitavanja
            if (values[6] != "")
            {
                Izdavac = new Izdavac();
                Izdavac.Sifra = values[6];
            }

            Autori = new List<Autor>();
            foreach (string lk in values[7].Split(','))
            {
                if (lk != "")
                {
                    Autor autor = new Autor();
                    autor.BrojLicneKarte = lk;
                    Autori.Add(autor);
                }
            }
        }
        public override string ToString()
        {
            string izdavac = Izdavac == null ? "-" : Izdavac.Naziv;
            return $"| ISBN: {ISBN} | Naziv: {Naziv} | Zanr: {Zanr} | Godina: {GodinaIzdanja} | Cena: {Cena:F2} | Strana: {BrojStrana} | Autori: {Autori.Count} | Izdavac: {izdavac} | Kupci: {Kupci.Count} | Zelje: {PosetiociZelja.Count} |";
        }
    }
}