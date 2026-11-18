using System;
using System.Collections.Generic;
using SajamKnjiga.Core.Models;
using SajamKnjiga.Core.Utils;

namespace SajamKnjiga.Core.DAO
{
    // Po uzoru na VehicleDAO iz CRUDExample (vezbe 3)
    public class PosetilacDAO
    {
        private readonly List<Posetilac> _posetioci;
        private readonly Storage<Posetilac> _storage;

        public PosetilacDAO()
        {
            _storage = new Storage<Posetilac>("posetioci.txt");
            _posetioci = _storage.Load();
        }

        public List<Posetilac> GetAllPosetioci()
        {
            return _posetioci;
        }

        public Posetilac GetPosetilacByBrojClanskeKarte(string brojKarte)
        {
            return _posetioci.Find(x => x.BrojClanskeKarte == brojKarte);
        }

         public Posetilac AddPosetilac(Posetilac posetilac)
        {
            // isti kljuc ne sme da postoji dva puta
            if (GetPosetilacByBrojClanskeKarte(posetilac.BrojClanskeKarte) != null)
            {
                return null;
            }

            _posetioci.Add(posetilac);
            _storage.Save(_posetioci);
            return posetilac;
        }

        public Posetilac UpdatePosetilac(Posetilac posetilac)
        {
            Posetilac stari = GetPosetilacByBrojClanskeKarte(posetilac.BrojClanskeKarte);
            if (stari == null)
            {
                return null;
            }

            stari.Ime = posetilac.Ime;
            stari.Prezime = posetilac.Prezime;
            stari.DatumRodjenja = posetilac.DatumRodjenja;
            stari.Adresa = posetilac.Adresa;
            stari.KontaktTelefon = posetilac.KontaktTelefon;
            stari.Email = posetilac.Email;
            stari.TrenutnaGodinaClanstva = posetilac.TrenutnaGodinaClanstva;
            stari.Status = posetilac.Status;
            _storage.Save(_posetioci);
            return stari;
        }

        public Posetilac RemovePosetilac(string brojKarte)
        {
            Posetilac posetilac = GetPosetilacByBrojClanskeKarte(brojKarte);
            if (posetilac == null)
            {
                return null;
            }

            _posetioci.Remove(posetilac);
            _storage.Save(_posetioci);
            return posetilac;
        }
    }
}