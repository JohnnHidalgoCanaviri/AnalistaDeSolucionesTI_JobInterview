using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Book
    {
        public Abbrev abbrev { get; set; }
        public string author { get; set; }
        public long chapters { get; set; }
        public string group { get; set; }
        public string name { get; set; }
        public Testament testament { get; set; }
    }

    public enum Testament { Nt, Vt };
}
