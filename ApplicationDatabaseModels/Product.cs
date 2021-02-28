using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDatabaseModels
{
    public abstract class Product
    {
        [Key]
        public int Id { get; set; }
        public int Cost { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Firm { get; set; }
        public List<User> UsersCart { get; set; }
    }
}
