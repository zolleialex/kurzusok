using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Kurzusok.Models
{
    public partial class Positions
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public int Hoursperweek { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public ICollection<Teachers> Teachers { get; set; }
    }
}
