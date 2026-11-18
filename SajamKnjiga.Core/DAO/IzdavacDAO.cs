using System;
using System.Collections.Generic;
using SajamKnjiga.Core.Models;
using SajamKnjiga.Core.Utils;

namespace SajamKnjiga.Core.DAO
{
    // Po uzoru na VehicleDAO iz CRUDExample (vezbe 3)
    public class IzdavacDAO
    {
        private readonly List<Izdavac> _izdavaci;
        private readonly Storage<Izdavac> _storage;

        public IzdavacDAO()
        {
            _storage = new Storage<Izdavac>("izdavaci.txt");
            _izdavaci = _storage.Load();
        }

        public List<Izdavac> GetAllIzdavaci()
        {
            return _izdavaci;
        }

        public Izdavac GetIzdavacBySifra(string sifra)
        {
            return _izdavaci.Find(x => x.Sifra == sifra);
        }

        public Izdavac AddIzdavac(Izdavac izdavac)
        {
            // isti kljuc ne sme da postoji dva puta
            if (GetIzdavacBySifra(izdavac.Sifra) != null)
            {
                return null;
            }

            _izdavaci.Add(izdavac);
            _storage.Save(_izdavaci);
            return izdavac;
        }

        public Izdavac UpdateIzdavac(Izdavac izdavac)
        {
            Izdavac stari = GetIzdavacBySifra(izdavac.Sifra);
            if (stari == null)
            {
                return null;
            }

            stari.Naziv = izdavac.Naziv;
            stari.SefIzdavaca = izdavac.SefIzdavaca;
            _storage.Save(_izdavaci);
            return stari;
        }

        public Izdavac RemoveIzdavac(string sifra)
        {
            Izdavac izdavac = GetIzdavacBySifra(sifra);
            if (izdavac == null)
            {
                return null;
            }

            _izdavaci.Remove(izdavac);
            _storage.Save(_izdavaci);
            return izdavac;
        }
    }
}