using System;
using System.Collections.Generic;
using SajamKnjiga.Core.DAO;
using SajamKnjiga.Core.Models;

namespace SajamKnjiga.Core.Utils
{
    // u fajlovima cuvamo samo kljuceve (ISBN, licna karta, sifra, clanska karta)
    // posle ucitavanja ovde "prazne" objekte menjamo pravim objektima iz DAO-a
    public static class Povezivanje
    {
        public static void Povezi(PosetilacDAO posetilacDao, AutorDAO autorDao, KnjigaDAO knjigaDao, IzdavacDAO izdavacDao, KupovinaDAO kupovinaDao)
        {
            foreach (Izdavac izdavac in izdavacDao.GetAllIzdavaci())
            {
                if (izdavac.SefIzdavaca != null)
                {
                    izdavac.SefIzdavaca = autorDao.GetAutorByBrojLicneKarte(izdavac.SefIzdavaca.BrojLicneKarte);
                }
            }

            foreach (Knjiga knjiga in knjigaDao.GetAllKnjige())
            {
                if (knjiga.Izdavac != null)
                {
                    knjiga.Izdavac = izdavacDao.GetIzdavacBySifra(knjiga.Izdavac.Sifra);
                }

                List<Autor> autori = new List<Autor>();
                foreach (Autor a in knjiga.Autori)
                {
                    Autor autor = autorDao.GetAutorByBrojLicneKarte(a.BrojLicneKarte);
                    if (autor != null)
                    {
                        autori.Add(autor);
                        autor.Knjige.Add(knjiga);
                    }
                }
                knjiga.Autori = autori;

                if (knjiga.Izdavac != null)
                {
                    knjiga.Izdavac.Knjige.Add(knjiga);
                    foreach (Autor autor in autori)
                    {
                        if (!knjiga.Izdavac.Autori.Contains(autor))
                        {
                            knjiga.Izdavac.Autori.Add(autor);
                        }
                    }
                }
            }

            foreach (Kupovina kupovina in kupovinaDao.GetAllKupovine())
            {
                Posetilac posetilac = posetilacDao.GetPosetilacByBrojClanskeKarte(kupovina.Posetilac.BrojClanskeKarte);
                Knjiga knjiga = knjigaDao.GetKnjigaByISBN(kupovina.Knjiga.ISBN);
                if (posetilac == null || knjiga == null)
                {
                    continue;
                }

                kupovina.Posetilac = posetilac;
                kupovina.Knjiga = knjiga;
                posetilac.ListaKupovina.Add(kupovina);
                knjiga.Kupci.Add(posetilac);
            }
        }
    }
}