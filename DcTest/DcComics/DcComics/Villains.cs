namespace DcComics
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Villains
    {
        public Villains()
        {
            Comics = new HashSet<Comics>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime Publish { get; set; }

        public int? Nemesis_ID { get; set; }

        public virtual ICollection<Comics> Comics { get; set; }

        public virtual Superheroes Superheroes { get; set; }
    }
}
