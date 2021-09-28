using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kurzusok.Models
{
    public partial class Szakok
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Tagozat { get; set; }
        public string Szint { get; set; }
    }
}
