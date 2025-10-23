using Model;
using PoslovnaLogika;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;




namespace Diplomski
{
    public partial class StranicaZaXML : System.Web.UI.Page
    {
        public KorisnikServis kos = new KorisnikServis();
        public List<Korisnik> kor = new List<Korisnik>();

        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                Label1.Text = string.Empty;


            }



           
        }

        protected void IspisiXml_Click(object sender, EventArgs e)  // ispisuje XML na konzoli
        {



           
          // IspisujeXmlNaKonzolu();
            string xmlSadrzaj = DajFormatiraniXmlKaoString();
            Label1.Text = "<pre>" + Server.HtmlEncode(xmlSadrzaj) + "</pre>";
















        }
        protected void UsporediDvaXmla_Click(object sender, EventArgs e)  // uspoređuje dva XML-a
        {
            string apsolutnaPutanja2 = System.Web.Hosting.HostingEnvironment.MapPath("~/Xmlmapa/") + FileUpload2.FileName;
            string apsolutnaPutanja1 = System.Web.Hosting.HostingEnvironment.MapPath("~/Xmlmapa/") + FileUpload1.FileName;


          Label1.Text = XmlServis.XmlCompare(apsolutnaPutanja1, apsolutnaPutanja2);


        }
        
        protected void ExportUXml_Click(object sender, EventArgs e)  //  IZ BAZE U XML
        {

            KreiraXmlKorisnika();

            Label2.Text = "eksportirao iz baze";



        }

        protected void bt_uveziXml_Click(object sender, EventArgs e)  // S DISKA UČITAVA XML I SPREMA GA U MAPU "Xmlmapa"
        {

            if (FileUpload1.HasFile)
            {
                string apsolutnaPutanja = Path.Combine(Server.MapPath("~/Xmlmapa"), FileUpload1.FileName);
                FileUpload1.SaveAs(apsolutnaPutanja);
                Label1.Text = "učitani fajl: " + FileUpload1.FileName;

            }

            else
            {
                Label1.Text = "fajl nije učitan";
            }

        }

        protected void bt_uvezidrugiXml_Click(object sender, EventArgs e)  // S DISKA UČITAVA XML I SPREMA GA U MAPU "Xmlmapa"
        {

            if (FileUpload2.HasFile)
            {
                string apsolutnaPutanja2 = Path.Combine(Server.MapPath("~/Xmlmapa"), FileUpload2.FileName);
                FileUpload2.SaveAs(apsolutnaPutanja2);
                Label2.Text = "učitani fajl: " + FileUpload2.FileName;

            }

            else
            {
                Label2.Text = "fajl nije učitan";
            }

        }

        protected void BtUsporedi_Click(object sender, EventArgs e)   //uspoređuje dvije liste korisnika. jedna lista se puni iz XML-a, druga iz baze
        {
            string apsolutnaPutanja = Path.Combine(Server.MapPath("~/Xmlmapa"), FileUpload1.FileName);

            List<Korisnik> korprvi = DajXmlUListu(apsolutnaPutanja);
            List<Korisnik> kordrugi = kos.DajKorisnike();

            UsporediRijesiDviListeKorisnika(korprvi, kordrugi);
        }

        protected void SpremiXMLuBazu_Click(object sender, EventArgs e)  //sprema u bazu podatke iz XML-a, koristi stored proceduru.
        {
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Xmlmapa/") + fileName;

                //string filePath = Server.MapPath("~/Xmlmapa/") + fileName;  
                FileUpload1.SaveAs(filePath);

                string xml = File.ReadAllText(filePath);
                string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

                XmlDocument xd = new XmlDocument();
                xd.LoadXml(xml);
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertirajXML"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@xml", SqlDbType.Xml);
                        param.Value = xd.InnerXml;
                        cmd.Parameters.Add(param);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }


            }
            else
            {
                Label1.Text = "fajl nije učitan";
            }

        }


        public static List<Korisnik> DajXmlUListu(string apsolutnaPutanja)
        {
            XmlDocument xmldok = new XmlDocument();
            //xmldok.Load(apsolutnaPutanja);// ne da mi pristupiti

            string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Xmlmapa/korisnici.xml");

            xmldok.Load(filePath);
            XmlElement root = xmldok.DocumentElement;
            XmlNodeList nodes = root.GetElementsByTagName("korisnik");//korisnik

            XmlRootAttribute xra = new XmlRootAttribute();
            xra.ElementName = "korisnik";
            XmlSerializer xs = new XmlSerializer(typeof(Korisnik), xra);
            List<Korisnik> korisnici = new List<Korisnik>();


            foreach (XmlNode xmlNode in nodes)
            {
                Stream stream = new MemoryStream(Encoding.UTF8.GetBytes("<korisnik>" + xmlNode.InnerXml.ToString() + "</korisnik>"));
                korisnici.Add((Korisnik)xs.Deserialize(stream));
            }

            return korisnici;
        }



        public void UsporediRijesiDviListeKorisnika(List<Korisnik> korprvi, List<Korisnik> kordrugi) //treba li test za ovu metodu ??
        {

            List<Korisnik> korisniciBaza = korprvi; 
            List<Korisnik> korisniciXML = kordrugi;

            List<Korisnik> izmjenjeni = new List<Korisnik>();
            List<Korisnik> brisani = new List<Korisnik>();
            List<Korisnik> dodani = new List<Korisnik>();


            /////////////////////////////////////////////////////////////////////////////       


            foreach (Korisnik korisnikBaza in korisniciBaza)
            {
                bool jeDodaan = true;

                foreach (Korisnik korisnikXml in korisniciXML)
                {
                    if (korisnikBaza.KorisnikId == korisnikXml.KorisnikId)
                    {
                        jeDodaan = false;
                        izmjenjeni.Add(korisnikXml);
                        continue;
                    }

                }
                if (jeDodaan)
                {
                    brisani.Add(korisnikBaza);
                }

            }

            foreach (Korisnik korisnikXml in korisniciXML)
            {
                bool jeDodan = true;
                foreach (Korisnik korisnikBaza in korisniciBaza)
                {
                    if (korisnikXml.KorisnikId == korisnikBaza.KorisnikId)
                    {
                        jeDodan = false;
                        continue;
                    }

                }
                if (jeDodan)
                {
                    dodani.Add(korisnikXml);
                }
            }

            /////////////////////////////////////////AŽURIRANJE////////////////////////////////////

            if (izmjenjeni.Count > 0)
            {

                foreach (Korisnik korisnik in izmjenjeni)
                {
                    string lozinka = korisnik.Lozinka.ToString();
                    string ime = korisnik.Ime.ToString();
                    string prezime = korisnik.Prezime.ToString();
                    string email = korisnik.Email.ToString();
                    int korID = Convert.ToInt32(korisnik.KorisnikId);
                    string korisnickoIme = korisnik.KorisnickoIme.ToString();

                    kos.AzuriranjeKorisnika(lozinka, ime, prezime, email, korID, korisnickoIme);

                    Label1.Text = "korisnici azurirani";

                }
            }

            else
            {
                Label1.Text = "nije bilo korisnika za ažuriranje ";

            }


            /////////////////////////////////////////////////INSERTIRANJE /////////////////////////////////////

            if (dodani.Count > 0)
            {

                foreach (Korisnik korisnik in dodani)
                {
                    string lozinka = korisnik.Lozinka.ToString();
                    string ime = korisnik.Ime.ToString();
                    string prezime = korisnik.Prezime.ToString();
                    string email = korisnik.Email.ToString();
                    string korIme = korisnik.KorisnickoIme.ToString();
                    int korID = Convert.ToInt32(korisnik.KorisnikId);

                    kos.InsertiranjeKorisnika(lozinka, ime, prezime, email, korIme, korID);

                    Label1.Text = "insertirani korisnici";
                    Console.ReadKey();
                }
            }

            else
            {
                Label1.Text = "nije bilo novih korisnika ";


            }

        }



        public void KreiraXmlKorisnika()   // KREIRA XML DOKUMENT, SVE DOHVAĆENE KORISNIKE IZ TABLICE  SPREMA  U XML
        {
            kor = kos.DajKorisnike();    //IZ BAZE ZAPOSLJAVANJE, TABLICE KORISNIK, DOHVAĆA SVE KORISNIKE
            List<Korisnik> korisnici = kor;

            XmlDocument xmldok = new XmlDocument();
            XmlNode rootnode = xmldok.CreateElement("korisnici");
            xmldok.AppendChild(rootnode);

            foreach (Korisnik korisnik in korisnici)
            {

                XmlNode kornode = xmldok.CreateElement("korisnik");
                rootnode.AppendChild(kornode);

                var kor_id = xmldok.CreateElement("korisnik_id");
                kor_id.InnerText = korisnik.KorisnikId.ToString();
                kornode.AppendChild(kor_id);

                var kor_ime = xmldok.CreateElement("korisnicko_ime");
                kor_ime.InnerText = korisnik.KorisnickoIme.ToString();
                kornode.AppendChild(kor_ime);

                var loz = xmldok.CreateElement("lozinka");
                loz.InnerText = korisnik.Lozinka.ToString();
                kornode.AppendChild(loz);

                var ime = xmldok.CreateElement("ime");
                ime.InnerText = korisnik.Ime.ToString();
                kornode.AppendChild(ime);

                var prez = xmldok.CreateElement("prezime");
                prez.InnerText = korisnik.Prezime.ToString();
                kornode.AppendChild(prez);

                var email = xmldok.CreateElement("email");
                email.InnerText = korisnik.Email.ToString();
                kornode.AppendChild(email);
            }

            string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Xmlmapa/EksportIzBaze.xml");

            xmldok.Save(filePath);




        }



        private string DajFormatiraniXmlKaoString()   //ispisuje xml
        {
            try
            {
                if (!FileUpload1.HasFile)
                    return "Nijedna datoteka nije odabrana.";

                string folderPath = Server.MapPath("~/Xmlmapa/");
                string filePath = Path.Combine(folderPath, FileUpload1.FileName);

                if (!File.Exists(filePath))
                    FileUpload1.SaveAs(filePath);

                XmlDocument dok = new XmlDocument();
                dok.Load(filePath);

                // Kreiramo StringWriter za formatirani XML
                StringBuilder sb = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "    ", // 4 razmaka za uvlačenje
                    NewLineChars = "\r\n",
                    NewLineHandling = NewLineHandling.Replace
                };

                using (XmlWriter writer = XmlWriter.Create(sb, settings))
                {
                    dok.Save(writer);
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "Greška pri čitanju XML-a: " + ex.Message;
            }
        }



        

    }
}


