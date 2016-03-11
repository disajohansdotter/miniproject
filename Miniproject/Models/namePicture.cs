using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miniproject.Models
{
    public class namePicture
    {
        [Key]
        public int pictureID { get; set; }

        public UrlAttribute url { get; set; }

        public string pictureWord { get; set; }
    }
}