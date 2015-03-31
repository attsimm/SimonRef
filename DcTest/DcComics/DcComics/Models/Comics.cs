using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DcComics.Models
{
    public class Comics
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public DateTime Publish { get; set; }
        public string Image { get; set; }
    }
}