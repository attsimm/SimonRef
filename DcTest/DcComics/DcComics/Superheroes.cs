namespace DcComics
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Superheroes
    {
        public Superheroes()
        {
            Comics = new HashSet<Comics>();
            Villains = new HashSet<Villains>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Power { get; set; }

        public DateTime Creation { get; set; }

        public virtual ICollection<Comics> Comics { get; set; }

        public virtual ICollection<Villains> Villains { get; set; }
    }
}
