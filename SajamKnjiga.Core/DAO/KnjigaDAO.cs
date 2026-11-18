using System;
using System.Collections.Generic;
using SajamKnjiga.Core.Models;
using SajamKnjiga.Core.Utils;

namespace SajamKnjiga.Core.DAO
{
    // Po uzoru na VehicleDAO iz CRUDExample (vezbe 3)
    public class KnjigaDAO
    {
        private readonly List<Knjiga> _knjige;
        private readonly Storage<Knjiga> _storage;

        public KnjigaDAO()
        {
            _storage = new Storage<Knjiga>("knjige.txt");
            _knjige = _storage.Load();
        }

        public List<Knjiga> GetAllKnjige()
        {
            return _knjige;
        }

        public Knjiga GetKnjigaByISBN(string isbn)
        {
            return _knjige.Find(x => x.ISBN == isbn);
        }

        public Knjiga AddKnjiga(Knjiga knjiga)
        {
            // isti kljuc ne sme da postoji dva puta
            if (GetKnjigaByISBN(knjiga.ISBN) != null)
            {
                return null;
            }

            _knjige.Add(knjiga);
            _storage.Save(_knjige);
            return knjiga;
        }

        public Knjiga UpdateKnjiga(Knjiga knjiga)
        {
            Knjiga stara = GetKnjigaByISBN(knjiga.ISBN);
            if (stara == null)
            {
                return null;
            }

            stara.Naziv = knjiga.Naziv;
            stara.Zanr = knjiga.Zanr;
            stara.GodinaIzdanja = knjiga.GodinaIzdanja;
            stara.Cena = knjiga.Cena;
            stara.BrojStrana = knjiga.BrojStrana;
            stara.Autori = knjiga.Autori;
            stara.Izdavac = knjiga.Izdavac;
            _storage.Save(_knjige);
            return stara;
        }

        public Knjiga RemoveKnjiga(string isbn)
        {
            Knjiga knjiga = GetKnjigaByISBN(isbn);
            if (knjiga == null)
            {
                return null;
            }

            _knjige.Remove(knjiga);
            _storage.Save(_knjige);
            return knjiga;
        }
    }
}