using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoslovnaLogika;
using Model;
using System.Security.Cryptography;
using System.Data;



namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void DajKorisnike()
        {
            try
            {
                KorisnikServis korisnikServis = new KorisnikServis();
                List<Korisnik> korisnici = korisnikServis.DajKorisnike();

                bool imaKorisnika = korisnici.Count > 0;
                Assert.AreEqual(imaKorisnika, true);
            }
            catch (Exception)
            {

                Assert.AreEqual(1, 2);
            }

        }

       

[TestClass]
    public class KorisnikServisTest
    {
        [TestMethod]
        public void DajKorisnike()
        {
            try
            {
                KorisnikServis korisnikServis = new KorisnikServis();
                List<Korisnik> korisnici = korisnikServis.DajKorisnike();

                Assert.IsNotNull(korisnici, "Lista korisnika ne sme biti null.");
                Assert.IsTrue(korisnici.Count > 0, "Očekuje se barem jedan korisnik.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test je neuspešan. Greška: {ex.Message}");
            }
        }
    }



    [TestMethod]


        public void AzuriranjeKor()
        {
            //string connString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            //string lozinka = "novaLozinka";
            //string ime = "novoIme";
            //string prezime = "novoPrezime";
            //string email = "novi@email.com";
            //int kor_id = 1;
            //string korisnickoIme = "novoKorisnickoIme";
            //try
            //{
            //    KorisnikServis korisnikServis = new KorisnikServis();

            //    korisnikServis.AzuriranjeKorisnika(lozinka, ime, prezime, email, kor_id,korisnickoIme);


            //    Assert.AreEqual(1, 1);
            //}

            //catch (Exception ex)
            //{
            //    Assert.AreEqual(1, 2);
            //}
        }

        [TestMethod]

        public void DajKorisnika()
        {
            string korIme = "";
            try
            {
                KorisnikServis korisnikServis = new KorisnikServis();
                korisnikServis.DajKorisnika(korIme);

                Assert.AreEqual(1, 1);

            }

            catch (Exception ex)
            {
                Assert.AreEqual (1, 2);
            }
        }

        [TestMethod]

        public void InsertiranjeKorisnika()
        {
            string lozinka = "test";
            string ime = "test";
            string prezime = "test";
            string email = "test";
            string korIme = "test";
            int korId = 1;


            try
            {
                KorisnikServis korisnikServis = new KorisnikServis();
                korisnikServis.InsertiranjeKorisnika(lozinka, ime, prezime, email, korIme, korId);
                Assert.AreEqual(1, 1);
            }

            catch (Exception ex)
            {
                Assert.AreEqual(1, 2);
            }
           
        }

        [TestMethod]

        public void DajKorisnikaPoKorimeLozinka()
        {
            string psw = "test";
            string ime = "test";

            try
            {
                KorisnikServis korisnikServis = new KorisnikServis();
                korisnikServis.DajKorisnikaPoKorimeLozinka(ime, psw);
                Assert.AreEqual(1, 1);
            }

            catch (Exception ex)
            {
                Assert.AreEqual(1, 2);
            }
        }

    }
}

