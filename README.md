Opis aplikacije

Aplikacija je rađena u asp.net okruženju pomoću web formi. Za današnje prilike mogli bismo slobodno reći korištene su arhaične tehnologije. Od programskih jezika korišten je C# programski jezik, SQL, html, java script te ado.net za pristup podacima. Aplikacija ima za cilj manipuliranje XML dokumentima korištenjem metoda iz .net okruženja. Osnovni koncept aplikacije podijeljen je u 3 dijela. To su model ,pristup podacima i poslovna logika.

Model sadrži klasu Korisnik Poslovna logika sadrži klase: KorisnikServis.cs XmlServis.cs

Pristup podatcima sadrži klase: KorisnikDal.cs XmlDal.cs

Šta radi aplikacija? Aplikacija manipulira xml dokumentom koristeći određene metode iz .net okruženja napisane u C# programskom jeziku. Funkcionalnosti aplikacije su slijedeće: Učitava XML dokument Ispisuje XML dokument Eksportira podatke iz baze u XML dokument Sprema u bazu podatke iz XML dokumenta Uspoređuje dva XML dokumenta po zadanim parametrima Uspoređuje dvije liste i ažurira podatke

U nastavku slijedi detaljnije objašnjenje svake funkcionalnosti.

Učitava XML dokument Za učitavanje datoteke s korisničkog računala na poslužitelj koristi se metoda “bt_uveziXml_Click”. Navedena metoda je događajni hendler koji se okida na gumb “bt_uveziXml”.

Metoda provjerava je li korisnik odabrao datoteku za učitavanje. Učitavanje se vrši pomoću kontrola FileUpload1.HasFile. Ako je datoteka odabrana generira se apsolutna putanja za spremanje datoteke kombiniranjem relativne putanje mape Xmlmapa s imenom datoteke koju je korisnik odabrao korištenjem Server.MapPath("~/Xmlmapa"). Datoteka se sprema na generiranu apsolutnu putanju na poslužitelju pomoću FileUpload1.SaveAs(apsolutnaPutanja). Tekstualni sadržaj labele Label1 se postavlja na poruku koja potvrđuje/demantira učitavanje datoteke.

Ispisuje XML dokument Metoda DajFormatiraniXmlKaoString uzima XML datoteku koju je korisnik odabrao u kontroli FileUpload1, sprema je na server ako još nije pohranjena, učitava sadržaj u XmlDocument i formatira XML tako da bude čitljiv s uvlačenjem i novim redovima. Rezultat vraća kao string, koji se u događajnom hendleru IspisiXml_Click prikazuje u Labeli koristeći HTML escape i 11:02 23.10.2025.tag. Ako se dogodi greška ili datoteka nije odabrana, metoda vraća odgovarajuću poruku.

Eksportira podatke iz baze u XML dokument
Eksport podataka iz baze u XML ostvaruje se okidanjem metode ExportUXml_Click koja poziva metodu KreiraXmlKorisnika.
Metoda KreiraXmlKorisnika kreira XML dokument i sve dohvaćene podatke iz tablice sprema u XML. Metoda radi slijedeće korake:
Dohvaća podatke iz baze podataka korištenjem metode DajKorisnike();
Podatke sprema u listu objekata nakon čega se stvara XML dokument, iterira se kroz korisnike te se na posljetku sprema XML dokument na generiranu apsolutnu putanju na poslužitelju.


Sprema u bazu podatke iz XML dokumenta
Spremanje podataka iz XML dokumenta u bazu vrši se pomoću metode SpremiXMLuBazu_Click(object sender, EventArgs e) koja se okida na gumb SpremiXMLuBazu. Za spremanje podataka iz XML dokumenta u bazu podataka metoda koristi pohranjenu proceduru InsertirajXML


Uspoređuje dva XML dokumenta
Okidanjem događaja UsporediDvaXmla_Click poziva se metoda XmlCompare iz klase XmlServis koja uspoređuje sadržaje dva XML dokumenta koji sadrže podatke o korisnicima. Usporedba se vrši na način da se učitaju XML dokumenti koji se deserijaliziraju u liste korisnika te se koriste različite* metode za pronalaženje razlika između dviju lista. Liste se uspoređuju na način da se:



traže korisnici koji se nalaze samo u jednoj listi (imaAnemaB i imaBnemaA)

traže korisnici koji se razlikuju po svojim svojstvima (sviRazlicitiKorisniciPoElementima).
Rezultati usporedbe se spremaju u odgovarajuće XML datoteke na disku.
Za obavljanje ovog složenog posla koriste se i klase XmlComparerId i XmlComparer koje  implementiraju sučelje IEqualityComparer što omogućuje usporedbu objekata klase Korisnik.
XmlComparerId provjerava jesu li dva korisnika jednaki samo prema njihovom ID-u.
XmlComparer provjerava jesu li dva korisnika jednaki po svim svojstvima.


Uspoređuje dvije liste korisnika
U ovoj funkcionalnosti uspoređuju se i ažuriraju dvije liste korisnika te ovisno o rezultatu insertiraju u bazu. Liste se pune iz različitih izvora. Jedna lista puni se iz baze dok se druga lista pun iz Xml-a . Liste se uspoređuju pomoću metode UsporediRijesiDviListeKorisnika
Metoda prolazi kroz svakog korisnika u jednoj listi i uspoređuje(po ID-u) ga s korisnikom u drugoj listi.
Ako korisnik iz baze postoji u xmlu dodaje se u listu “izmijenjeni” što znači da je došlo do promjene u korisniku.
Ako korisnik iz baze nije pronađen u XMLu dodaje se u listu “brisani” što znači da je brisan iz XMLa.
Prolazi se kroz korisnike u listi “korisniciXML” i traže oni koji nisu u listi “korisniciBaza”. Takvi korisnici se dodaju u listu “dodani”.


Ako postoje korisnici u listi izmjenjeni, metoda AzuriranjeKorisnika ažurira podatke o tim korisnicima u bazi podataka.
Ako postoje korisnici u listi dodani, metoda InsertiranjeKorisnika insertira te korisnike u bazu podataka.

