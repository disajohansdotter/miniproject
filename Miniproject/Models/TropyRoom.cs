using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Miniproject.Models
{
    public class TrophyRoom
    {
        [Key]
        public int trophyRoomID { get; set; }

        public string challengeType { get; set; }

        public string user { get; set; }

        public int challengePoints { get; set; }
 
    }
}