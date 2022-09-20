using System.Text.RegularExpressions;

namespace AppCore.Helpers
{
    public static class ValidationVeiculo
    {
        private static string Fabricantes()
        {

            var lista = "Acura, Agrale, Alfa Romeo, Asia, AM General, Aston Martin, Audi, Adly, Aprilia, Atala, Amazonas, Austin, Apperson, Ashok Leyland, Alpina, Adler, Ascari, Abarth, Autobianchi, Aixam, AMG, AZLK, Avtokam, ACMAT, Albion, Argyle, Askam, Aspark Owl, A.D. Tramontana";
            lista += ", BMW, Buggy, BRM, Bugre, Bugatti, Bentley, Buick, Baker, Biddle, Bajaj, Bitter, Borgward, Briggs, Belsize, Bertone, Bianchi, Brilliance, Byd Auto, Baic, Birrana, Brabus, Birkin, Bailey";
            lista += ", Chevrolet, Cadillac, CBT, Chana, Changan, Chery, Chrysler, Citroen, Cross Lander, Chinkara, Caterham, Chater-Lea, Covini, Caresto, Changhe, Cizeta";
            lista += ", Daewoo, Daihatsu, Dodge, De Tomaso, Ducati, Delorean, DKW, DR Motor, De La Chapelle, Dongfeng, DRB, Derways, Dragon Motors, Daimler, Datsun, Dacia, DoniRosset";
            lista += ", Effa, Engesa, Envemo, Eicher, Esther, Elfin, Eagle, Eterniti, ERF, Elva";
            lista += ", Ferrari, FIAT, Fibravan, Ford, Foton, Fyber, Force, Fornasari, Fisker, Freightliner, Faw, FPV, Facel Vega, Fioravanti, Franklin";
            lista += ", Geely, GM, Great Wall, Gurgel, GMC, Gorhan, Gumpert, Ginetta, Geo, GAC, Giocattolo, Gaz, Genesis, Gillet, Grinnall";
            lista += ", Hafei, Honda, Hyunday, Harley-Davidson, Husqvarna, Hummer, Hindustan, Hongqi, Holden, HSV, Hino, Harper, Hero Motors";
            lista += ", Isuzu, Iveco, ICML Motors, Infiniti, Isdera, Invicta, Isotta Fraschini, Irizar, Innoson, Ivema";
            lista += ", Jeep, Jaguar, JPX, Jinbei, JAC, James & Browne, Josse Car, Jiefang";
            lista += ", Kia, Kahena, Kasinski, KTM, Keinath, Koenigsegg, Kamaz, Kawasaki, Karma, Kaz, Karrier, Kantanka, Kiira";
            lista += ", Lada, Lamborghini, Lancia, Land Rover, Lexus, Lifan, Lotus, Lobini, Lincoln, Laferrari, Ligier, Lagonda, Lucid, Luxgen, Laraki";
            lista += ", Mahindra, Maserati, Matra, MG, Mazda, Mclaren, Mercedes-Benz, Mercury, Miura, Mini, Mitsubishi, Maruti, Mitsuoka, Maybach, Microcar, Mack, Moskvich, Marussia, MAN, Marcos, Mazzanti, Morris, Mustang, MAZ, Mobius";
            lista += ", Nissan, Navistar, Nota, Nami Okhta, Noble";
            lista += ", Opel, Oldsmobile, Ohta Jidosha, Otosan, ÖAF ";
            lista += ", Peugeot, Plymouth, Pontiac, Porsche, Puma, Polaris, Panoz, Premier, Prince, Pagani, Panhard, PGO, Pyeonghwa, Proto, Perodua, Paccar, Pininfarina, Paramount Automotive, Proforce, Perana";
            lista += ", Qvale, Qoros";
            lista += ", RAM, Rely, Rover, Renault, Rolls-Royce, Rootes, Rambler, Riley, Rossion, RUF, Ronart, Rimac";
            lista += ", SAAB, Saturn, SEAT, Shineray, Smart, Ssangyong, Subaru, Suzuki, Sundown, Sino Truck, Scania, Scion, Saic, Spetsteh, Skoda, Shelby, Saleen, Sterling, Saroukh El-jamahiriya, Shaka Nynya";
            lista += ", TAC, Toyota, Troller, Tata, Triumph, Traxx, Tesla, Tatra, Trion, The Turtle, Tropical";
            lista += ", UAZ, Unimog, UEV, Ultima, Uri, URO";
            lista += ", Volvo, Volkswagen, Venturi, Volga, Vauxhall, Vector, Venucia, Vulcan, Vomag, Vanaja";
            lista += ", Wake, Walk, Wuyang, Wheego, Willeme, Wallys";
            lista += ", Xbasiralsanayei, XBehnam";
            lista += ", Yamaha, Yale, Yuna, Yugo, Yulon, Yarovit, Yorkshire";
            lista += ", Zimmer, Zyle Daewoo, Zotye, Zil, Zastava, Zolfe, Zenvo, Zender, Zwicky";

            return lista.ToUpper();
        }

        public static bool IsNameFabricaVeiculo(string fabrica)
        {
            if (string.IsNullOrWhiteSpace(fabrica))
                return false;

            try
            {
                if (Fabricantes().Contains(fabrica.ToUpper()))
                    return true;
                else
                    return false;

            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


    }
}
