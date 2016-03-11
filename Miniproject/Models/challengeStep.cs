using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Miniproject.Models
{
    [NotMapped]
    public class challengeStep
    {
        [NotMapped]
        public int challengeType { get; set; }
        [NotMapped]
        public int currentStep { get; set; }
        [NotMapped]
        public int score { get; set; }
    }
}