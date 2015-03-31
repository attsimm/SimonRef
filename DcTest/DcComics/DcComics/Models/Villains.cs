using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DcComics.Models
{
    public class Villains
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Publish { get; set; }

        public virtual ICollection<Comics> Comics { get; set; }
        public virtual Superheroes Nemesis { get; set; }
    }
}