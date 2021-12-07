using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Kurzusok.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Subjects = new HashSet<Subjects>();
        }

        public int Id { get; set; }
        public string Date { get; set; }
        //[Required(ErrorMessage = "A kötelező!")]
        //[Range(1, 100, ErrorMessage = "Az oktató terheltsége csak 1 és 100 között egész érték lehet!")]
        public int Weeks { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public ICollection<Subjects> Subjects { get; set; }
    }
}
