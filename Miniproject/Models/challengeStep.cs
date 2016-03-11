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
        public int challengeType { get; set; }
        public int currentStep { get; set; }
        public int score { get; set; }
    }
}