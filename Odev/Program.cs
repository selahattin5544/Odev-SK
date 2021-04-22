using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Odev
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Deger> list = new List<Deger>();
            XDocument xDocument = XDocument.Load("https://www.borsaistanbul.com/datfile/kmtpkpnsxml");
            list = xDocument.Descendants("TL").Select(o => new Deger
            {
                Altin = (string)o.Element("altindeger"),
                Gumus = (string)o.Element("gumusdeger"),
                Platin = (string)o.Element("platindeger"),
                Paladyum = (string)o.Element("paladyumdeger")

            }).ToList();
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
