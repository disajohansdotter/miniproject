using Miniproject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Miniproject.DataAccess
{
    public class MPContext : DbContext
    {

        public DbSet<clickColor> clickColors { get; set;}
        public DbSet<correctText> correctTexts { get; set; }
        public DbSet<namePicture> namePictures { get; set; }
        public DbSet<sentenceBuild> sentenceBuilds { get; set; }
        public DbSet<TrophyRoom> Trophyrooms { get; set; }

        //Not Mapped
        public DbSet<challengeStep> challengeSteps { get; set; }

        public MPContext() : base("Miniproject") { }

    }

}