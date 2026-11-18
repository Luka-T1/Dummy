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
    }
}