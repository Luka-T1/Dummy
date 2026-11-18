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
    }
}