using System;
using System.Collections.Generic;
using SajamKnjiga.Core.Models;
using SajamKnjiga.Core.Utils;

namespace SajamKnjiga.Core.DAO
{
    // Po uzoru na VehicleDAO iz CRUDExample (vezbe 3)
    public class AutorDAO
    {
        private readonly List<Autor> _autori;
        private readonly Storage<Autor> _storage;

        public AutorDAO()
        {
            _storage = new Storage<Autor>("autori.txt");
            _autori = _storage.Load();
        }

        public List<Autor> GetAllAutori()
        {
            return _autori;
        }

        public Autor GetAutorByBrojLicneKarte(string brojLicneKarte)
        {
            return _autori.Find(x => x.BrojLicneKarte == brojLicneKarte);
        }

        public Autor AddAutor(Autor autor)
        {
            // isti kljuc ne sme da postoji dva puta
            if (GetAutorByBrojLicneKarte(autor.BrojLicneKarte) != null)
            {
                return null;
            }

            _autori.Add(autor);
            _storage.Save(_autori);
            return autor;
        }

        public Autor UpdateAutor(Autor autor)
        {
            Autor stari = GetAutorByBrojLicneKarte(autor.BrojLicneKarte);
            if (stari == null)
            {
                return null;
            }

            stari.Ime = autor.Ime;
            stari.Prezime = autor.Prezime;
            stari.DatumRodjenja = autor.DatumRodjenja;
            stari.Adresa = autor.Adresa;
            stari.Telefon = autor.Telefon;
            stari.Email = autor.Email;
            stari.GodineIskustva = autor.GodineIskustva;
            _storage.Save(_autori);
            return stari;
        }

        public Autor RemoveAutor(string brojLicneKarte)
        {
            Autor autor = GetAutorByBrojLicneKarte(brojLicneKarte);
            if (autor == null)
            {
                return null;
            }

            _autori.Remove(autor);
            _storage.Save(_autori);
            return autor;
        }
    }
}