using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    class Thing
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int HouseholdId { get; set; }
        public bool Show { get; set; }
        public bool Needed { get; set; }
        public float DefaultPrice { get; set; }
    }
}
