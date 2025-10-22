using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoslovnaLogika;
using System;
using System.Collections.Generic;
using Model;
using System.Diagnostics;

namespace Testovi
{
    [TestClass]
    public class KorisnikServisTest
    {
        [TestMethod]
        public void TestDajKorisnike()
        {
            try
            {
                KorisnikServis korisnikServis = new KorisnikServis();
                var korisnici = korisnikServis.DajKorisnike();

                Assert.IsNotNull(korisnici, "Lista korisnika ne smije biti null.");
                Assert.IsTrue(korisnici.Count > 0, "Očekuje se barem jedan korisnik.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test nije uspio. Greška: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestDajKorisnika()
        {
            try
            {
                KorisnikServis korisnikServis = new KorisnikServis();
                var korisnik = korisnikServis.DajKorisnika("test");

                Assert.IsNotNull(korisnik, "Korisnik ne smije biti null.");
                Assert.AreEqual("testKorisnik", korisnik.KorisnickoIme, "Korisničko ime se ne poklapa sa očekivanim.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test nije uspio. Greška: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestAzuriranjeKorisnika()
        {
            string lozinka = "novaLozinka";
            string ime = "novoIme";
            string prezime = "novoPrezime";
            string email = "novi@email.com";
            string korisnickoIme = "novoKorIme";
            int kor_id = 1;

            try
            {
                KorisnikServis korisnikServis = new KorisnikServis();

                korisnikServis.AzuriranjeKorisnika(lozinka, ime, prezime, email, kor_id, korisnickoIme);



            }
            catch (Exception ex)
            {
                Assert.Fail($"Test nije uspio. Greška: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestDajXmlUListu()
        {
            try
            {
                KorisnikServis korisnikServis = new KorisnikServis();
                var korisnici = korisnikServis.DajXmlUListu();

                Assert.IsNotNull(korisnici, "Lista korisnika ne sme biti null.");
                Assert.IsTrue(korisnici.Count > 0, "Očekuje se barem jedan korisnik.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test nije uspeo. Greška: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestInsertiranjeKorisnika()
        {
            string lozinka = "novaLozinka";
            string ime = "novoIme";
            string prezime = "novoPrezime";
            string email = "novi@email.com";
            string korisnickoIme = "novoKorIme";
            int kor_id = 1;

            try
            {
                KorisnikServis korisnikServis = new KorisnikServis();

                korisnikServis.InsertiranjeKorisnika(lozinka, ime, prezime, email, korisnickoIme, kor_id);

            }
            catch (Exception ex)
            {
                Assert.Fail($"Test nije uspeo. Greška: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestDajKorisnikaPoKorimeLozinka()
        {
            try
            {
                KorisnikServis korisnikServis = new KorisnikServis();
                var korisnik = korisnikServis.DajKorisnikaPoKorimeLozinka("test", "test");

                Assert.IsNotNull(korisnik, "Korisnik ne sme biti null.");
                Assert.AreEqual("testKorisnik", korisnik.KorisnickoIme, "Korisničko ime se ne poklapa sa očekivanim.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test nije uspeo. Greška: {ex.Message}");
            }
        }

        [TestMethod]

        public void DajXmlUListu()//metoda postoji na dva mjesta
        {
            try
            {
                KorisnikServis korisnikServis = new KorisnikServis();
                List<Korisnik> korisnici = korisnikServis.DajXmlUListu();

                Assert.IsNotNull(korisnici);
                Assert.IsTrue(korisnici.Count > 0);
            }

            catch (Exception ex)

            {
                Assert.Fail($"Iznimka prilikom izvođenja testa: {ex.Message}");
            }
        }
    }

    
}
