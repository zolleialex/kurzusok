using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Kurzusok.ViewModels
{
    public class RolesViewModel
    {
        public string roleId { get; set; }
        public string roleName { get; set; }
        public List<String> Users{ get; set; }
    }
}
