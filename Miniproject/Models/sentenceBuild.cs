using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miniproject.Models
{
    public class sentenceBuild
    {
        [Key]
        public int sentenceBuildID { get; set; }

        public string subject { get; set; }

        public string verb { get; set; }

        public string objekt { get; set; }

    }
}