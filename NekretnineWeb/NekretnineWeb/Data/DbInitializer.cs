using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NekretnineWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            ApplicationDbContext context =
                applicationBuilder.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Cities.Any())
            {
                context.Cities.AddRange(Cities.Select(c => c.Value));
            }
            //if (!context.Roles.Any())
            //{
            //    IdentityRole role = new IdentityRole();
            //    role.Name = "Admin";
            //    context.Roles.Add(role);
            //}
           
            //if (!context.Properties.Any())
            //{
            //    context.AddRange
            //    (
            //        //courses.Single(c => c.Title == "Chemistry").CourseID
            //        //new Property { Customer = Customers.Single(c => c.Value.FirstName == "Ana").Value, CustomerId = 0, City = Cities.Single(c => c.Value.CityName == "Beograd").Value, CityId = Cities.Single(c => c.Value.CityName == "Beograd").Value.CityId, Price = 70000, ShortDescription = "Kuca sa velikim dvorištem", LongDescription = "Kuca sa velikim dvorištem, u kojem se nalazi bašta i bazen", Category = Categories.Single(c => c.Value.CategoryName == "Kuca").Value, CategoryId = Categories.Single(c => c.Value.CategoryName == "Kuca").Value.CategoryId, ImageUrl = "https://7wuxfa.bn.files.1drv.com/y4m9JeLv8HRYThlF6d2538eRN2Mb2YLSgd__1mgxRM4AUEZ_7HohngLlc8ahyt5VKhwKexiX6ISfpQ_zXNs-lzmrjIEuar0CsLSwsCWrtG-GsnkDu2stdJY75OX3P72K36zdpRObn0edPV2NLeO5Y-aOTvKoglAfeQZH8xxddErDR-UjaLdCI49Bt4Ji5mnnyDQvjmensP06-MSP4vbTDrsYA?width=1197&height=682&cropmode=none", Address = "Novosadski put 11", Date = DateTime.Now, Area = 90, Baths = 2, Rooms = 5, Email = false, PhoneNumber = false, PropertyId = 0 }
            //        //new Property { City = Cities["Beograd"], Price = 20000, ShortDescription = "Poljoprivredno zemljište", LongDescription = "Poljoprivredno zemljište", Category = Categories["Poljoprivredno zemljište"], ImageUrl = "https://inpe8q.bn.files.1drv.com/y4mvBC8nKF3x_AFn30JJSoi1U_PiMoB3tcRFIYOUe5uwgYDNNyl9yWHDtrxYFa26yHj0RxVyfpycJPqwL-ObBeF1IAeiw4x7r9Xowp3sm-om__znDv6XSCkm2F6zYh7XozP98OvfITHCNfn3YUhC8oUZWUWj6u65BAwOxz1sRlVLDxLE5pWpTKlWLyHKIkcdA_2Vzi_-YAvwXTjAVDQuwty3A?width=800&height=533&cropmode=none", Address = "Futoški put 11", Date = DateTime.Now, Area = 1000, Email = false, PhoneNumber = false }
            //        //new Property { City = Cities["Niš"], Price = 40000, ShortDescription = "Stan na cetvrtom spratu u novoj zgradi", LongDescription = "Stan na cetvrtom spratu u novoj zgradi", Category = Categories["Stan"], ImageUrl = "https://7wwdtg.bn.files.1drv.com/y4mzaK3oWBOJq02Is03PTYMJ_TXco1NeRN9vr0ADVpKOP9tZMWLVe8tBBky-GTcynN1S4hj2cT9HJaaL32iu36XIfINybu_VM7E6IkrrQk9n0CqkYTBJVf31hbCTPZSqooc9-KJiAVrmfbuWOF_Zw-wUQS_JhQlrphrC-Co4KwnSayTcd4COpxFT3WgXkWR0jH6DjjmQNMK81fXsgivm2gIYA?width=720&height=405&cropmode=none", Address = "Cirpanova 85", Date = DateTime.Now, Area = 70, Baths = 1, Rooms = 3, Email = false, PhoneNumber = false },
            //        //new Property { City = Cities["Pirot"], Price = 15000, ShortDescription = "Prelep pogled na reku", LongDescription = "Vikendica se nalazi u prelepoj prirodi.", Category = Categories["Vikendica"], ImageUrl = "https://inrfzq.bn.files.1drv.com/y4mKghZds7VvdV09lyYcHRbQEkaEYjC4Ouz6zj8nm3pAwoptBk1uwOL8cQ0J76TGpCsBu5IqbbWlIA2D2lOh0FHU1MrD7pX6-3o2oZ9P_aYTYAdvaEjnAdiu81Np_4iOmDoFQFxqtERV7J7a9R8bWVJrg_ghitzzKWupyj7xhwwc-tqLqcnHQcCgaj3jrs3eV5aJmP1AWez9OyFEw-uJRXh3Q?width=800&height=533&cropmode=none", Address = "Bulevar Cara Dušana 3", Date = DateTime.Now, Area = 50, Baths = 1, Rooms = 1, Email = false, PhoneNumber = false },
            //        //new Property { City = Cities["Novi Sad"], Price = 5000, ShortDescription = "Višenamenski pomocni objekat", LongDescription = "Višenamenski pomocni objekat", Category = Categories["Pomocni objekat"], ImageUrl = "https://inploa.bn.files.1drv.com/y4myzQCuKAudKDUzb6LDkLOIsZbCJ4j1ZBcazPVJfgKoxdPnVLkSyp_LMCPw7Ib4pS0NZIqB3bhSLB9a3dvRN-Uty0Tmi006S85ZjjOu2AURDZP9Gm6j7nlXGhJ8GHL60RCzfl-DrwmjjTNdUNp2Zq0EBDvYlZmBx65VC8e6tH9yODJeSpq_KxbF5vUa3aGQlMhdRZhfb3Yx7hGWPoUL2-SGQ?width=1024&height=768&cropmode=none", Address = "Bulevar Oslobodenja 21", Date = DateTime.Now, Area = 300, Email = false, PhoneNumber = false },
            //        //new Property { City = Cities["Subotica"], Price = 100000, ShortDescription = "Lokal se nalazi u samom centru grada", LongDescription = "Lokal se nalazi u samom centru grada", Category = Categories["Poslovni prostor"], ImageUrl = "https://inqwww.bn.files.1drv.com/y4mtOVM3R-Q5C_cf6mAbXFg5ugge6D7P-AfJvM9uxm1vCuUOfSriomurpSUGrURXgE7IJr3ID9pRemnz-0cPrKdv60xTfbaNDohjAjBGHyca2SrkDfLEj6znPK8DVhb4izdjvfBiOleXpRc_2wNcI1OCtVW_qwXXH_9e-RZtujeHlkaHCfny-h7hMtxDuULfKe32hW5b9XMKJeceTpyBrbxaw?width=500&height=332&cropmode=none", Address = "Novosadski put 18", Date = DateTime.Now, Area = 100, Baths = 1, Email = false, PhoneNumber = false },
            //        //new Property { City = Cities["Jagodina"], Price = 250000, ShortDescription = "Sportski objekat", LongDescription = "Sportski objekat", Category = Categories["Sportski objekat"], ImageUrl = "https://inp62g.bn.files.1drv.com/y4mahdWZhsd118d5kgbGG_PQ1qzlOh4Ev9g1OKno5F6SlSj8gzmEYozypSFECmJQ8dDaPDdxfiWFjDnRKXPcnx03NiyhkoBz7hO823ljExLvnANevLQ5HODWLvVWwSEuf1tBj8LXWcNYbAc0ZJgijfAxYcYm74yrTs0OF94CqdeU4hwdGaFZ9_5twCsIcPaZ8_ZO6FuVyPxZ5VLzVCIxwikdA?width=900&height=599&cropmode=none", Address = "Novosadski put 1", Date = DateTime.Now, Area = 800, Baths = 7, Email = false, PhoneNumber = false },
            //        //new Property { City = Cities["Beograd"], Price = 30000, ShortDescription = "Plac spreman za gradnju", LongDescription = "Zemljište spreman za gradnju", Category = Categories["Gradevinsko zemljište"], ImageUrl = "https://inovtw.bn.files.1drv.com/y4mxTNHx9wGZiriXOTidqlbYBPKZOyx3O4sgrWQ0-Nk9560juKIIsZZjhb59TFnfNvDJ2ckeexL2kScmO1iwGdKsfStuCfQYRFCBixZ_Y3fnVlXVTXs2ZXsAyTe1NzVQRBvh9HAzZ1QsgBYJDbxybCOhVFaU04ibZ4UNS9kPoPQ6jnD6hCUKudqAsrg3u7Bp510iy4KC6b0HJ99IqvPwtHGLg?width=620&height=348&cropmode=none", Address = "Futoška 19", Date = DateTime.Now, Area = 100, Email = false, PhoneNumber = false },
            //        //new Property { City = Cities["Beograd"], Price = 150000, ShortDescription = "Kuca sa dve garaže", LongDescription = "Kuca sa dve garaže", Category = Categories["Kuca"], ImageUrl = "https://7wxm8a.bn.files.1drv.com/y4mp7yNdOd-arDcOMJ5Qv1grondFE3codPe_mZFEARUvLuJmofFz2Jeocubh3Q7qM_uAPJ9YbUlsrACTyJcVNz_Ho2Ay-OOaW-Y4LcF0ZnXyrDlvW3K3dMULRVYFfzjLonO3YTzSIATUeGp_OpSjkSpbE_-TpFLT-rAtvsJlrJhKvt3YzMD4ZQX7zbHXmjs-_vUfUmlARl0bdSxBiHjAo62uw?width=1920&height=1280&cropmode=none", Address = "Kneginja Milica 21", Date = DateTime.Now, Area = 300, Baths = 3, Rooms = 5, Email = false, PhoneNumber = false },
            //        //new Property { City = Cities["Vranje"], Price = 35000, ShortDescription = "Prekrasan stan sa svojim parkingom", LongDescription = "Dvosoban stan sa parkingom. 54 kvadratnih metara s pokrivenom terasom. Stan ima centralno grejanje.", Category = Categories["Stan"], ImageUrl = "https://inqpfa.bn.files.1drv.com/y4m1PqSMq24hX6RPPMg7O4GQj9cu8iFYmR_ZxrqlgeOv7FoiPCTtfz9480y8rKxcJCF1eZcpnx3cP-1VKpjppdAgoA1H62CzfxPdj-XgmEf47uOCwi4CZJe0JT7eA8EHuK_TwljdB4lyT3ogSi8s7HgJVKcGL8v56eTPmaQQZDYCNI0pBQeRaINwAsnOaK_bFkdf0DFk5BEYrxEfTJciwt99Q?width=640&height=425&cropmode=none", Address = "Futoška 25", Date = DateTime.Now, Area = 54, Baths = 1, Rooms = 2, Email = false, PhoneNumber = false },
            //        //new Property { City = Cities["Kragujevac"], Price = 65000, ShortDescription = "Kuca u Kragujevcu", LongDescription = "Kuca u Kragujevcu", Category = Categories["Kuca"], ImageUrl = "https://7wvnzq.bn.files.1drv.com/y4mbfuVIyKmnQR4afEslOibHMhx7tyD2fbUULfOS99PVVd1PN5RCcp_NJXjaLKOQ1KS5Y7DGnEirrCfREfj9mlLfJeyXJr3zThRiTKywl2miR4shaFntmZszusLkSkeAX_mdaZrrn-_ZdXm8EGN9Y6OrNPKi9sezNsMkTA2CuKsUBS_Tb4mnwat9-v1A549N6TvJj483wnYG8xOKthiTFjELg?width=1280&height=720&cropmode=none", Address = "Novosadski put 51", Date = DateTime.Now, Area = 100, Baths = 2, Rooms = 4, Email = false, PhoneNumber = false }
            //    );
            //}

            context.SaveChanges();

        }
        //private UserManager<ApplicationUser> _userManager;
        //private var user = await _userManager.GetUserAsync(User);
        //ApplicationUser auser = (ApplicationUser)UserManager<ApplicationUser>.FindById(model.Id);

        //ApplicationUser user = await useri.GetUserAsync(0);
        private static Dictionary<string, ApplicationUser> customers;
        private static Dictionary<string, ApplicationUser> Customers
        {
            get
            {
                if (customers == null)
                {
                    var genresList = new ApplicationUser[]
                    {
                        new ApplicationUser { FirstName = "Mico" }
                    };

                    customers = new Dictionary<string, ApplicationUser>();

                    foreach (ApplicationUser genre in genresList)
                    {
                        customers.Add(genre.FirstName, genre);
                    }
                }
                return customers;
            }
        }
        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                //if (categories == null)
                //{
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Kuća" },
                        new Category { CategoryName = "Stan" },
                        new Category { CategoryName = "Vikendica" },
                        new Category { CategoryName = "Pomoćni objekat" },
                        new Category { CategoryName = "Poslovni prostor" },
                        new Category { CategoryName = "Sportski objekat" },
                        new Category { CategoryName = "Građevinsko zemljište" },
                        new Category { CategoryName = "Poljoprivredno zemljište" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                //}

                return categories;
            }
        }
        private static Dictionary<string, City> cities;
        public static Dictionary<string, City> Cities
        {
            get
            {
                //if (cities == null)
                //{
                    var genresList = new City[]
                    {
                        new City { CityName = "Novi Sad", Country = "Srbija", Area = 702.7, Population = 341625, ImageUrl1 = "~/images/Gradovi/NoviSad1.jpg", ImageUrl2 = "~/images/Gradovi/NoviSad2.jpg", ImageUrl3 = "~/images/Gradovi/NoviSad3.jpg", Description = "Novi Sad je najveći grad Autonomne Pokrajine Vojvodine i njen administrativni centar, posle Beograda drugi grad u Srbiji po broju stanovnika. Prema konačnim rezultatima popisa stanovništva iz 2011. godine, na administrativnoj teritoriji Grada Novog Sada je živelo 341.625 stanovnika, dok je u samom naselju Novi Sad živelo 250.439 stanovnika, a na urbanom području koje čini Grad Novi Sad 277.522 stanovnika. Osnovan 1694. godine, Novi Sad je dugo vremena bio centar srpske kulture, zbog čega je dobio ime „Srpska Atina“. Danas je Novi Sad veliki industrijski i finansijski centar srpske ekonomije, univerzitetski grad i školski centar, kulturni, naučni, zdravstveni i politički centar Autonomne Pokrajine Vojvodine, grad domaćin mnogih međunarodnih i domaćih privrednih, kulturnih, naučnih i sportskih manifestacija, kao i grad muzeja, galerija, biblioteka i pozorišta." },
                        new City { CityName = "Beograd", Country = "Srbija", Area = 3227, Population = 1659440, ImageUrl1 = "~/images/Gradovi/Beogard1.jpg", ImageUrl2 = "~/images/Gradovi/Beograd2.jpg", ImageUrl3 = "~/images/Gradovi/Beograd3.jpg", Description = "Grad Beograd ima status posebne teritorijalne jedinice u Srbiji sa svojom lokalnom samoupravom. Njegova teritorija podeljena je na 17 gradskih opština, od kojih svaja ima svoje lokalne organe vlasti.Beograd zauzima preko 3,6% teritorije Srbije, a u njemu živi 21% ukupnog broja građana Srbije.Beograd je takođe ekonomski centar Srbije i središte srpske kulture, obrazovanja i nauke. Prema Zakonu o regionalnom razvoju, okrug grada Beograd će dobiti i nadležnosti i status statističkog regiona." },
                        new City { CityName = "Niš", Country = "Srbija", Area = 596.73, Population = 260273, ImageUrl1 = "~/images/Gradovi/Nis1.jpg", ImageUrl2 = "~/images/Gradovi/Nis2.jpg", ImageUrl3 = "~/images/Gradovi/Nis3.jpg", Description = "Niš je najveći grad u jugoistočnoj Srbiji i sedište Nišavskog upravnog okruga. Na području Grada Niša je, prema popisu iz 2011, živelo 260.237 stanovnika, dok je u samom naseljenom mestu živelo 183.164 stanovnika, pa je tako po broju stanovnika Niš treći grad po veličini u Srbiji (posle Beograda i Novog Sada)." },
                        new City { CityName = "Jagodina", Country = "Srbija", Area = 470, Population = 71852, ImageUrl1 = "~/images/Gradovi/Jagodina1.jpg", ImageUrl2 = "~/images/Gradovi/Jagodina2.jpg", ImageUrl3 = "~/images/Gradovi/Jagodina3.jpg", Description = "Grad Jagodina je grad u Pomoravskom okrugu u središtu Srbije, u Šumadiji. Središte grada kao i okruga je gradsko naselje Jagodina. Prema popisu iz 2011. bilo je 71.852 stanovnika, od čega 37.282 u samom gradu." },
                        new City { CityName = "Kragujevac", Country = "Srbija", Area = 835, Population = 179417, ImageUrl1 = "~/images/Gradovi/Kragujevac1.jpg", ImageUrl2 = "~/images/Gradovi/Kragujevac2.jpg", ImageUrl3 = "~/images/Gradovi/Kragujevac3.jpg", Description = "Kragujevac je značajan privredni, kulturni, obrazovni i zdravstveni centar Šumadije, Pomoravlja i susednih regiona. Makroregionalni je centar za regione: Čačka, Kraljeva, Užica, Jagodine, Kruševca, Smedereva, Požarevca i severnog Kosova. Početkom 1990.ih godina grad postaje jedan od siromašnijih gradova u Srbiji. Danas je Kragujevac ponovo jedan od najjačih administrativnih, kulturnih, finansijskih, industrijskih i političkih centara u Srbiji." },
                        new City { CityName = "Kruševac", Country = "Srbija", Area = 854, Population = 131368, ImageUrl1 = "~/images/Gradovi/Krusevac1.jpg", ImageUrl2 = "~/images/Gradovi/Krusevac2.jpg", ImageUrl3 = "~/images/Gradovi/Krusevac3.jpg", Description = "Grad Kruševac je grad na reci Rasini u dolini Zapadnog Pomoravlja u Rasinskom okrugu u središnjoj Srbiji. Središte grada kao i okruga je gradsko naselje Kruševac." },
                        new City { CityName = "Subotica", Country = "Srbija", Area = 1007, Population = 141554, ImageUrl1 = "~/images/Gradovi/Subotica1.jpg", ImageUrl2 = "~/images/Gradovi/Subotica2.jpg", ImageUrl3 = "~/images/Gradovi/Subotica3.jpg", Description = "Grad Subotica (opštinska jedinica, aglomerat – po novom zakonu) se nalazi u širokoj ravnici na krajnjem severu Vojvodine, u blizini granice Srbije i Mađarske. Teritorija administrativne oblasti grada se ujedno preklapa sa područjem Severnobačkog upravnog okruga. Središte grada kao i okruga je gradsko naselje Subotica." },
                        new City { CityName = "Priština", Country = "Srbija", Area = 572, Population = 204937, ImageUrl1 = "~/images/Gradovi/Cacak1.jpg", ImageUrl2 = "~/images/Gradovi/Cacak2.jpg", ImageUrl3 = "~/images/Gradovi/Cacak3.jpg", Description = "Grad Priština je teritorijalna jedinica u Srbiji, koja se nalazi na Kosovu i Metohiji i pripada Kosovskom upravnom okrugu. Središte je gradsko naselje Priština." },
                        new City { CityName = "Zrenjanin", Country = "Srbija", Area = 1324, Population = 123362, ImageUrl1 = "~/images/Gradovi/Zrenjanin1.jpg", ImageUrl2 = "~/images/Gradovi/Zrenajnin2.jpg", ImageUrl3 = "~/images/Gradovi/Zrenjanin3.jpg", Description = "Grad Zrenjanin je jedan od gradova u Republici Srbiji. Nalazi se u AP Vojvodina i spada u Srednjobanatski okrug. Po podacima iz 2004. opština zauzima površinu od 1324 km2 (od čega na poljoprivrednu površinu otpada 112340 ha, a na šumsku 1392 ha. Grad Zrenjanin se sastoji od 22 naselja. Po podacima iz 2002. godine u gradu je živelo 132051 stanovnika. Po podacima iz 2004. prirodni priraštaj je iznosio -4,9‰, a broj zaposlenih u opštini iznosi 33081 ljudi. U gradu se nalaze 32 osnovne i 8 srednjih škola." },
                        new City { CityName = "Čačak", Country = "Srbija", Area = 636, Population = 117072, ImageUrl1 = "~/images/Gradovi/Cacak1.jpg", ImageUrl2 = "~/images/Gradovi/Cacak2.jpg", ImageUrl3 = "~/images/Gradovi/Cacak3.jpg", Description = "Grad Čačak se nalazi u središnjem delu centralne Srbije u Moravičkom okrugu, između opština Gornji Milanovac na severu i opštine Lučana na jugozapadu. Na zapadu je opština Požega koja pripada Zlatiborskom okrugu, istočno je opština Knić koja je sastavu Šumadijskog okruga, a na jugoistoku je grad Kraljevo koja pripada Raškom okrugu." },
                        new City { CityName = "Kraljevo", Country = "Srbija", Area = 1529, Population = 121707, ImageUrl1 = "~/images/Gradovi/Kraljevo1.jpg", ImageUrl2 = "~/images/Gradovi/Kraljevo2.jpg", ImageUrl3 = "~/images/Gradovi/Kraljevo3.jpg", Description = "Grad Kraljevo je grad u Raškom okrugu na jugozapadu Srbije. Središte grada kao i okruga je gradsko naselje Kraljevo." },
                        new City { CityName = "Novi Pazar", Country = "Srbija", Area = 835, Population = 100410, ImageUrl1 = "~/images/Gradovi/NoviPazar1.jpg", ImageUrl2 = "~/images/Gradovi/NoviPazar2.jpg", ImageUrl3 = "~/images/Gradovi/NoviPazar3.jpg", Description = "Grad Novi Pazar je grad u Raškom okrugu u zapadoj Srbiji. Središte grada je gradsko naselje Novi Pazar." },
                        new City { CityName = "Leskovac", Country = "Srbija", Area = 1025, Population = 144206, ImageUrl1 = "~/images/Gradovi/Leskovac1.jpg", ImageUrl2 = "~/images/Gradovi/Leskovac2.jpg", ImageUrl3 = "~/images/Gradovi/Leskovac3.jpg", Description = "Leskovac je administrativni centar Jablaničkog okruga. Status grada dobio je 2007. godine. Grad se nalazi u Leskovačkoj kotlini, poznatoj po srpskom petorečju." },
                        new City { CityName = "Smederevo", Country = "Srbija", Area = 484, Population = 108209, ImageUrl1 = "~/images/Gradovi/Smederevo1.jpg", ImageUrl2 = "~/images/Gradovi/Smederevo2.jpg", ImageUrl3 = "~/images/Gradovi/Smederevo3.jpg", Description = "Grad Smederevo je grad u Podunavskom okrugu u centralnoj Srbiji. Po podacima iz 2004. grad zauzima površinu od 484 km² (od čega na poljoprivrednu površinu otpada 38.817 ha, a na šumsku 2.617 ha). Sedište grada kao i okruga je gradsko naselje Smederevo. Grad Smederevo se sastoji od 28 naselja: jednog gradskog i 27 ostalih naselja. Po podacima iz 2011. godine u gradu je živelo 108.209 stanovnika. Po podacima iz 2004. prirodni priraštaj je iznosio -1,7‰, a broj zaposlenih u gradu iznosi 30.219 ljudi. U gradu se nalaze 33 osnovne i 4 srednje škole." },
                        new City { CityName = "Vranje", Country = "Srbija", Area = 860, Population = 83524, ImageUrl1 = "~/images/Gradovi/Vranje1.jpg", ImageUrl2 = "~/images/Gradovi/Vranje2.jpg", ImageUrl3 = "~/images/Gradovi/Vranje3.jpg", Description = "Grad Vranje je grad u Pčinjskom okrugu na jugu Srbije. Po podacima iz 2004. zauzima površinu od 860 km2 (od čega na poljoprivrednu površinu otpada 44.721 ha, a na šumsku 32.478 ha). Sedište grada kao i okruga je gradsko naselje Vranje. Grad Vranje se sastoji od 27 naselja: 2 gradska (Vranje i Vranjska Banja) i 103 seoska naselja. Po podacima iz 2002. godine u gradu je živelo 87.288 stanovnika. Po prethodnom popisu, iz 1991. godine, je bilo 86.518 stanovnika. Po podacima iz 2004. prirodni priraštaj je iznosio 1,8‰, a broj zaposlenih iznosi 25.940 ljudi. U gradu Vranju se nalazi 60 osnovnih, 7 srednjih škola, jedna viša škola i jedan fakultet." },
                        new City { CityName = "Užice", Country = "Srbija", Area = 666.7, Population = 78040, ImageUrl1 = "~/images/Gradovi/Uzice1.jpg", ImageUrl2 = "~/images/Gradovi/Uzice2.jpg", ImageUrl3 = "~/images/Gradovi/Uzice3.jpg", Description = "Grad Užice je grad u Zlatiborskom okrugu na zapadu Srbije. Sedište grada kao i okruga je gradsko naselje Užice. Grad Užice se sastoji od 41 naselja: 2 gradska (Sevojno i Užice) i 39 seoska naselja. Užice od Beograda udaljeno je 195 km²." },
                        new City { CityName = "Valjevo", Country = "Srbija", Area = 905, Population = 90312, ImageUrl1 = "~/images/Gradovi/Valjevo1.jpg", ImageUrl2 = "~/images/Gradovi/Valjevo2.jpg", ImageUrl3 = "~/images/Gradovi/Valjevo3.jpg", Description = "Grad Valjevo je jedan od gradova u Republici Srbiji i pripada Kolubarskom okrugu. Nalazi u zapadnoj Srbiji u gornjem delu sliva reke Kolubare (pritoke Save), na kontaktu između planinskog i nizijskog dela Srbije. Grad Valjevo se graniči na severu sa opštinama Ub i Koceljeva, na zapadu sa Osečinom i Ljubovijom, na jugu sa Bajinom Baštom i Kosjerićem i na istoku sa Mionicom i Lajkovcem." },
                        new City { CityName = "Šabac", Country = "Srbija", Area = 795, Population = 115884, ImageUrl1 = "~/images/Gradovi/Sabac1.jpg", ImageUrl2 = "~/images/Gradovi/Sabac2.jpg", ImageUrl3 = "~/images/Gradovi/Sabac3.jpg", Description = "Grad Šabac je grad u Mačvanskom okrugu na zapadu Srbije. Po podacima iz 2004. grad zauzima površinu od 795 km2 (od čega na poljoprivrednu površinu otpada 60653 ha, a na šumsku 10037 ha). Središte grada kao i okruga je gradsko naselje Šabac. Gradu Šapcu pripada 52 naselja. Po podacima iz 2011. godine u gradu Šapcu je živelo 115884 stanovnika. Po podacima iz 2012. prirodni priraštaj je iznosio -5,6‰, a broj zaposlenih u gradu iznosi 27932 ljudi. U gradu se nalazi 60 osnovnih i 8 srednjih škola." },
                        new City { CityName = "Požarevac", Country = "Srbija", Area = 482, Population = 75334, ImageUrl1 = "~/images/Gradovi/Pozarevac1.jpg", ImageUrl2 = "~/images/Gradovi/Pozarevac2.jpg", ImageUrl3 = "~/images/Gradovi/Pozarevac3.jpg", Description = "Grad Požarevac je grad u Braničevskom okrugu u centralnoj Srbiji. Po podacima iz 2004. grad zauzima površinu od 482 km² (od čega na poljoprivrednu površinu otpada 35.313 ha, a na šumsku 2.179 ha). Sedište grada kao i okruga je gradsko naselje Požarevac. Grad Požarevac se sastoji od 27 naselja: 2 gradska (Kostolac i Požarevac) i 25 seoska naselja. Po podacima iz 2011. godine u gradu je živelo 75.334 stanovnika. Po podacima iz 2004. prirodni priraštaj je iznosio -0,9‰, dok je broj zaposlenih u gradu iznosio 22.944 ljudi. U gradu se nalaze 32 osnovne i 7 srednjih škola." },
                        new City { CityName = "Sombor", Country = "Srbija", Area = 1178, Population = 85903, ImageUrl1 = "~/images/Gradovi/Sombor1.jpg", ImageUrl2 = "~/images/Gradovi/Sombor2.jpg", ImageUrl3 = "~/images/Gradovi/Sombor3.jpg", Description = "Grad Sombor je jedan od gradova u Republici Srbiji. Nalazi se u AP Vojvodina i spada u Zapadnobački okrug. Po podacima iz 2004. grad zauzima površinu od 1178 km² (od čega na poljoprivrednu površinu otpada 101070 ha, a na šumsku 7076 ha). Središte grada kao i okruga je gradsko naselje Sombor. Grad Sombor se sastoji od 16 naselja. Po podacima iz 2011. godine u gradu je živelo 85.903 stanovnika. Po podacima iz 2004. prirodni priraštaj je iznosio -7,5‰, a broj zaposlenih u gradu iznosi 24029 ljudi. U gradu se nalazi 26 osnovnih i 6 srednjih škola." },
                        new City { CityName = "Pirot", Country = "Srbija", Area = 1232, Population = 57928, ImageUrl1 = "~/images/Gradovi/Pirot1.jpg", ImageUrl2 = "~/images/Gradovi/Pirot2.jpg", ImageUrl3 = "~/images/Gradovi/Pirot3.jpg", Description = "Grad Pirot je administrativna jedinica u Pirotskom okrugu u jugoistočnoj Srbiji. Prema popisu iz 2011. u gradu je živelo 57.928 stanovnika. Po podacima iz 2004. grad zauzima površinu od 1.232 km². Sedište grada kao i okruga je gradsko naselje Pirot. Opština Pirot je 29. februara 2016. dobila status grada." },
                        new City { CityName = "Zaječar", Country = "Srbija", Area = 1068, Population = 59461, ImageUrl1 = "~/images/Gradovi/Zajecar1.jpg", ImageUrl2 = "~/images/Gradovi/Zajecar2.jpg", ImageUrl3 = "~/images/Gradovi/Zajecar3.jpg", Description = "Grad Zaječar je grad u istočnoj Srbiji na granici sa Bugarskom. Nalazi se u centralnom delu u Timočke Krajine, u Zaječarskom okrugu u koji još spadaju opštine Sokobanja, Knjaževac i Boljevac. Središte je gradsko naselje Zaječar koji predstavlja administrativni, kulturni, privredni, ekonomski, politički i verski centar kako opštine tako i samog okruga." },
                        new City { CityName = "Kikinda", Country = "Srbija", Area = 782, Population = 59453, ImageUrl1 = "~/images/Gradovi/Kikinda1.jpg", ImageUrl2 = "~/images/Gradovi/Kikinda2.jpg", ImageUrl3 = "~/images/Gradovi/Kikinda3.jpg", Description = "Grad Kikinda je grad u Republici Srbiji. Nalazi se u AP Vojvodina i spada u Severnobanatski okrug. Po podacima iz 2004. opština zauzima površinu od 782 km2 (od čega na poljoprivrednu površinu otpada 70.594 ha, a na šumsku 214 ha). Sedište grada kao i okruga je gradsko naselje Kikinda. Grad Kikinda se sastoji od 10 naselja: jednog gradskog i 9 seoska naselja. Po podacima iz 2002. godine u opštini je živelo 67.002 stanovnika. Po podacima iz 2004. prirodni priraštaj je iznosio -5,7‰, a zaposlen u gradu je bio 17.371 čovek. U gradu se nalazi 15 osnovnih i 4 srednjih škola." },
                        new City { CityName = "Sremska Mitrovica", Country = "Srbija", Area = 762, Population = 79940, ImageUrl1 = "~/images/Gradovi/SremskaMitrovica1.jpg", ImageUrl2 = "~/images/Gradovi/SremskaMitrovica2.jpg", ImageUrl3 = "~/images/Gradovi/SremskaMitrovica3.jpg", Description = "Grad Sremska Mitrovica je jedan od gradova u Republici Srbiji. Nalazi se u AP Vojvodina i spada u Sremski okrug. Po podacima iz 2004. grad zauzima površinu od 762 km² (od čega na poljoprivrednu površinu otpada 56571 ha, a na šumsku 8705 ha). Središte grada kao i okruga je gradsko naselje Sremska Mitrovica. Grad Sremska Mitrovica ima 26 naselja. Po podacima iz 2011. godine u gradu je živelo 79940 stanovnika. Po podacima iz 2004. prirodni priraštaj je iznosio -3,8‰, a broj zaposlenih u opštini iznosi 18186 ljudi. U gradu se nalazi 39 osnovnih i 6 srednjih škola." },
                        new City { CityName = "Vršac", Country = "Srbija", Area = 800, Population = 52026, ImageUrl1 = "~/images/Gradovi/Vrsac1.jpg", ImageUrl2 = "~/images/Gradovi/Vrsac2.jpg", ImageUrl3 = "~/images/Gradovi/Vrsac3.jpg", Description = "Grad Vršac je jedan od gradova u Srbiji. Nalazi se u AP Vojvodina i spada u Južnobanatski okrug. Po podacima iz 2004. grad zauzima površinu od 800 km2 (od čega na poljoprivrednu površinu otpada 62.323 ha, a na šumsku 6.434 ha). Sedište grada je gradsko naselje Vršac. Grad Vršac se sastoji od 24 naselja: jednog gradskog i 23 seoska naselja. Po podacima iz 2011. godine u gradu je živelo 52.026 stanovnika. Po podacima iz 2004. prirodni priraštaj je iznosio -4,3‰, a u gradu je zaposlen 16.551 čovek. U gradu Vršcu se nalazi 27 osnovnih i 4 srednje škola." },
                        new City { CityName = "Loznica", Country = "Srbija", Area = 612, Population = 79327, ImageUrl1 = "~/images/Gradovi/Loznica1.jpg", ImageUrl2 = "~/images/Gradovi/Loznica2.jpg", ImageUrl3 = "~/images/Gradovi/Loznica3.jpg", Description = "Grad Loznica je grad u Mačvanskom okrugu na zapadu Srbije. Po podacima iz 2004. grad zauzima površinu od 612 km2 (od čega na poljoprivrednu površinu otpada 35965 ha, a na šumsku 19852 ha). Središte grada kao i okruga je gradsko naselje Loznica. Grad Loznica se sastoji od 54 naselja. Po podacima iz 2011. godine u gradu je živelo 79327 stanovnika. Po podacima iz 2004. prirodni priraštaj je iznosio -1,3‰, a broj zaposlenih iznosi 17228 ljudi. U gradu se nalazi 34 osnovnih i 4 srednje škole." },
                        new City { CityName = "Pančevo", Country = "Srbija", Area = 759, Population = 123414, ImageUrl1 = "~/images/Gradovi/Pancevo1.jpg", ImageUrl2 = "~/images/Gradovi/Pancevo2.jpg", ImageUrl3 = "~/images/Gradovi/Pancevo3.jpg", Description = "Grad Pančevo je jedan od gradova u Srbiji. Nalazi se u AP Vojvodina i spada u Južnobanatski okrug. Po podacima iz 2004. grad zauzima površinu od 759 km² (od čega na poljoprivrednu površinu otpada 63.225 ha, a na šumsku 1.085 ha). Središte grada kao i okruga je gradsko naselje Pančevo. Grad Pančevo se sastoji od 10 naselja: 2 gradska (Kačarevo, Pančevo) i 8 seoskih naselja. Po podacima iz 2011. godine u gradu je živelo 123.414 stanovnika. Po podacima iz 2004. prirodni priraštaj je iznosio -3‰, a broj zaposlenih u gradu iznosi 35.533 ljudi. U gradu se nalazi 19 osnovnih i 8 srednjih škola." }
                    };

                    cities = new Dictionary<string, City>();

                    foreach (City genre in genresList)
                    {
                        cities.Add(genre.CityName, genre);
                    }
                //}

                return cities;
            }
        }
    }
}
