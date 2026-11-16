using System;
using System.Collections.Generic;

namespace SajamKnjiga.Core.Models
{
    public class Knjiga
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

        public override string ToString()
        {
            string izdavac = Izdavac == null ? "-" : Izdavac.Naziv;
            return $"| ISBN: {ISBN} | Naziv: {Naziv} | Zanr: {Zanr} | Godina: {GodinaIzdanja} | Cena: {Cena:F2} | Strana: {BrojStrana} | Autori: {Autori.Count} | Izdavac: {izdavac} | Kupci: {Kupci.Count} | Zelje: {PosetiociZelja.Count} |";
        }
    }
}