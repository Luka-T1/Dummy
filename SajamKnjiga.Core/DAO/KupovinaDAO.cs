using System;
using System.Collections.Generic;
using SajamKnjiga.Core.Models;
using SajamKnjiga.Core.Utils;

namespace SajamKnjiga.Core.DAO
{
    // Po uzoru na VehicleDAO iz CRUDExample (vezbe 3)
    // kupovina nema svoj kljuc pa je trazimo po clanskoj karti i ISBN-u
    public class KupovinaDAO
    {
        private readonly List<Kupovina> _kupovine;
        private readonly Storage<Kupovina> _storage;

        public KupovinaDAO()
        {
            _storage = new Storage<Kupovina>("kupovine.csv");
            _kupovine = _storage.Load();
        }

        public List<Kupovina> GetAllKupovine()
        {
            return _kupovine;
        }

        public Kupovina GetKupovina(string brojKarte, string isbn)
        {
            return _kupovine.Find(k => k.Posetilac.BrojClanskeKarte == brojKarte && k.Knjiga.ISBN == isbn);
        }

        public Kupovina AddKupovina(Kupovina kupovina)
        {
            if (GetKupovina(kupovina.Posetilac.BrojClanskeKarte, kupovina.Knjiga.ISBN) != null)
            {
                return null;
            }

            _kupovine.Add(kupovina);
            kupovina.Posetilac.ListaKupovina.Add(kupovina);
            kupovina.Knjiga.Kupci.Add(kupovina.Posetilac);
            _storage.Save(_kupovine);
            return kupovina;
        }

        public Kupovina UpdateKupovina(Kupovina kupovina)
        {
            Kupovina stara = GetKupovina(kupovina.Posetilac.BrojClanskeKarte, kupovina.Knjiga.ISBN);
            if (stara == null)
            {
                return null;
            }

            stara.DatumKupovine = kupovina.DatumKupovine;
            stara.Ocena = kupovina.Ocena;
            stara.Komentar = kupovina.Komentar;

            _storage.Save(_kupovine);
            return stara;
        }

        public Kupovina RemoveKupovina(string brojKarte, string isbn)
        {
            Kupovina kupovina = GetKupovina(brojKarte, isbn);
            if (kupovina == null)
            {
                return null;
            }

            _kupovine.Remove(kupovina);
            kupovina.Posetilac.ListaKupovina.Remove(kupovina);
            kupovina.Knjiga.Kupci.Remove(kupovina.Posetilac);
            _storage.Save(_kupovine);
            return kupovina;
        }
    }
}
