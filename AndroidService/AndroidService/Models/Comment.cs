using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AndroidService.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Tekst { get; set; }
        public string Op { get; set; }
        [ForeignKey("Meme")]
        public int MemeID { get; set; }
        [JsonIgnore]
        public virtual Meme Meme { get; set; }
    }
}