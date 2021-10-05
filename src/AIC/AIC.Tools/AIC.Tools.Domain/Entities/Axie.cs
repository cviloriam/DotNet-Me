using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIC.Tools.Domain.Entities
{
    public class Axie
    {
        public string id { get; set; }
        public string image { get; set; }

        private string @class { get; set; }
        public string Class { get => @class; set => @class = value; }

        public Stats stats { get; set; }
        public List<Part> parts { get; set; }
    }
}