using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slobodianiuk.University.Example.Models.Database
{
    public class Flower : DbItem
    {
        public string? Name { get; set; }
        public int? price { get; set; }
    }
}
