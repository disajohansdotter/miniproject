using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miniproject.Models
{
    public class correctText
    {
        [Key]
        public int correctTextID { get; set; }

        public string cText { get; set; }

        public string punctuation { get; set; }
    }
}