using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DcComics.Models
{
    public class Superheroes
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Power { get; set; }
        public DateTime Creation { get; set; }

        public virtual ICollection<Comics> Comics { get; set; }
    }
}