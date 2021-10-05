using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIC.Tools.Domain.Entities
{
    public class Part
    {
        public string id { get; set; }
        public string name { get; set; }
        public string @class { get; set; }
        public string type { get; set; }
        public object specialGenes { get; set; }
        public int stage { get; set; }
        public List<Ability> abilities { get; set; }
    }
}