using System;
using System.Collections.Generic;

namespace SajamKnjiga.Core.Models
{
    public class Posetilac
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

        public override string ToString()
        {
            return $"| Ime: {Ime} | Prezime: {Prezime} | Datum rodjenja: {DatumRodjenja:dd.MM.yyyy.} | Adresa: {Adresa} | Telefon: {KontaktTelefon} | Email: {Email} | Clanska karta: {BrojClanskeKarte} | Godina clanstva: {TrenutnaGodinaClanstva} | Status: {Status} | Prosek recenzija: {ProsecnaOcenaRecenzija:F2} | Kupovine: {ListaKupovina.Count} | Zelje: {ListaZelja.Count} |";
        }
    }
}