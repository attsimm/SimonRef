namespace DcComics
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comics
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int Rating { get; set; }

        public DateTime Publish { get; set; }

        public string Image { get; set; }

        public int? Superheroes_ID { get; set; }

        public int? Villains_ID { get; set; }

        public virtual Superheroes Superheroes { get; set; }

        public virtual Villains Villains { get; set; }
    }
}
