using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndroidService.Models
{
    public class Meme
    {
        public int MemeID { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public string Categorie { get; set; }
        public string Afbeelding { get; set; }
        public string Op { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }



    }
}