using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDatabaseModels
{
    public class Food : Product
    {
        public int calories { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
