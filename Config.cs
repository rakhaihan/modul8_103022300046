using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul8_103022300046
{
    class Config
    {
        //atribut untuk deserialisasi
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public string[] methods { get; set; }
        public Confirmation confirmation { get; set; }

        //konstruktor kosong untuk deserialisasi
        public Config() { }

        public Config(string lang, Transfer transfer, string[] methods, Confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }

        //class Transfer untuk transfer
        public class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }

        //class Confirmation untuk confirmation
        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }
        }
    }
}
