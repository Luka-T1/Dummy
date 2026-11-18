using System;
using System.Text;
using SajamKnjiga.Core.DAO;
using SajamKnjiga.Core.Utils;

namespace SajamKnjiga.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            // da bi se lepo prikazivala nasa slova
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // DAO objekti se prave jednom i dele izmedju pogleda
            PosetilacDAO posetilacDao = new PosetilacDAO();
            AutorDAO autorDao = new AutorDAO();
            KnjigaDAO knjigaDao = new KnjigaDAO();
            IzdavacDAO izdavacDao = new IzdavacDAO();
            KupovinaDAO kupovinaDao = new KupovinaDAO();

            Povezivanje.Povezi(posetilacDao, autorDao, knjigaDao, izdavacDao, kupovinaDao);
        }
    }
}