using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoneshop.ConsoleApp
{
    public class Phone
    {
        public int ID { get; private set; }
        public string Merk { get; private set; }
        public string Type { get; private set; }
        public string Omschrijving { get; private set; }
        public double Prijs { get; private set; }

        static int count = 1;

        public Phone (string merk, string type, string omschrijving, double prijs)
        {
            this.ID = count;
            this.Merk = merk;
            this.Type = type;
            this.Omschrijving = omschrijving;
            this.Prijs = prijs;

            count++;
        }
    }
}