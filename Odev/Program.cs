using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Odev
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Atın(KG/TL)       Gümüş(KG/TL)    Platin(KG/TL)      Paladyum(KG/TL)");
            int sayac=0;
        A:
            if (sayac==10)
            {
                Console.Clear();
                Console.WriteLine("Altın(KG/TL)        Gümüş(KG/TL)        Platin(KG/TL)       Paladyum(KG/TL) ");
                sayac = 0;
              
            }
            List<Deger> list = new List<Deger>();
            XDocument xDocument = XDocument.Load("https://www.borsaistanbul.com/datfile/kmtpkpnsxml");
            list = xDocument.Descendants("TL").Select(o => new Deger
            {
                Altin = (string)o.Element("altindeger"),
                Gumus = (string)o.Element("gumusdeger"),
                Platin = (string)o.Element("platindeger"),
                Paladyum = (string)o.Element("paladyumdeger")

            }).ToList();


            Console.Write((list[0].Altin) + "         " + (list[0].Gumus) + "         " + (list[0].Platin) + "         " + (list[0].Paladyum) +  "  ===>  " + DateTime.Now + "  Güncellendi.\n");

            TextWriter Writer = new StreamWriter("MetalFiyat.text");
            Writer.WriteLine("Altın(KG/TL)        Gümüş(KG/TL)      Platin(KG/TL)       Paladyum(KG/TL)  ");
            Writer.WriteLine((list[0].Altin) + "          " + (list[0].Gumus) + "          " + (list[0].Platin) + "          " + (list[0].Paladyum) + "    ===>    " + DateTime.Now + "  Güncellendi.");
            Writer.Close();
            Thread.Sleep(60000);
            sayac = 1 + sayac;
                goto A;
            
           
        }
        

    }


    class Deger
    {
        public string Altin { get; set; }
        public string Gumus { get; set; }
        public string Platin { get; set; }
        public string Paladyum { get; set; }
    }
}
