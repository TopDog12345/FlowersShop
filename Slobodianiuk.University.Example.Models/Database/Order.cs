using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slobodianiuk.University.Example.Models.Database
{
    public class Order:DbItem
    {
        public int FlowerId { get; set; }
        public virtual Flower Flower { get; set; }
        public string UserId { get; set; }
        public DateTime date { get; set; }
    }
}
