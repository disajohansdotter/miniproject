using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Miniproject.Models
{
    public class clickColor
    {
        [Key]
        public int clickColorID { get; set; }

        public string color { get; set; }

        public string colorWord { get; set; }

    }
}