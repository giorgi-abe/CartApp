using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ApplicationDatabaseModels
{
    public class User : IdentityUser<string>
    {
        public int Money { get; set; }
        public List<Product> Cart { get; set; }
        public string Address { get; set; }
    }
}
