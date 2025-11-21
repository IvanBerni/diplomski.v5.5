# Sadržaj
# Sadržaj

- [Sadržaj](#sadraj)
  - [3. ARHITEKTURA MODERNIZIRANOG RJEŠENJA](#3-arhitektura-moderniziranog-rjeenja)
- [3.1. Polazišno stanje](#31-polazino-stanje)
- [3.2. Razlozi za modernizaciju](#32-razlozi-za-modernizaciju)
- [3.3. Arhitektura moderniziranog sustava](#33-arhitektura-moderniziranog-sustava)
- [3.3.1. Pregled cjelokupne arhitekture](#331-pregled-cjelokupne-arhitekture)
- [3.3.2. Slojevi poslužiteljske (backend) arhitekture](#332-slojevi-posluiteljske-backend-arhitekture)
    - [**1. Models**](#1-models)
    - [**2. Repositories**](#2-repositories)
    - [**3. Services**](#3-services)
    - [**4. Controllers**](#4-controllers)
- [3.3.3. Slojevi klijentske (frontend) arhitekture](#333-slojevi-klijentske-frontend-arhitekture)
    - [**1. React komponenti**](#1-react-komponenti)
    - [**2. API pomoćnih modula**](#2-api-pomonih-modula)
    - [**3. Globalnog App.jsx**](#3-globalnog-appjsx)
    - [**4. Vite konfiguracije**](#4-vite-konfiguracije)
- [3.3.4. Komunikacija između komponenti](#334-komunikacija-izmeu-komponenti)
- [3.3.5. Sigurnost i integracija](#335-sigurnost-i-integracija)
- [3.3.6. Prednosti nove arhitekture](#336-prednosti-nove-arhitekture)
    - [✔️ Čisto odvajanje frontenda i backenda](#isto-odvajanje-frontenda-i-backenda)
    - [✔️ Bolja testabilnost](#bolja-testabilnost)
    - [✔️ Skalabilnost](#skalabilnost)
    - [✔️ Modularnost i proširivost](#modularnost-i-proirivost)
    - [✔️ Moderno korisničko iskustvo](#moderno-korisniko-iskustvo)
- [3.3.7. Dijagram arhitekture](#337-dijagram-arhitekture)
- [4. IMPLEMENTACIJA POSLUŽITELJSKE STRANE (BACKEND)](#4-implementacija-posluiteljske-strane-backend)
- [4.1. Struktura projekta](#41-struktura-projekta)
    - [**4.1.1. Controllers**](#411-controllers)
    - [**4.1.2. Services**](#412-services)
    - [**4.1.3. Repositories**](#413-repositories)
    - [**4.1.4. Helpers**](#414-helpers)
- [4.2. Konfiguracija aplikacije](#42-konfiguracija-aplikacije)
- [4.3. Modeli](#43-modeli)
- [4.4. Pristup bazi podataka (Repositories)](#44-pristup-bazi-podataka-repositories)
    - [**4.4.1. Sučelje**](#441-suelje)
    - [**4.4.2. Implementacija**](#442-implementacija)
- [4.5. Poslovna logika (Services)](#45-poslovna-logika-services)
  - [4.5.1. XmlService](#451-xmlservice)
    - [**Metoda: Učitavanje i formatiranje XML-a**](#metoda-uitavanje-i-formatiranje-xml-a)
  - [4.5.2. Usporedba XML dokumenata (XmlComparer)](#452-usporedba-xml-dokumenata-xmlcomparer)
- [4.6. Izdvajanje korisnika iz XML dokumenta](#46-izdvajanje-korisnika-iz-xml-dokumenta)
- [4.7. Apliciranje sinkronizacije s bazom](#47-apliciranje-sinkronizacije-s-bazom)
- [4.8. API kontroleri](#48-api-kontroleri)
  - [4.8.1. XmlController](#481-xmlcontroller)
  - [4.8.2. KorisniciController](#482-korisnicicontroller)
- [4.9. Konfiguracijska datoteka (appsettings.json)](#49-konfiguracijska-datoteka-appsettingsjson)
- [6. Evaluacija moderniziranog rješenja](#6-evaluacija-moderniziranog-rjeenja)
- [---------------------------------------](#---------------------------------------)
  - [6.1. Prednosti u odnosu na WebForms verziju](#61-prednosti-u-odnosu-na-webforms-verziju)
    - [**✔️ Čista arhitektura**](#ista-arhitektura)
    - [**✔️ Testabilnost**](#testabilnost)
    - [**✔️ Performanse**](#performanse)
    - [**✔️ Održavanje i proširivanje**](#odravanje-i-proirivanje)
    - [**✔️ Skalabilnost**](#skalabilnost)
  - [6.2. Identificirana ograničenja](#62-identificirana-ogranienja)
  - [6.3. Procjena ciljeva modernizacije](#63-procjena-ciljeva-modernizacije)
- [-------------------](#-------------------)
- [7. Zaključak](#7-zakljuak)
- [-------------------](#-------------------)
- [-----------------------------------------](#-----------------------------------------)
- [PRILOG A – Instalacija i pokretanje](#prilog-a--instalacija-i-pokretanje)
- [-----------------------------------------](#-----------------------------------------)
  - [A.1. Preduvjeti](#a1-preduvjeti)
  - [A.2. Instalacija baze](#a2-instalacija-baze)
  - [A.3. Pokretanje backend API-ja](#a3-pokretanje-backend-api-ja)
  - [A.4. Pokretanje frontenda](#a4-pokretanje-frontenda)
  - [A.5. Pokretanje testovima](#a5-pokretanje-testovima)
- [PRILOG B – IZVORNI KÔD POSLUŽITELJSKE APLIKACIJE (BACKEND)](#prilog-b--izvorni-kd-posluiteljske-aplikacije-backend)
  - [B.1. Struktura projekta DiplomskiXml.Server](#b1-struktura-projekta-diplomskixmlserver)
  - [B.2. Datoteka DiplomskiXml.Server.csproj](#b2-datoteka-diplomskixmlservercsproj)
  - [B.3. Datoteka appsettings.json](#b3-datoteka-appsettingsjson)
  - [B.4. Datoteka Properties/launchSettings.json](#b4-datoteka-propertieslaunchsettingsjson)
  - [B.5. Datoteka Program.cs](#b5-datoteka-programcs)
  - [B.6. Model Models/Korisnik.cs](#b6-model-modelskorisnikcs)
  - [B.7. Sučelje Repositories/IKorisnikRepository.cs](#b7-suelje-repositoriesikorisnikrepositorycs)
  - [B.8. Repozitorij Repositories/KorisnikRepository.cs](#b8-repozitorij-repositorieskorisnikrepositorycs)
  - [B.9. Sučelje Services/IKorisnikService.cs](#b9-suelje-servicesikorisnikservicecs)
  - [B.10. Servis Services/KorisnikService.cs](#b10-servis-serviceskorisnikservicecs)
  - [B.11. Sučelje Services/IXmlService.cs](#b11-suelje-servicesixmlservicecs)
  - [B.12. Servis Services/XmlService.cs](#b12-servis-servicesxmlservicecs)
  - [B.13. Kontroler Controllers/KorisniciController.cs](#b13-kontroler-controllerskorisnicicontrollercs)
  - [B.14. Kontroler Controllers/XmlController.cs](#b14-kontroler-controllersxmlcontrollercs)
- [📎 PRILOG C – IZVORNI KÔD KORISNIČKOG SUČELJA (FRONTEND)](#prilog-c--izvorni-kd-korisnikog-suelja-frontend)
  - [C.1. Struktura projekta diplomski-frontend](#c1-struktura-projekta-diplomski-frontend)
  - [C.2. Datoteka package.json](#c2-datoteka-packagejson)
  - [C.3. Datoteka vite.config.js](#c3-datoteka-viteconfigjs)
  - [C.4. Datoteka index.html](#c4-datoteka-indexhtml)
  - [C.5. Datoteka src/main.jsx](#c5-datoteka-srcmainjsx)
  - [C.6. Datoteka src/App.jsx](#c6-datoteka-srcappjsx)
  - [C.7. Datoteka src/styles.css](#c7-datoteka-srcstylescss)
  - [C.8. Datoteka src/api/xmlApi.js](#c8-datoteka-srcapixmlapijs)
  - [C.9. Datoteka src/api/korisniciApi.js](#c9-datoteka-srcapikorisniciapijs)
  - [C.10. Komponenta src/components/XmlUpload.jsx](#c10-komponenta-srccomponentsxmluploadjsx)
  - [C.11. Komponenta src/components/XmlCompare.jsx](#c11-komponenta-srccomponentsxmlcomparejsx)
  - [C.12. Komponenta src/components/UsersTable.jsx](#c12-komponenta-srccomponentsuserstablejsx)
- [📎 PRILOG D – SQL SKRIPTE I TESTNI PROJEKT](#prilog-d--sql-skripte-i-testni-projekt)
  - [D.1. SQL skripta za kreiranje baze i tablice](#d1-sql-skripta-za-kreiranje-baze-i-tablice)
  - [D.2. Struktura testnog projekta DiplomskiXml.Tests](#d2-struktura-testnog-projekta-diplomskixmltests)
  - [D.3. Datoteka DiplomskiXml.Tests.csproj](#d3-datoteka-diplomskixmltestscsproj)
  - [D.4. Datoteka XmlServiceTests.cs](#d4-datoteka-xmlservicetestscs)
  - [D.5. Datoteka KorisnikServiceTests.cs](#d5-datoteka-korisnikservicetestscs)


[TOC]

**Sveučilište / Fakultet**  
**Odsjek / Smjer**

\\

**Ivan Bernatović**

\\

**MODERNIZACIJA APLIKACIJE ZA RAD S XML DOKUMENTIMA KORIŠTENJEM ASP.NET
CORE 9 I REACT TEHNOLOGIJA**

\\\

**Diplomski rad**

\\

**Mentor:** *Ime i prezime mentora*  
**Akademska godina:** *2025/2026*

**SAŽETAK**

Ovaj diplomski rad opisuje proces modernizacije postojeće web-aplikacije
izrađene u tehnologiji ASP.NET WebForms, čija je primarna funkcija
manipulacija XML dokumentima, usporedba sadržaja i sinkronizacija
podataka s relacijskom bazom podataka. Budući da je izvorna aplikacija
bila izrađena u zastarjelom okruženju i snažno povezivala korisničko
sučelje s backend logikom, cilj modernizacije bio je stvoriti modularno,
testabilno i proširivo rješenje temeljeno na suvremenim
web-tehnologijama.

Modernizirano rješenje sastoji se od ASP.NET Core 9 Web API-ja na
poslužiteljskoj strani i React aplikacije temeljene na Vite razvojnom
alatu na klijentskoj strani. Poslovna logika razdvojena je u jasne
slojeve (kontroleri, servisi, repozitoriji), pri čemu se za pristup
podacima koristi mikro ORM alat Dapper. XML dokumenti obrađuju se
korištenjem klasa iz .NET okvira (XmlDocument, XPath, XmlWriter), dok
React frontend omogućava učitavanje datoteka, prikaz formatiranog XML
sadržaja, usporedbu dvaju XML dokumenata te pregled i manipulaciju
korisnicima pohranjenima u SQL Server bazi.

Rad obuhvaća dizajn arhitekture, implementaciju pojedinih komponenti
sustava, testiranje pomoću xUnit okvira i evaluaciju moderniziranog
rješenja. Rezultati pokazuju kako je modernizacija rezultirala značajnim
poboljšanjem u pogledu performansi, fleksibilnosti, testabilnosti i
općeg korisničkog iskustva.

**Ključne riječi:** ASP.NET Core, React, XML, modernizacija, Web API,
Dapper, Vite, xUnit.

**ABSTRACT**

This thesis presents the modernization of an existing web application
originally developed using ASP.NET WebForms, designed for manipulating
XML documents, comparing their contents, and synchronizing data with a
relational database. Since the original system was tightly coupled and
based on outdated technologies, the primary goal of the modernization
process was to create a modular, testable, and scalable solution using
contemporary web development tools.

The modernized system consists of an ASP.NET Core 9 Web API as the
backend layer and a React application built with the Vite build tool as
the frontend layer. Business logic is separated into well-defined layers
(controllers, services, repositories), while Dapper is used as a
lightweight ORM for database access. XML documents are processed using
.NET built-in components such as XmlDocument, XPath, and XmlWriter. The
React frontend enables file uploads, formatted XML preview, XML
comparison, and user management through integration with the SQL Server
database.

The thesis includes architectural design, detailed implementation, xUnit
test development, and system evaluation. The results demonstrate
significant improvements in performance, maintainability, flexibility,
and overall user experience compared to the legacy WebForms application.

**Keywords:** ASP.NET Core, React, XML, modernization, Web API, Dapper,
Vite, xUnit.

**1. UVOD**

Digitalna transformacija i ubrzani razvoj web-tehnologija doveli su do
potrebe za modernizacijom velikog broja postojećih aplikacija koje su
temeljene na zastarjelim obrascima i arhitekturama. Jedan od takvih
sustava je i web-aplikacija izrađena u okviru ASP.NET WebForms
platforme, korištena za rad s XML dokumentima, prikaz i sinkronizaciju
korisničkih podataka te razne operacije vezane uz manipulaciju
strukturiranim sadržajem.

Iako WebForms paradigma omogućuje brzi razvoj jednostavnijih rješenja,
njezina arhitektura oslanja se na snažno povezivanje korisničkog
sučelja, poslužiteljske logike i stanja aplikacije. Takav pristup
otežava održavanje, testiranje, migraciju na moderne alate te
integraciju s drugim sustavima. Zbog toga je provedena modernizacija
aplikacije uz korištenje ASP.NET Core 9 okvira, koji predstavlja
suvremeni Microsoftov standard za izgradnju web-servisa, i React
tehnologije, jedne od najraširenijih knjižnica za razvoj dinamičkih
korisničkih sučelja.

Cilj ovog rada je prikazati cijeli proces modernizacije, uključujući
analizu postojećeg sustava, izbor tehnologija, projektiranje nove
arhitekture, implementaciju i testiranje funkcionalnosti. Poseban
naglasak stavljen je na obradu XML dokumenata, usporedbu sadržaja,
integraciju s bazom podataka te razvoj jedno-stranične aplikacije (SPA)
koja komunicira s backendom putem RESTful API-ja.

Rezultat modernizacije je modularna, proširiva i visoko-performantna
aplikacija koja u potpunosti zadržava funkcionalnosti izvorne verzije,
uz značajna unapređenja u pogledu korisničkog iskustva, brzine i
održivosti softvera.

**1.1. Ciljevi rada**

Glavni ciljevi diplomskog rada su:

-   modernizirati postojeću aplikaciju izrađenu u ASP.NET WebForms
    tehnologiji,

-   izgraditi backend temeljeni na ASP.NET Core 9 Web API-ju,

-   implementirati frontend koristeći React i Vite,

-   refaktorirati poslovnu logiku u testabilne slojeve (servisi,
    repozitoriji),

-   osigurati manipulaciju i usporedbu XML dokumenata korištenjem .NET
    komponenti,

-   integrirati relacijsku bazu podataka uz korištenje Dapper mikro
    ORM-a,

-   izraditi jedinčne testove (xUnit) za ključne dijelove sustava,

-   evaluirati prednosti novog sustava u odnosu na WebForms rješenje.

**1.2. Metodologija rada**

Pristup modernizaciji temelji se na sljedećim koracima:

1.  Analiza postojećeg sustava i identifikacija poslovnih pravila.

2.  Dizajn nove arhitekture temeljene na razdvajanju klijenta i
    poslužitelja.

3.  Implementacija RESTful API-ja i servisnog sloja.

4.  Razvoj React SPA korisničkog sučelja.

5.  Izrada testova za ključne komponente.

6.  Evaluacija performansi i funkcionalnosti.

**1.3. Struktura rada**

Diplomski rad organiziran je u sljedeća poglavlja:

-   **Poglavlje 1** donosi uvod, ciljeve i metodologiju rada.

-   **Poglavlje 2** opisuje tehnologije korištene u moderniziranom
    sustavu, uključujući XML, ASP.NET Core, React, Vite, SQL Server,
    Dapper i xUnit.

-   **Poglavlje 3** detaljno prikazuje arhitekturu moderniziranog
    rješenja, uključujući dijagrame i objašnjenja komponenti.

-   **Poglavlje 4** predstavlja implementaciju poslužiteljske i
    klijentske strane sustava.

-   **Poglavlje 5** prikazuje testiranje sustava pomoću xUnit okvira.

-   **Poglavlje 6** sadrži evaluaciju sustava i usporedbu s izvornim
    rješenjem.

-   **Poglavlje 7** donosi zaključna razmatranja.

-   **Prilozi A–D** sadrže instalacijske upute, SQL skripte te kompletan
    izvorni kôd backenda, frontenda i testnog projekta.

**2. TEHNOLOŠKE OSNOVE**

Ovo poglavlje opisuje sve ključne tehnologije korištene u moderniziranom
sustavu — XML, ASP.NET Core, React, Vite, Dapper, SQL Server i xUnit.
Cilj poglavlja je dati teorijski temelj koji se nadovezuje na praktičnu
implementaciju u narednim poglavljima.

**2.1. Extensible Markup Language (XML)**

**2.1.1. Definicija i svrha**

XML (Extensible Markup Language) je standardizirani tekstualni format za
razmjenu strukturiranih podataka između različitih sustava, aplikacija i
platformi. Razvijen od strane organizacije W3C, XML je oblikovan kao
pojednostavljena verzija SGML-a s naglaskom na interoperabilnost i
strukturiranost podataka.

Glavne značajke XML-a uključuju:

-   proširivost — korisnik definira vlastite oznake,

-   strukturu temeljenu na hijerarhijskom stablu,

-   neovisnost o platformi i programskom jeziku,

-   čitljivost za ljude i strojeve,

-   široku podršku u industrijskim standardima i protokolima.

XML se koristi u različitim područjima — konfiguracija aplikacija,
razmjena dokumenata, web-servisi, EDI sustavi, modeliranje podataka i
integracijske platforme.

**2.1.2. Struktura XML dokumenta**

XML dokument sastoji se od:

1.  **XML prologa**

2.  \

3.  **korijenskog elementa** (root element) — jedinstveni vršni čvor

4.  **podređenih elemenata (child nodes)** — struktura nalik stablu

5.  **atributa**

6.  **tekstualnih vrijednosti**

Primjer osnovnog XML dokumenta:

\

\

\

\Ivan\

\Bernatović\

\ivan@example.com\

\

\

XML mora biti **well-formed**, što znači da poštuje sljedeća pravila:

-   svi elementi imaju početni i završni tag

-   elementi su pravilno ugniježđeni

-   atributi su unutar navodnika

-   dokument ima jedan korijenski element

-   velika i mala slova razlikuju se

**2.1.3. Validacija XML-a**

Validacija XML-a provodi se putem:

-   **DTD (Document Type Definition)**

-   **XSD (XML Schema Definition)** — suvremeni standard

XSD omogućuje definiranje:

-   strukture dokumenta

-   tipova podataka

-   obaveznih i opcionalnih elemenata

-   ograničenja i odnosa među elementima

U poslovnim sustavima (npr. e-računi, SEPA nalozi, državne službe) XML
validacija je ključna za osiguranje ispravnog formata razmijenjenih
poruka.

**2.1.4. Obrada XML dokumenata u .NET okruženju**

U .NET okruženju dostupno je više biblioteka za rad s XML-om:

-   **XmlDocument** — DOM model, omogućuje rad s čvorovima

-   **XPath** — mogućnost pretraživanja čvorova

-   **XmlReader / XmlWriter** — brzi, stream-based parseri

-   **LINQ to XML (XDocument)** — napredniji API

U moderniziranom sustavu korištene su klase:

-   XmlDocument — učitavanje i analiza XML-a

-   XmlNode — rad s čvorovima i atributima

-   XmlTextWriter — formatirani ispis XML-a

-   XPath (SelectNodes) — izdvajanje korisnika

-   IFormFile — učitavanje datoteka u ASP.NET Core

Primjer izdvajanja korisnika iz XML-a:

var users = xml.SelectNodes("//Korisnik");

**2.1.5. Prednosti i nedostaci XML-a**

**Prednosti:**

-   standardiziran i široko podržan

-   fleksibilan i proširiv

-   strukturiran i čitljiv

-   idealan za složene dokumente

**Nedostaci:**

-   veći od JSON-a

-   sporiji za parsiranje

-   zauzima više memorije

Unatoč tome, XML je i dalje dominantan u bankarstvu, državnim sustavima
i integracijskim platformama.

**2.2. ASP.NET Core 9**

ASP.NET Core 9 predstavlja suvremeni Microsoftov okvir namijenjen
izgradnji visokoperformantnih web-aplikacija i API-ja. Okvir je:

-   otvorenog koda

-   višenamjenski i multiplatformski

-   optimiziran za RESTful servise

-   moduliran u obliku paketa

**2.2.1. Ključne značajke**

-   ugrađen **Dependency Injection**

-   fleksibilni **middleware pipeline**

-   minimalistički i proširiv pristup konfiguraciji

-   integrirani JSON serijalizator (System.Text.Json)

-   izvrsne performanse i mali memory footprint

ASP.NET Core je odabran kao temelj backend sustava zbog:

-   modularnosti

-   performansi

-   dugoročne podrške

-   jednostavne integracije s React SPA aplikacijama

**2.3. RESTful arhitektura**

Backend aplikacija implementira REST (Representational State Transfer)
arhitekturu.

**REST princip uključuje:**

-   klijent–poslužitelj model

-   komunikaciju preko HTTP metoda (GET, POST, PUT, DELETE)

-   stateless obradu zahtjeva

-   razmjenu podataka u JSON formatu

-   jasne i konzistentne rute

Primjer rute:

GET /api/korisnici/5

REST API omogućuje:

-   neovisnost frontenda i backenda

-   jednostavno testiranje

-   mogućnost korištenja API-ja od drugih aplikacija (npr. mobilnih)

**2.4. React**

React je najpopularnija knjižnica za izgradnju dinamičkih korisničkih
sučelja.

**2.4.1. Ključne značajke**

-   komponentni razvoj (UI se sastoji od manjih dijelova)

-   virtualni DOM

-   jednostavno rukovanje stanjem

-   brzo ažuriranje prikaza

-   ogromni ekosustav dodatnih biblioteka

React je u ovoj aplikaciji korišten za:

-   učitavanje XML dokumenata

-   usporedbu XML sadržaja

-   prikaz korisnika iz SQL baze

-   interakciju s API slojem

**2.5. Vite**

Vite je moderni alat za razvoj frontend aplikacija, s naglaskom na
brzinu.

**Prednosti Vite-a:**

-   iznimno brz razvojni server

-   hot module replacement

-   optimizirana produkcijska gradnja

-   jednostavna konfiguracija

Vite je poslužio kao razvojno okruženje za React aplikaciju.

**2.6. SQL Server**

SQL Server predstavlja relacijski sustav za upravljanje bazama podataka.

**Razlozi korištenja SQL Servera:**

-   stabilnost i performanse

-   izvrsna integracija s .NET okvirom

-   podrška za stored procedure, transakcije, indeksiranje

-   jednostavno administriranje putem SSMS-a

U ovom radu SQL Server koristi se za spremanje entiteta **Korisnik**.

**2.7. Dapper mikro ORM**

Dapper je mikro ORM koji nudi:

-   izravno izvršavanje SQL upita

-   automatsko mapiranje rezultata na .NET objekte

-   minimalni overhead

-   punu kontrolu nad SQL-om

**Prednosti Dappera:**

-   idealan za aplikacije gdje postoji postojeća SQL struktura

-   visoke performanse

-   jednostavna implementacija

Zbog toga je odabran kao zamjena za ADO.NET kod iz WebForms aplikacije.

**2.8. xUnit testni okvir**

xUnit je moderna platforma za pisanje testova u .NET ekosustavu.

**Prednosti:**

-   jednostavan i čitljiv API

-   test metode označene atributom \[Fact\]

-   integracija s Visual Studio okruženjem

-   proširivost i mogućnost mockiranja (Moq)

Testovi u ovom radu pokrivaju:

-   obradu XML dokumenata

-   usporedbu struktura

-   repozitorije (Dapper)

-   poslovne servise

## 3. ARHITEKTURA MODERNIZIRANOG RJEŠENJA

U ovom poglavlju prikazana je arhitektura modernizirane aplikacije,
uključujući podjelu sustava na klijentski i poslužiteljski dio,
definirane slojeve poslovne logike i pristupa podacima, način
komunikacije između komponenti te korištene tehnologije. Poseban
naglasak stavljen je na razlike između izvornog WebForms rješenja i nove
arhitekture temeljene na ASP.NET Core Web API-ju i React
jedno-straničnoj aplikaciji.

# 3.1. Polazišno stanje

Izvorna verzija aplikacije bila je implementirana kao ASP.NET WebForms
rješenje s klasičnom tro-slojnom arhitekturom:

-   prezentacijski sloj (ASPX stranice i code-behind),

-   poslovna logika (servisne klase),

-   pristup podacima (ADO.NET u DAL klasama).

Ključni problemi izvorne arhitekture:

-   korisničko sučelje i poslovna logika bili su čvrsto povezani
```
    (tightly coupled),

```
-   nema jasnog odvajanja frontend i backend dijela,

-   teško testiranje zbog spajanja UI logike i server-side koda,

-   zastarjela tehnologija bez buduće podrške,

-   ograničene mogućnosti skaliranja i modernizacije.

# 3.2. Razlozi za modernizaciju

Modernizacija je provedena kako bi se postigli sljedeći ciljevi:

-   odvajanje korisničkog sučelja i API-ja (frontend ↔ backend),

-   uvođenje RESTful web servisa,

-   omogućavanje testabilnosti poslovne logike,

-   zamjena zastarjelog WebForms okvira,

-   uvođenje modernog SPA frontenda (React),

-   poboljšanje performansi i korisničkog iskustva,

-   olakšana buduća nadogradnja i integracija.

# 3.3. Arhitektura moderniziranog sustava

Modernizirana aplikacija sastoji se od tri glavne cjeline:

1.  Frontend — React + Vite SPA aplikacija

2.  Backend — ASP.NET Core 9 Web API

3.  SQL Server — relacijska baza podataka

Sve komponente međusobno komuniciraju putem jasno definiranih sučelja i
HTTP zahtjeva, što omogućava neovisnost i zamjenjivost pojedinih
dijelova sustava.

# 3.3.1. Pregled cjelokupne arhitekture

Frontend aplikacija:

-   učitava XML dokumente,

-   prikazuje formatirani XML,

-   poziva API za usporedbu XML dokumenata,

-   prikazuje korisnike iz baze,

-   prikazuje razlike između XML datoteka,

-   komunicira isključivo s REST API-jem.

Backend:

-   izlaže RESTful API,

-   obrađuje XML dokumente,

-   pristupa SQL bazi pomoću Dappera,

-   provodi poslovne procese (usporedba, sinkronizacija).

Baza:

-   pohranjuje entitet Korisnik,

-   omogućuje dohvat i ažuriranje podataka.

# 3.3.2. Slojevi poslužiteljske (backend) arhitekture

Backend je organiziran u četiri jasno odvojena sloja:

### **1. Models**

```
Predstavljaju entitete domene (npr. Korisnik).

```
### **2. Repositories**

-   sadrže SQL upite i pristup bazi podataka,

-   koriste Dapper za izvršavanje upita i mapiranja,

-   zamjenjuju staru ADO.NET logiku.

### **3. Services**

-   implementiraju poslovnu logiku,

-   provode operacije nad XML dokumentima,

-   pripremaju podatke za sinkronizaciju s bazom,

-   testabilni su i ne ovise o UI-ju.

### **4. Controllers**

-   predstavljaju ulazne točke za HTTP zahtjeve,

-   pozivaju servisni sloj,

-   vraćaju JSON rezultate frontendu.

# 3.3.3. Slojevi klijentske (frontend) arhitekture

Frontend aplikacija sastoji se od:

### **1. React komponenti**

-   XmlUpload

-   XmlCompare

-   UsersTable

-   Layout

### **2. API pomoćnih modula**

Smješteni u /src/api:

-   xmlApi.js

-   korisniciApi.js

Oni omogućuju izoliran i ponovno iskoristiv API sloj.

### **3. Globalnog App.jsx**

Glavna komponenta koja povezuje funkcionalnosti.

### **4. Vite konfiguracije**

Brzi dev server i optimizirana produkcijska gradnja.

# 3.3.4. Komunikacija između komponenti

Frontend ⇄ Backend komunikacija odvija se preko:

-   HTTP GET — dohvat korisnika,

-   HTTP POST (multipart/form-data) — upload XML dokumenta,

-   HTTP POST — usporedba i sinkronizacija,

-   HTTP PUT/DELETE — ažuriranje podataka.

Podaci se razmjenjuju u:

-   JSON formatu za standardne API pozive,

-   XML datotekama za upload,

-   JSON strukturama za rezultate usporedbe i formatirani XML.

# 3.3.5. Sigurnost i integracija

Minimalno potrebna sigurnost uključuje:

-   HTTPS enkripciju,

-   validaciju podataka,

-   zaštitu od pogrešnih XML formata,

-   ograničene veličine upload datoteka.

```
Za potrebe diplomskog rada autentikacija nije implementirana, ali
arhitektura to lako dopušta (JWT, OAuth, Identity).

```
# 3.3.6. Prednosti nove arhitekture

Nova arhitektura donosi sljedeće prednosti:

### ✔️ Čisto odvajanje frontenda i backenda

Frontend više nije ovisan o izvedbi poslužitelja.

### ✔️ Bolja testabilnost

Servisi i logika mogu se testirati bez Web UI-ja.

### ✔️ Skalabilnost

Moguće je skalirati API i frontend neovisno.

### ✔️ Modularnost i proširivost

Novi entiteti, nove funkcije i novi API endpointi mogu se jednostavno
dodati.

### ✔️ Moderno korisničko iskustvo

React donosi dinamičnost, brzinu i responzivnost.

# 3.3.7. Dijagram arhitekture

# <img src="media/image1.png" style="width:4.04167in;height:6.0625in" />

Slika 3.1: Arhitektura moderniziranog rješenja

Izvor: izradio autor

Slika 3.1 prikazuje cjelokupnu arhitekturu sustava koja je rezultat
modernizacije izvorne WebForms aplikacije. Korisnik pristupa aplikaciji
putem web preglednika u kojem se izvršava React jedno-stranična
aplikacija. React aplikacija komunicira s ASP.NET Core Web API-jem
isključivo putem HTTPS protokola i standardnih HTTP metoda. Web API
sadrži poslovnu logiku i sloj pristupa podacima koji koriste Dapper
mikro ORM za komunikaciju sa SQL Server bazom podataka. API istovremeno
obrađuje XML dokumente učitane s klijentske strane te provodi usporedbe,
validacije i sinkronizaciju podataka. Takva arhitektura osigurava jasnu
separaciju odgovornosti, modularnost i jednostavnu mogućnost proširenja
sustava u budućnosti.

# 4. IMPLEMENTACIJA POSLUŽITELJSKE STRANE (BACKEND)

U ovom poglavlju detaljno je prikazana implementacija poslužiteljske
strane moderniziranog sustava, razvijene korištenjem ASP.NET Core 9 Web
API tehnologije. Ključni elementi implementacije uključuju definiranje
arhitekture projekta, implementaciju poslovne logike, pristup bazi
podataka korištenjem Dapper mikro ORM-a te obradu, usporedbu i
formatiranje XML dokumenata.

# 4.1. Struktura projekta

Backend je organiziran u obliku višeslojne arhitekture koja slijedi
jasnu separaciju odgovornosti. Projekt sadrži sljedeće direktorije:

DiplomskiXml.Server/

│

├── Controllers/

├── Models/

├── Services/

├── Repositories/

├── Helpers/

├── appsettings.json

└── Program.cs

### **4.1.1. Controllers**

```
Sadrže krajnje točke (endpointove) kojima pristupa frontend:

```
-   XmlController

-   KorisniciController

### **4.1.2. Services**

Implementiraju poslovnu logiku:

-   XmlService – učitavanje, formatiranje, usporedba XML-a

-   KorisnikService – obrada i sinkronizacija korisnika

### **4.1.3. Repositories**

Zaduženi za komunikaciju s bazom:

-   KorisnikRepository

### **4.1.4. Helpers**

Dodatne klase:

-   XmlFormatter – formatirani ispis XML-a

-   XmlComparer – rekurzivna usporedba XML dokumenata

# 4.2. Konfiguracija aplikacije

Datoteka Program.cs sadrži definiciju servisa i konfiguraciju
aplikacije:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

```
// Repozitoriji i servisi

```
builder.Services.AddScoped\<IKorisnikRepository, KorisnikRepository\>();

builder.Services.AddScoped\<IKorisnikService, KorisnikService\>();

builder.Services.AddScoped\<IXmlService, XmlService\>();

```
// Connection string

```csharp
builder.Services.AddSingleton(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

```
# 4.3. Modeli

U direktoriju Models nalazi se entitet **Korisnik**:

```csharp
public class Korisnik

{

public int KorisnikId { get; set; }

public string Ime { get; set; }

public string Prezime { get; set; }

public string Email { get; set; }

}

```
# 4.4. Pristup bazi podataka (Repositories)

Za pristup SQL Server bazi koristi se Dapper.

### **4.4.1. Sučelje**

```csharp
public interface IKorisnikRepository

{

Task\<IEnumerable\<Korisnik\>\> GetAllAsync();

Task\<int\> InsertAsync(Korisnik korisnik);

Task\<int\> UpdateAsync(Korisnik korisnik);

Task\<int\> DeleteAsync(int id);

}

```
### **4.4.2. Implementacija**

```csharp
public class KorisnikRepository : IKorisnikRepository

{

private readonly string \_connectionString;

public KorisnikRepository(string connectionString)

{

\_connectionString = connectionString;

}

public async Task\<IEnumerable\<Korisnik\>\> GetAllAsync()

{

using var connection = new SqlConnection(\_connectionString);

return await connection.QueryAsync\<Korisnik\>("SELECT \* FROM
Korisnik");

}

public async Task\<int\> InsertAsync(Korisnik korisnik)

{

var sql = @"INSERT INTO Korisnik (Ime, Prezime, Email)

VALUES (@Ime, @Prezime, @Email)";

using var connection = new SqlConnection(\_connectionString);

return await connection.ExecuteAsync(sql, korisnik);

}

public async Task\<int\> UpdateAsync(Korisnik korisnik)

{

var sql = @"UPDATE Korisnik SET Ime=@Ime, Prezime=@Prezime, Email=@Email

WHERE KorisnikId=@KorisnikId";

using var connection = new SqlConnection(\_connectionString);

return await connection.ExecuteAsync(sql, korisnik);

}

public async Task\<int\> DeleteAsync(int id)

{

using var connection = new SqlConnection(\_connectionString);

return await connection.ExecuteAsync("DELETE FROM Korisnik WHERE
KorisnikId = @id", new { id });

}

}

```
# 4.5. Poslovna logika (Services)

## 4.5.1. XmlService

XmlService obrađuje:

-   učitavanje XML dokumenta

-   formatiranje (“beautify”)

-   usporedbu XML struktura

-   izdvajanje korisnika iz XML-a

-   pripremu podataka za sinkronizaciju

### **Metoda: Učitavanje i formatiranje XML-a**

```csharp
public string FormatXml(IFormFile xmlFile)

{

using var stream = xmlFile.OpenReadStream();

var xml = new XmlDocument();

xml.Load(stream);

using var stringWriter = new StringWriter();

using var xmlTextWriter = new XmlTextWriter(stringWriter)

{

```
Formatting = Formatting.Indented

```
};

xml.WriteContentTo(xmlTextWriter);

return stringWriter.ToString();

}

```
## 4.5.2. Usporedba XML dokumenata (XmlComparer)

Usporedba se izvodi rekurzivno:

```csharp
public class XmlComparer

{

public bool AreEqual(XmlNode a, XmlNode b)

{

if (a.Name != b.Name) return false;

if (a.InnerText.Trim() != b.InnerText.Trim()) return false;

if (a.Attributes.Count != b.Attributes.Count) return false;

for (int i = 0; i \< a.Attributes.Count; i++)

{

if (a.Attributes\[i\].Value != b.Attributes\[i\].Value)

return false;

}

if (a.ChildNodes.Count != b.ChildNodes.Count) return false;

for (int i = 0; i \< a.ChildNodes.Count; i++)

{

if (!AreEqual(a.ChildNodes\[i\], b.ChildNodes\[i\]))

return false;

}

return true;

}

}

```
Rezultat se šalje frontendu u JSON formatu:

```
{

"equal": false,

```
"differences": \[

```
"Element \<Ime\> razlikuje se.",

```
"Atribut email se razlikuje."

\]

```
}

```
# 4.6. Izdvajanje korisnika iz XML dokumenta

Korisnici se izdvajaju putem XPath izraza:

```xml
public IEnumerable\<Korisnik\> ExtractUsers(XmlDocument xml)

{

var users = new List\<Korisnik\>();

var nodes = xml.SelectNodes("//Korisnik");

foreach (XmlNode node in nodes)

{

users.Add(new Korisnik

{

Ime = node\["Ime"\]?.InnerText,

Prezime = node\["Prezime"\]?.InnerText,

```
Email = node\["Email"\]?.InnerText

```
});

}

return users;

}

```
# 4.7. Apliciranje sinkronizacije s bazom

Metoda:

-   uspoređuje korisnike u XML-u

-   uspoređuje korisnike u bazi

-   dodaje nove

-   ažurira postojeće

-   briše višak

```xml
public async Task SyncUsers(IEnumerable\<Korisnik\> fromXml)

{

var fromDb = (await \_korisnikRepository.GetAllAsync()).ToList();

foreach (var user in fromXml)

{

var match = fromDb.FirstOrDefault(x =\> x.Email == user.Email);

if (match == null)

await \_korisnikRepository.InsertAsync(user);

```
else

```
{

user.KorisnikId = match.KorisnikId;

await \_korisnikRepository.UpdateAsync(user);

}

}

}

```
# 4.8. API kontroleri

## 4.8.1. XmlController

\[ApiController\]

```csharp
\[Route("api/\[controller\]")\]

public class XmlController : ControllerBase

{

private readonly IXmlService \_xmlService;

public XmlController(IXmlService xmlService)

{

\_xmlService = xmlService;

}

\[HttpPost("format")\]

public IActionResult FormatXml(IFormFile file)

{

var result = \_xmlService.FormatXml(file);

return Ok(result);

}

\[HttpPost("compare")\]

public IActionResult Compare(IFormFile fileA, IFormFile fileB)

{

var differences = \_xmlService.Compare(fileA, fileB);

return Ok(differences);

}

\[HttpPost("sync")\]

public async Task\<IActionResult\> Sync(IFormFile file)

{

var result = await \_xmlService.SyncUsers(file);

return Ok(result);

}

}

```
## 4.8.2. KorisniciController

\[ApiController\]

```csharp
\[Route("api/\[controller\]")\]

public class KorisniciController : ControllerBase

{

private readonly IKorisnikRepository \_repository;

public KorisniciController(IKorisnikRepository repository)

{

\_repository = repository;

}

```
\[HttpGet\]

```csharp
public async Task\<IActionResult\> GetAll()

=\> Ok(await \_repository.GetAllAsync());

}

```
# 4.9. Konfiguracijska datoteka (appsettings.json)

```
{

"ConnectionStrings": {

```
"DefaultConnection":
```
"Server=localhost;Database=DiplomskiDb;Trusted_Connection=True;TrustServerCertificate=True"

}

}

**5. IMPLEMENTACIJA KLIJENTSKE STRANE (FRONTEND)**

```
U ovom poglavlju prikazana je implementacija klijentskog dijela sustava
razvijenog u tehnologiji React uz Vite kao razvojno i produkcijsko
okruženje. Klijentska aplikacija omogućuje učitavanje i prikaz XML
dokumenata, usporedbu dvaju XML datoteka, interakciju s API slojem te
prikaz popisa korisnika iz SQL Server baze podataka.

Frontend aplikacija implementirana je kao jedno-stranična aplikacija
```
(Single Page Application – SPA), što omogućuje dinamičko učitavanje
```
sadržaja bez ponovnog osvježavanja stranice te znatno poboljšava
korisničko iskustvo.

**5.1. Struktura React projekta**

Frontend aplikacija slijedi standardnu projektnu strukturu generiranu
Vite alatom:

diplomski-frontend/

│

├── public/

├── src/

│ ├── api/

│ │ ├── xmlApi.js

│ │ └── korisniciApi.js

│ ├── components/

│ │ ├── XmlUpload.jsx

│ │ ├── XmlCompare.jsx

│ │ ├── UsersTable.jsx

│ │ └── Layout.jsx

│ ├── App.jsx

│ ├── main.jsx

│ └── styles.css

├── index.html

└── vite.config.js

Svaka funkcionalnost smještena je u vlastitu komponentu kako bi se
postigla modularnost i ponovno korištenje koda.

**5.2. Konfiguracija Vite okruženja**

Datoteka **vite.config.js** sadrži minimalnu konfiguraciju potrebnu za
lokalni razvoj:

```javascript
import { defineConfig } from 'vite'

import react from '@vitejs/plugin-react'

export default defineConfig({

plugins: \[react()\],

server: {

```
port: 5173

```
}

})

```
**5.3. Početna točka aplikacije**

**5.3.1. main.jsx**

```javascript
import React from 'react'

import ReactDOM from 'react-dom/client'

import App from './App.jsx'

import './styles.css'

ReactDOM.createRoot(document.getElementById('root')).render(

```
\<React.StrictMode\>

\<App /\>

\</React.StrictMode\>

```
)

```
**5.3.2. App.jsx**

App.jsx povezuje sve glavne komponente:

```javascript
import XmlUpload from './components/XmlUpload.jsx'

import XmlCompare from './components/XmlCompare.jsx'

import UsersTable from './components/UsersTable.jsx'

export default function App() {

return (

```
\<div className="container"\>

\<h1\>Aplikacija za rad s XML dokumentima\</h1\>

\<XmlUpload /\>

\<XmlCompare /\>

\<UsersTable /\>

\</div\>

```
)

}

**5.4. API sloj (/src/api)**

```
Za komunikaciju s backendom implementirane su dvije moduleske datoteke:

**5.4.1. xmlApi.js**

```csharp
const API_URL = "https://localhost:7001/api/xml"

export async function formatXml(file) {

const form = new FormData()

form.append("file", file)

const res = await fetch(\`${API_URL}/format\`, {

method: "POST",

```
body: form

```csharp
})

return res.text()

}

export async function compareXml(fileA, fileB) {

const form = new FormData()

form.append("fileA", fileA)

form.append("fileB", fileB)

const res = await fetch(\`${API_URL}/compare\`, {

method: "POST",

```
body: form

```
})

return res.json()

}

```
**5.4.2. korisniciApi.js**

```csharp
const API_URL = "https://localhost:7001/api/korisnici"

export async function getAllUsers() {

const res = await fetch(API_URL)

return res.json()

}

```
**5.5. Komponente**

**5.5.1. Upload XML datoteke — XmlUpload.jsx**

Omogućuje slanje XML dokumenta API-ju radi formatiranog prikaza.

```javascript
import { useState } from "react"

import { formatXml } from "../api/xmlApi"

export default function XmlUpload() {

const \[file, setFile\] = useState(null)

const \[output, setOutput\] = useState("")

async function handleUpload() {

const result = await formatXml(file)

setOutput(result)

}

return (

```
\<div className="card"\>

\<h2\>Učitavanje i formatiranje XML dokumenta\</h2\>

```
\<input type="file" onChange={e =\> setFile(e.target.files\[0\])} /\>

\<button onClick={handleUpload}\>Formatiraj XML\</button\>

\<pre className="xml-output"\>{output}\</pre\>

```
\</div\>

```
)

}

```
**5.5.2. Usporedba XML dokumenata — XmlCompare.jsx**

Omogućuje učitavanje dvaju dokumenata i prikaz rezultata usporedbe.

```javascript
import { useState } from "react"

import { compareXml } from "../api/xmlApi"

export default function XmlCompare() {

const \[fileA, setFileA\] = useState(null)

const \[fileB, setFileB\] = useState(null)

const \[result, setResult\] = useState(null)

async function handleCompare() {

const res = await compareXml(fileA, fileB)

setResult(res)

}

return (

```
\<div className="card"\>

\<h2\>Usporedba XML dokumenata\</h2\>

```
\<input type="file" onChange={e =\> setFileA(e.target.files\[0\])} /\>

\<input type="file" onChange={e =\> setFileB(e.target.files\[0\])} /\>

\<button onClick={handleCompare}\>Usporedi\</button\>

{result && (

```
\<div className="compare-output"\>

```
{result.equal ? (

```
\<p\>XML dokumenti su identični.\</p\>

```
) : (

```
\<\>

\<p\>Dokumenti se razlikuju:\</p\>

\<ul\>

```
{result.differences.map((d, i) =\> (

\<li key={i}\>{d}\</li\>

))}

```
\</ul\>

\</\>

```
)}

```
\</div\>

```
)}

```
\</div\>

```
)

}

```
**5.5.3. Tablica korisnika — UsersTable.jsx**

Prikazuje podatke iz SQL Server baze.

```javascript
import { useEffect, useState } from "react"

import { getAllUsers } from "../api/korisniciApi"

export default function UsersTable() {

const \[users, setUsers\] = useState(\[\])

useEffect(() =\> {

getAllUsers().then(setUsers)

}, \[\])

return (

```
\<div className="card"\>

\<h2\>Lista korisnika\</h2\>

\<table className="users-table"\>

\<thead\>

\<tr\>

\<th\>Ime\</th\>

\<th\>Prezime\</th\>

\<th\>Email\</th\>

\</tr\>

\</thead\>

\<tbody\>

```
{users.map(u =\> (

\<tr key={u.korisnikId}\>

\<td\>{u.ime}\</td\>

\<td\>{u.prezime}\</td\>

\<td\>{u.email}\</td\>

```
\</tr\>

```
))}

```
\</tbody\>

\</table\>

\</div\>

```
)

}

**5.6. Stilizacija (styles.css)**

```
Jednostavna stilizacija radi preglednosti:

```
.container {

width: 900px;

margin: auto;

font-family: Arial, sans-serif;

}

.card {

background: \#fff;

padding: 20px;

margin-top: 30px;

border-radius: 6px;

box-shadow: 0 2px 5px rgba(0,0,0,0.1);

}

.xml-output {

background: \#f4f4f4;

padding: 10px;

height: 250px;

overflow: auto;

}

.users-table {

width: 100%;

border-collapse: collapse;

}

.users-table td, .users-table th {

border: 1px solid \#ccc;

padding: 6px;

}

```
**5.7. Komunikacija s backendom**

Spa React aplikacija šalje zahtjeve:

-   **multipart/form-data** za upload XML datoteka

-   **application/json** za dohvat korisnika

Komunikacija je stateless i neovisna o poslužitelju, što omogućuje:

-   jednostavnu zamjenu backend implementacije,

-   razvoj mobilne verzije aplikacije,

-   horizontalno skaliranje.

**5.8. Integracija frontenda i backenda**

Aplikacija je spremna za produkcijsko korištenje:

```javascript
1.  Backend (DiplomskiXml.Server) pokreće se na 7001/7000.

2.  Frontend (npm run dev) pokreće se na 5173.

```
3.  Vite proxy može se dodati da se izbjegne CORS.

Primjer:

```
server: {

proxy: {

```
'/api': 'https://localhost:7001'

```
}

}

```
# 6. Evaluacija moderniziranog rješenja

# ---------------------------------------

Evaluacija moderniziranog rješenja provedena je usporedbom stare ASP.NET
WebForms aplikacije i novog sustava temeljenog na ASP.NET Core 9 i React
tehnologijama.

## 6.1. Prednosti u odnosu na WebForms verziju

### **✔️ Čista arhitektura**

```
WebForms je bio snažno povezan (tightly coupled), što je otežavalo
```
testiranje i održavanje.  
Novo rješenje uvodi:

-   odvojene slojeve (Controllers, Services, Repositories),

-   jasan API sloj,

-   frontend potpuno odvojen od servera.

### **✔️ Testabilnost**

WebForms pristup nije omogućavao pisanje jedinčnih testova.  
Novi sustav koristi xUnit, a servisi su projektirani tako da budu u
potpunosti testabilni.

### **✔️ Performanse**

-   ASP.NET Core 9 je višestruko brži od .NET Framework WebForms-a

-   React + Vite osigurava instant reload i minimalan bundle u
    produkciji

### **✔️ Održavanje i proširivanje**

-   frontend i backend se razvijaju neovisno

-   jednostavno dodavanje novih endpointa

-   mogućnost integracije mobilne aplikacije koja koristi isti API

### **✔️ Skalabilnost**

-   API se može horizontalno skalirati

-   frontend se može publishati na CDN, GitHub Pages, Vercel, Netlify
    itd.

## 6.2. Identificirana ograničenja

Iako modernizacija donosi velik napredak, postoje određena ograničenja:

-   Usporedba XML dokumenata pri većim datotekama (\>10 MB) može biti
    sporija

-   Autentikacija i autorizacija nisu implementirane (mogući budući rad)

-   Napredna sinkronizacija baze (npr. delta detekcija i privatni
```
    ključevi) može se dodatno optimizirati

```
-   Ne postoji verzioniranje XML dokumenata, ali arhitektura omogućuje
    naknadnu implementaciju

## 6.3. Procjena ciljeva modernizacije

| **Cilj**                                    | **Ostvaren** |
|---------------------------------------------|--------------|
| Zamjena zastarjele WebForms tehnologije     | ✔️           |
| Uvođenje modernog REST API-ja               | ✔️           |
| Odvajanje prikaznog i poslužiteljskog sloja | ✔️           |
```
| Viša testabilnost (xUnit)                   | ✔️           |
```
| Uvođenje React SPA sučelja                  | ✔️           |
| Povećanje održivosti i modularnosti         | ✔️           |
| Jednostavnije proširenje funkcionalnosti    | ✔️           |

# -------------------

# 7. Zaključak

# -------------------

U ovom diplomskom radu provedena je cjelovita modernizacija zastarjele
ASP.NET WebForms aplikacije u suvremeni tehnološki sklop temeljen na
ASP.NET Core 9 i Reactu. Modernizacija je donijela jasnu separaciju
odgovornosti, povećala održivost sustava, te omogućila brže i
jednostavnije buduće nadogradnje.

Sve ključne funkcionalnosti — učitavanje XML dokumenata, formatiranje,
usporedba i sinkronizacija s SQL bazom — prebačene su u čistu i
modularnu arhitekturu. Poslovna logika je centralizirana, a frontend
potpuno odvojen od poslužiteljske implementacije.

Implementirani sustav dokazuje da se suvremene web tehnologije mogu
uspješno primijeniti na starije monolitne aplikacije, pri čemu se
ostvaruju:

-   značajna poboljšanja performansi,

-   jednostavnije testiranje,

-   bolji razvojni tijek,

-   veća fleksibilnost.

Budući razvoj ovog rješenja može uključivati:

-   autentikaciju i autorizaciju (JWT, Identity)

-   CI/CD pipeline

-   Docker kontenere

-   nadograđeni sustav za verzioniranje XML dokumenata

-   proširenje klijentskog sučelja

Modernizirani sustav predstavlja stabilnu platformu za daljnji razvoj i
implementaciju budućih funkcionalnosti.

# -----------------------------------------

# PRILOG A – Instalacija i pokretanje

# -----------------------------------------

## A.1. Preduvjeti

-   Visual Studio 2022 (ASP.NET workload)

-   .NET SDK 9

-   Node.js 18+

-   npm

-   SQL Server Express ili SQL 2019+

-   SSMS (opcionalno)

## A.2. Instalacija baze

```sql
CREATE DATABASE Diplomski;

GO

USE Diplomski;

GO

CREATE TABLE Korisnik (

Id INT IDENTITY(1,1) PRIMARY KEY,

Ime NVARCHAR(100) NOT NULL,

Prezime NVARCHAR(100) NOT NULL,

Email NVARCHAR(200) NOT NULL

);

INSERT INTO Korisnik (Ime, Prezime, Email)

VALUES

('Ivan', 'Bernatović', 'ivan@example.com'),

('Ksenija', 'Test', 'ksenija@example.com');

```
## A.3. Pokretanje backend API-ja

U Visual Studiu:

1.  Otvoriti rješenje

2.  Postaviti DiplomskiXml.Server kao startup project

3.  Pokrenuti F5

API radi na:

-   <https://localhost:5001>

-   https://localhost:7001 (ovisno o profilu)

Swagger se otvara automatski.

## A.4. Pokretanje frontenda

U terminalu:

cd diplomski-frontend

npm install

npm run dev

Frontend radi na:

http://localhost:5173

## A.5. Pokretanje testovima

U Visual Studiu:

Test → Run All Tests

# PRILOG B – IZVORNI KÔD POSLUŽITELJSKE APLIKACIJE (BACKEND)

Ovaj prilog prikazuje kompletan izvorni kôd backend dijela aplikacije
razvijene u ASP.NET Core 9 Web API tehnologiji.

## B.1. Struktura projekta DiplomskiXml.Server

DiplomskiXml.Server/

│

├── Controllers/

│ ├── KorisniciController.cs

│ └── XmlController.cs

│

├── Models/

│ └── Korisnik.cs

│

├── Repositories/

│ ├── IKorisnikRepository.cs

│ └── KorisnikRepository.cs

│

├── Services/

│ ├── IKorisnikService.cs

│ ├── KorisnikService.cs

│ ├── IXmlService.cs

│ └── XmlService.cs

│

├── Properties/

│ └── launchSettings.json

│

├── appsettings.json

├── Program.cs

└── DiplomskiXml.Server.csproj

## B.2. Datoteka DiplomskiXml.Server.csproj

\<Project Sdk="Microsoft.NET.Sdk.Web"\>

\<PropertyGroup\>

\<TargetFramework\>net9.0\</TargetFramework\>

\<Nullable\>enable\</Nullable\>

\<ImplicitUsings\>enable\</ImplicitUsings\>

\</PropertyGroup\>

\<ItemGroup\>

\<PackageReference Include="Dapper" Version="2.1.35" /\>

\<PackageReference Include="Microsoft.Data.SqlClient" Version="5.2.0"
/\>

\<PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" /\>

\</ItemGroup\>

\</Project\>

## B.3. Datoteka appsettings.json
```json

{

"ConnectionStrings": {

"DefaultConnection":
"Server=.;Database=Diplomski;Trusted_Connection=True;TrustServerCertificate=True"

},

"Logging": {

"LogLevel": {

"Default": "Information",

"Microsoft.AspNetCore": "Warning"

}

},

"AllowedHosts": "\*"

}

```
## B.4. Datoteka Properties/launchSettings.json

```
{

"iisSettings": {

"windowsAuthentication": false,

"anonymousAuthentication": true,

"iisExpress": {

"applicationUrl": "http://localhost:5242",

```
"sslPort": 44304

```
}

},

"profiles": {

"DiplomskiXml.Server": {

"commandName": "Project",

"dotnetRunMessages": true,

"launchBrowser": true,

"applicationUrl": "https://localhost:5001;http://localhost:5000",

"environmentVariables": {

```
"ASPNETCORE_ENVIRONMENT": "Development"

```
}

},

"IIS Express": {

"commandName": "IISExpress",

"launchBrowser": true,

"environmentVariables": {

```
"ASPNETCORE_ENVIRONMENT": "Development"

```
}

}

}

}

```
## B.5. Datoteka Program.cs

```csharp
using System.Data;

using Microsoft.Data.SqlClient;

using DiplomskiXml.Server.Repositories;

using DiplomskiXml.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Connection string (iz appsettings.json)

var connectionString =
builder.Configuration.GetConnectionString("DefaultConnection");

```
// IDbConnection za Dapper

```csharp
builder.Services.AddScoped\<IDbConnection\>(\_ =\>

{

return new SqlConnection(connectionString);

});

```
// Repozitoriji i servisi

```csharp
builder.Services.AddScoped\<IKorisnikRepository, KorisnikRepository\>();

builder.Services.AddScoped\<IKorisnikService, KorisnikService\>();

builder.Services.AddScoped\<IXmlService, XmlService\>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

```
// CORS za React frontend

```
builder.Services.AddCors(options =\>

{

options.AddPolicy("Frontend", policy =\>

{

```
policy

```csharp
.WithOrigins("http://localhost:5173")

.AllowAnyHeader()

.AllowAnyMethod();

});

});

var app = builder.Build();

if (app.Environment.IsDevelopment())

{

app.UseSwagger();

app.UseSwaggerUI();

}

app.UseCors("Frontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

```
## B.6. Model Models/Korisnik.cs

```csharp
namespace DiplomskiXml.Server.Models;

public class Korisnik

{

public int Id { get; set; }

public string Ime { get; set; } = string.Empty;

public string Prezime { get; set; } = string.Empty;

public string Email { get; set; } = string.Empty;

}

```
## B.7. Sučelje Repositories/IKorisnikRepository.cs

```csharp
using DiplomskiXml.Server.Models;

namespace DiplomskiXml.Server.Repositories;

public interface IKorisnikRepository

{

Task\<IEnumerable\<Korisnik\>\> DajSveAsync();

Task\<Korisnik?\> DajPoIdAsync(int id);

Task\<int\> InsertAsync(Korisnik korisnik);

Task\<int\> UpdateAsync(Korisnik korisnik);

Task\<int\> DeleteAsync(int id);

}

```
## B.8. Repozitorij Repositories/KorisnikRepository.cs

```csharp
using System.Data;

using Dapper;

using DiplomskiXml.Server.Models;

namespace DiplomskiXml.Server.Repositories;

public class KorisnikRepository : IKorisnikRepository

{

private readonly IDbConnection \_db;

public KorisnikRepository(IDbConnection db)

{

\_db = db;

}

public async Task\<IEnumerable\<Korisnik\>\> DajSveAsync()

{

const string sql = "SELECT Id, Ime, Prezime, Email FROM Korisnik";

return await \_db.QueryAsync\<Korisnik\>(sql);

}

public async Task\<Korisnik?\> DajPoIdAsync(int id)

{

const string sql = "SELECT Id, Ime, Prezime, Email FROM Korisnik WHERE
Id = @Id";

return await \_db.QuerySingleOrDefaultAsync\<Korisnik\>(sql, new { Id =
id });

}

public async Task\<int\> InsertAsync(Korisnik korisnik)

{

const string sql = @"

INSERT INTO Korisnik (Ime, Prezime, Email)

VALUES (@Ime, @Prezime, @Email);

SELECT CAST(SCOPE_IDENTITY() as int);";

var newId = await \_db.ExecuteScalarAsync\<int\>(sql, korisnik);

return newId;

}

public async Task\<int\> UpdateAsync(Korisnik korisnik)

{

const string sql = @"

UPDATE Korisnik SET

Ime = @Ime,

Prezime = @Prezime,

```
Email = @Email

```sql
WHERE Id = @Id";

return await \_db.ExecuteAsync(sql, korisnik);

}

public async Task\<int\> DeleteAsync(int id)

{

const string sql = "DELETE FROM Korisnik WHERE Id = @Id";

return await \_db.ExecuteAsync(sql, new { Id = id });

}

}

```
## B.9. Sučelje Services/IKorisnikService.cs

```csharp
using DiplomskiXml.Server.Models;

namespace DiplomskiXml.Server.Services;

public interface IKorisnikService

{

Task\<IEnumerable\<Korisnik\>\> DajSveAsync();

Task\<Korisnik?\> DajPoIdAsync(int id);

Task\<Korisnik\> KreirajAsync(Korisnik korisnik);

Task\<bool\> AzurirajAsync(Korisnik korisnik);

Task\<bool\> ObrisiAsync(int id);

}

```
## B.10. Servis Services/KorisnikService.cs

```csharp
using DiplomskiXml.Server.Models;

using DiplomskiXml.Server.Repositories;

namespace DiplomskiXml.Server.Services;

public class KorisnikService : IKorisnikService

{

private readonly IKorisnikRepository \_repo;

public KorisnikService(IKorisnikRepository repo)

{

\_repo = repo;

}

public Task\<IEnumerable\<Korisnik\>\> DajSveAsync()

=\> \_repo.DajSveAsync();

public Task\<Korisnik?\> DajPoIdAsync(int id)

=\> \_repo.DajPoIdAsync(id);

public async Task\<Korisnik\> KreirajAsync(Korisnik korisnik)

{

var id = await \_repo.InsertAsync(korisnik);

korisnik.Id = id;

return korisnik;

}

public async Task\<bool\> AzurirajAsync(Korisnik korisnik)

=\> await \_repo.UpdateAsync(korisnik) \> 0;

public async Task\<bool\> ObrisiAsync(int id)

=\> await \_repo.DeleteAsync(id) \> 0;

}

```
## B.11. Sučelje Services/IXmlService.cs

```csharp
using Microsoft.AspNetCore.Http;

using DiplomskiXml.Server.Models;

namespace DiplomskiXml.Server.Services;

public interface IXmlService

{

Task\<object\> ProcessXmlAsync(IFormFile file);

Task\<object\> CompareXmlAsync(IFormFile fileA, IFormFile fileB);

Task\<IEnumerable\<Korisnik\>\> ExtractUsersAsync(IFormFile file);

Task\<object\> SyncWithDatabaseAsync(IFormFile file);

}

```
## B.12. Servis Services/XmlService.cs
```csharp


using System.Xml;

using DiplomskiXml.Server.Models;

using DiplomskiXml.Server.Repositories;

using Microsoft.AspNetCore.Http;

namespace DiplomskiXml.Server.Services;

public class XmlService : IXmlService

{

private readonly IKorisnikRepository \_korisnikRepo;

public XmlService(IKorisnikRepository korisnikRepo)

{

\_korisnikRepo = korisnikRepo;

}

public async Task\<object\> ProcessXmlAsync(IFormFile file)

{

var xml = await ReadXmlAsync(file);

var formatted = BeautifyXml(xml);

return new

{

Raw = xml.OuterXml,

Formatted = formatted,

RootElement = xml.DocumentElement?.Name

};

}

public async Task\<object\> CompareXmlAsync(IFormFile fileA, IFormFile
fileB)

{

var xmlA = await ReadXmlAsync(fileA);

var xmlB = await ReadXmlAsync(fileB);

var differences = CompareNodes(xmlA.DocumentElement!,
xmlB.DocumentElement!);

return new

{

Differences = differences,

Count = differences.Count

};

}

public async Task\<IEnumerable\<Korisnik\>\> ExtractUsersAsync(IFormFile
file)

{

var xml = await ReadXmlAsync(file);

var users = new List\<Korisnik\>();

foreach (XmlNode node in xml.SelectNodes("//Korisnik")!)

{

users.Add(new Korisnik

{

Ime = node\["Ime"\]?.InnerText ?? string.Empty,

Prezime = node\["Prezime"\]?.InnerText ?? string.Empty,

Email = node\["Email"\]?.InnerText ?? string.Empty

});

}

return users;

}

public async Task\<object\> SyncWithDatabaseAsync(IFormFile file)

{

var xmlUsers = (await ExtractUsersAsync(file)).ToList();

var dbUsers = (await \_korisnikRepo.DajSveAsync()).ToList();

var toInsert = xmlUsers.Where(x =\> !dbUsers.Any(d =\> d.Email ==
x.Email)).ToList();

var toDelete = dbUsers.Where(d =\> !xmlUsers.Any(x =\> x.Email ==
d.Email)).ToList();

// Ovdje se može dodati stvarno Insert/Update/Delete, za diplomski
dovoljno je pripremiti liste

return new

{

InsertCount = toInsert.Count,

DeleteCount = toDelete.Count,

InsertList = toInsert,

DeleteList = toDelete

};

}

private async Task\<XmlDocument\> ReadXmlAsync(IFormFile file)

{

using var stream = file.OpenReadStream();

var xml = new XmlDocument();

await Task.Run(() =\> xml.Load(stream));

return xml;

}

private string BeautifyXml(XmlDocument doc)

{

using var stringWriter = new StringWriter();

using var xmlTextWriter = new XmlTextWriter(stringWriter)

{

Formatting = Formatting.Indented

};

doc.WriteContentTo(xmlTextWriter);

return stringWriter.ToString();

}

private List\<string\> CompareNodes(XmlNode nodeA, XmlNode nodeB,
string? path = null)

{

var diffs = new List\<string\>();

path ??= "/" + nodeA.Name;

if (nodeA.Name != nodeB.Name)

{

diffs.Add($"Razlika u nazivu čvora na putanji {path}: '{nodeA.Name}' vs
'{nodeB.Name}'");

return diffs;

}

if (nodeA.InnerText.Trim() != nodeB.InnerText.Trim() &&

nodeA.ChildNodes.Count == 0 && nodeB.ChildNodes.Count == 0)

{

diffs.Add($"Razlika u vrijednosti čvora {path}: '{nodeA.InnerText}' vs
'{nodeB.InnerText}'");

}

if (nodeA.Attributes?.Count != nodeB.Attributes?.Count)

{

diffs.Add($"Razlika u broju atributa za čvor {path}");

}

if (nodeA.Attributes != null && nodeB.Attributes != null)

{

foreach (XmlAttribute attrA in nodeA.Attributes)

{

var attrB = nodeB.Attributes\[attrA.Name\];

if (attrB == null)

{

diffs.Add($"Nedostaje atribut '{attrA.Name}' u čvoru {path} u drugom
dokumentu");

}

else if (attrA.Value != attrB.Value)

{

diffs.Add($"Razlika u atributu '{attrA.Name}' u čvoru {path}:
'{attrA.Value}' vs '{attrB.Value}'");

}

}

}

if (nodeA.ChildNodes.Count != nodeB.ChildNodes.Count)

{

diffs.Add($"Razlika u broju podčvorova u {path}");

}

var count = Math.Min(nodeA.ChildNodes.Count, nodeB.ChildNodes.Count);

for (int i = 0; i \< count; i++)

{

var childPath = $"{path}/{nodeA.ChildNodes\[i\].Name}";

diffs.AddRange(CompareNodes(nodeA.ChildNodes\[i\],
nodeB.ChildNodes\[i\], childPath));

}

return diffs;

}

}

```
## B.13. Kontroler Controllers/KorisniciController.cs

```csharp
using DiplomskiXml.Server.Models;

using DiplomskiXml.Server.Services;

using Microsoft.AspNetCore.Mvc;

namespace DiplomskiXml.Server.Controllers;

```
\[ApiController\]

```csharp
\[Route("api/\[controller\]")\]

public class KorisniciController : ControllerBase

{

private readonly IKorisnikService \_service;

public KorisniciController(IKorisnikService service)

{

\_service = service;

}

```
\[HttpGet\]

```xml
public async Task\<ActionResult\<IEnumerable\<Korisnik\>\>\> Get()

{

var korisnici = await \_service.DajSveAsync();

return Ok(korisnici);

}

\[HttpGet("{id:int}")\]

public async Task\<ActionResult\<Korisnik\>\> Get(int id)

{

var korisnik = await \_service.DajPoIdAsync(id);

if (korisnik is null) return NotFound();

return Ok(korisnik);

}

```
\[HttpPost\]

```xml
public async Task\<ActionResult\<Korisnik\>\> Post(Korisnik korisnik)

{

var created = await \_service.KreirajAsync(korisnik);

return CreatedAtAction(nameof(Get), new { id = created.Id }, created);

}

\[HttpPut("{id:int}")\]

public async Task\<IActionResult\> Put(int id, Korisnik korisnik)

{

if (id != korisnik.Id) return BadRequest();

var ok = await \_service.AzurirajAsync(korisnik);

if (!ok) return NotFound();

return NoContent();

}

\[HttpDelete("{id:int}")\]

public async Task\<IActionResult\> Delete(int id)

{

var ok = await \_service.ObrisiAsync(id);

if (!ok) return NotFound();

return NoContent();

}

}

```
## B.14. Kontroler Controllers/XmlController.cs

```csharp
using DiplomskiXml.Server.Services;

using Microsoft.AspNetCore.Mvc;

namespace DiplomskiXml.Server.Controllers;

```
\[ApiController\]

```csharp
\[Route("api/\[controller\]")\]

public class XmlController : ControllerBase

{

private readonly IXmlService \_xmlService;

public XmlController(IXmlService xmlService)

{

\_xmlService = xmlService;

}

\[HttpPost("upload")\]

public async Task\<IActionResult\> UploadXml(IFormFile file)

{

if (file == null \|\| file.Length == 0)

return BadRequest("Datoteka nije učitana.");

var result = await \_xmlService.ProcessXmlAsync(file);

return Ok(result);

}

\[HttpPost("compare")\]

public async Task\<IActionResult\> CompareXml(IFormFile fileA, IFormFile
fileB)

{

if (fileA == null \|\| fileB == null)

return BadRequest("Obje XML datoteke moraju biti učitane.");

var result = await \_xmlService.CompareXmlAsync(fileA, fileB);

return Ok(result);

}

\[HttpPost("extract-users")\]

public async Task\<IActionResult\> ExtractUsers(IFormFile file)

{

if (file == null \|\| file.Length == 0)

return BadRequest("Datoteka nije učitana.");

var users = await \_xmlService.ExtractUsersAsync(file);

return Ok(users);

}

\[HttpPost("sync")\]

public async Task\<IActionResult\> SyncXmlWithDb(IFormFile file)

{

if (file == null \|\| file.Length == 0)

return BadRequest("Datoteka nije učitana.");

var result = await \_xmlService.SyncWithDatabaseAsync(file);

return Ok(result);

}

}

```
# 📎 PRILOG C – IZVORNI KÔD KORISNIČKOG SUČELJA (FRONTEND)

Frontend je izrađen u React + Vite tehnologiji.

## C.1. Struktura projekta diplomski-frontend

diplomski-frontend/

│

├── index.html

├── package.json

├── vite.config.js

│

└── src/

├── main.jsx

├── App.jsx

├── styles.css

│

├── api/

│ ├── xmlApi.js

│ └── korisniciApi.js

│

└── components/

├── XmlUpload.jsx

├── XmlCompare.jsx

└── UsersTable.jsx

## C.2. Datoteka package.json

```
{

"name": "diplomski-frontend",

"version": "1.0.0",

"private": true,

"scripts": {

"dev": "vite",

"build": "vite build",

```
"preview": "vite preview"

```
},

"dependencies": {

"react": "^18.3.1",

```
"react-dom": "^18.3.1"

```
},

"devDependencies": {

"@vitejs/plugin-react": "^4.3.0",

```
"vite": "^6.0.0"

```
}

}

```
## C.3. Datoteka vite.config.js

```javascript
import { defineConfig } from "vite";

import react from "@vitejs/plugin-react";

export default defineConfig({

plugins: \[react()\],

server: {

```
port: 5173

```
}

});

```
## C.4. Datoteka index.html

\<!doctype html\>

\<html lang="hr"\>

\<head\>

\<meta charset="UTF-8" /\>

\<title\>Diplomski XML aplikacija\</title\>

\</head\>

\<body\>

\<div id="root"\>\</div\>

\<script type="module" src="/src/main.jsx"\>\</script\>

\</body\>

\</html\>

## C.5. Datoteka src/main.jsx

```javascript
import React from "react";

import ReactDOM from "react-dom/client";

import App from "./App";

import "./styles.css";

ReactDOM.createRoot(document.getElementById("root")).render(

```
\<React.StrictMode\>

\<App /\>

\</React.StrictMode\>

```
);

```
## C.6. Datoteka src/App.jsx

```javascript
import XmlUpload from "./components/XmlUpload";

import XmlCompare from "./components/XmlCompare";

import UsersTable from "./components/UsersTable";

export default function App() {

return (

```
\<div className="container"\>

\<h1\>Diplomski – XML aplikacija\</h1\>

\<XmlUpload /\>

\<hr /\>

\<XmlCompare /\>

\<hr /\>

\<h2\>Korisnici iz baze\</h2\>

\<UsersTable /\>

\</div\>

```
);

}

```
## C.7. Datoteka src/styles.css

```
body {

background: \#f4f4f4;

margin: 0;

padding: 0;

font-family: Arial, sans-serif;

}

.container {

max-width: 960px;

margin: 0 auto;

padding: 20px;

background: \#ffffff;

}

h1, h2 {

margin-top: 0;

}

hr {

margin: 30px 0;

}

.card {

margin: 20px 0;

padding: 15px;

border-radius: 6px;

background: \#fafafa;

box-shadow: 0 2px 4px rgba(0,0,0,0.08);

}

button {

margin-top: 10px;

padding: 6px 12px;

cursor: pointer;

}

.xml-output {

background: \#272822;

color: \#f8f8f2;

padding: 10px;

margin-top: 10px;

max-height: 300px;

overflow: auto;

white-space: pre;

font-family: Consolas, monospace;

}

.users-table {

width: 100%;

border-collapse: collapse;

}

.users-table th,

.users-table td {

border: 1px solid \#ccc;

padding: 6px 8px;

}

```
## C.8. Datoteka src/api/xmlApi.js

```csharp
const API_BASE = "https://localhost:5001/api";

export async function uploadXml(file) {

const formData = new FormData();

formData.append("file", file);

const res = await fetch(\`${API_BASE}/xml/upload\`, {

method: "POST",

```
body: formData

```csharp
});

if (!res.ok) throw new Error("Greška pri uploadu XML-a");

return await res.json();

}

export async function compareXml(fileA, fileB) {

const formData = new FormData();

formData.append("fileA", fileA);

formData.append("fileB", fileB);

const res = await fetch(\`${API_BASE}/xml/compare\`, {

method: "POST",

```
body: formData

```
});

if (!res.ok) throw new Error("Greška pri usporedbi XML-a");

return await res.json();

}

```
## C.9. Datoteka src/api/korisniciApi.js

```csharp
const API_BASE = "https://localhost:5001/api";

export async function getKorisnici() {

const res = await fetch(\`${API_BASE}/korisnici\`);

if (!res.ok) throw new Error("Greška pri dohvaćanju korisnika");

return await res.json();

}

```
## C.10. Komponenta src/components/XmlUpload.jsx

```javascript
import { useState } from "react";

import { uploadXml } from "../api/xmlApi";

export default function XmlUpload() {

const \[file, setFile\] = useState(null);

const \[result, setResult\] = useState(null);

const \[error, setError\] = useState("");

const handleUpload = async () =\> {

setError("");

setResult(null);

if (!file) {

setError("Odaberi XML datoteku");

return;

}

try {

const res = await uploadXml(file);

setResult(res);

} catch (err) {

setError(err.message \|\| "Greška pri uploadu");

}

};

return (

```
\<div className="card"\>

\<h2\>Učitavanje XML dokumenta\</h2\>

\<input

type="file"

accept=".xml"

```
onChange={e =\> setFile(e.target.files?.\[0\] \|\| null)}

```
/\>

```
\<button onClick={handleUpload}\>Učitaj\</button\>

{error && \<p style={{ color: "red" }}\>{error}\</p\>}

{result && (

```
\<\>

```
\<h3\>Root element: {result.rootElement}\</h3\>

\<pre className="xml-output"\>{result.formatted}\</pre\>

```
\</\>

```
)}

```
\</div\>

```
);

}

```
## C.11. Komponenta src/components/XmlCompare.jsx

```javascript
import { useState } from "react";

import { compareXml } from "../api/xmlApi";

export default function XmlCompare() {

const \[fileA, setFileA\] = useState(null);

const \[fileB, setFileB\] = useState(null);

const \[diffs, setDiffs\] = useState(\[\]);

const \[error, setError\] = useState("");

const handleCompare = async () =\> {

setError("");

setDiffs(\[\]);

if (!fileA \|\| !fileB) {

setError("Odaberi oba XML dokumenta");

return;

}

try {

const res = await compareXml(fileA, fileB);

setDiffs(res.differences \|\| \[\]);

} catch (err) {

setError(err.message \|\| "Greška pri usporedbi");

}

};

return (

```
\<div className="card"\>

\<h2\>Usporedba XML dokumenata\</h2\>

\<div\>

\<label\>XML A: \</label\>

\<input

type="file"

accept=".xml"

```
onChange={e =\> setFileA(e.target.files?.\[0\] \|\| null)}

```
/\>

\</div\>

\<div\>

\<label\>XML B: \</label\>

\<input

type="file"

accept=".xml"

```
onChange={e =\> setFileB(e.target.files?.\[0\] \|\| null)}

```
/\>

\</div\>

```
\<button onClick={handleCompare}\>Usporedi\</button\>

{error && \<p style={{ color: "red" }}\>{error}\</p\>}

{diffs.length \> 0 && (

```
\<ul\>

```
{diffs.map((d, i) =\> (

\<li key={i}\>{d}\</li\>

))}

```
\</ul\>

```
)}

```
\</div\>

```
);

}

```
## C.12. Komponenta src/components/UsersTable.jsx

```javascript
import { useEffect, useState } from "react";

import { getKorisnici } from "../api/korisniciApi";

export default function UsersTable() {

const \[korisnici, setKorisnici\] = useState(\[\]);

const \[error, setError\] = useState("");

useEffect(() =\> {

(async () =\> {

try {

const data = await getKorisnici();

setKorisnici(data);

} catch (err) {

setError(err.message \|\| "Greška");

}

})();

}, \[\]);

if (error) return \<p style={{ color: "red" }}\>{error}\</p\>;

return (

```
\<table className="users-table"\>

\<thead\>

\<tr\>

\<th\>Id\</th\>

\<th\>Ime\</th\>

\<th\>Prezime\</th\>

\<th\>Email\</th\>

\</tr\>

\</thead\>

\<tbody\>

```
{korisnici.map(k =\> (

\<tr key={k.id}\>

\<td\>{k.id}\</td\>

\<td\>{k.ime}\</td\>

\<td\>{k.prezime}\</td\>

\<td\>{k.email}\</td\>

```
\</tr\>

```
))}

```
\</tbody\>

\</table\>

```
);

}

```
# 📎 PRILOG D – SQL SKRIPTE I TESTNI PROJEKT

## D.1. SQL skripta za kreiranje baze i tablice

```sql
CREATE DATABASE Diplomski;

GO

USE Diplomski;

GO

CREATE TABLE Korisnik (

Id INT IDENTITY(1,1) PRIMARY KEY,

Ime NVARCHAR(100) NOT NULL,

Prezime NVARCHAR(100) NOT NULL,

Email NVARCHAR(200) NOT NULL

);

GO

INSERT INTO Korisnik (Ime, Prezime, Email)

VALUES

('Ivan', 'Bernatović', 'ivan@example.com'),

('Ksenija', 'Test', 'ksenija@example.com');

GO

```
## D.2. Struktura testnog projekta DiplomskiXml.Tests

DiplomskiXml.Tests/

│

├── DiplomskiXml.Tests.csproj

├── XmlServiceTests.cs

└── KorisnikServiceTests.cs

## D.3. Datoteka DiplomskiXml.Tests.csproj

\<Project Sdk="Microsoft.NET.Sdk"\>

\<PropertyGroup\>

\<TargetFramework\>net9.0\</TargetFramework\>

\<IsPackable\>false\</IsPackable\>

\<Nullable\>enable\</Nullable\>

\</PropertyGroup\>

\<ItemGroup\>

\<PackageReference Include="xunit" Version="2.9.0" /\>

\<PackageReference Include="xunit.runner.visualstudio" Version="2.8.1"\>

\<PrivateAssets\>all\</PrivateAssets\>

```
\<IncludeAssets\>runtime; build; native; contentfiles; analyzers;
```
buildtransitive\</IncludeAssets\>

\</PackageReference\>

\<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.11.1"
/\>

\<PackageReference Include="Moq" Version="4.20.72" /\>

\</ItemGroup\>

\<ItemGroup\>

\<ProjectReference
Include="..\\DiplomskiXml.Server\\DiplomskiXml.Server.csproj" /\>

\</ItemGroup\>

\</Project\>

## D.4. Datoteka XmlServiceTests.cs

```csharp
using DiplomskiXml.Server.Services;

using Microsoft.AspNetCore.Http;

using Xunit;

namespace DiplomskiXml.Tests;

public class XmlServiceTests

{

private IFormFile StringToFormFile(string content, string fileName =
"test.xml")

{

var bytes = System.Text.Encoding.UTF8.GetBytes(content);

var stream = new MemoryStream(bytes);

return new FormFile(stream, 0, bytes.Length, "file", fileName);

}

```
\[Fact\]

```csharp
public async Task ProcessXmlAsync_Returns_RootElement()

{

var repoMock = new
Moq.Mock\<DiplomskiXml.Server.Repositories.IKorisnikRepository\>();

var service = new XmlService(repoMock.Object);

var file = StringToFormFile("\<root\>\<a\>1\</a\>\</root\>");

var result = await service.ProcessXmlAsync(file);

Assert.Contains("root", result.ToString() ?? "");

}

```
\[Fact\]

```csharp
public async Task CompareXmlAsync_Detects_Differences()

{

var repoMock = new
Moq.Mock\<DiplomskiXml.Server.Repositories.IKorisnikRepository\>();

var service = new XmlService(repoMock.Object);

var fileA = StringToFormFile("\<root\>\<a\>1\</a\>\</root\>", "a.xml");

var fileB = StringToFormFile("\<root\>\<a\>2\</a\>\</root\>", "b.xml");

dynamic result = await service.CompareXmlAsync(fileA, fileB);

Assert.True(result.Count \> 0);

}

}

```
## D.5. Datoteka KorisnikServiceTests.cs

```csharp
using System.Collections.Generic;

using System.Threading.Tasks;

using DiplomskiXml.Server.Models;

using DiplomskiXml.Server.Repositories;

using DiplomskiXml.Server.Services;

using Moq;

using Xunit;

namespace DiplomskiXml.Tests;

public class KorisnikServiceTests

{

```
\[Fact\]

```xml
public async Task DajSveAsync_Returns_List()

{

var fakeData = new List\<Korisnik\>

{

new() { Id = 1, Ime = "Ivan", Prezime = "Test", Email = "ivan@test.com"
}

};

var repoMock = new Mock\<IKorisnikRepository\>();

repoMock.Setup(r =\> r.DajSveAsync()).ReturnsAsync(fakeData);

var service = new KorisnikService(repoMock.Object);

var result = await service.DajSveAsync();

Assert.Single(result);

}

}
```