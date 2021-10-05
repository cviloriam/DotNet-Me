using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIC.Tools.Domain.Entities
{
    public class Ability
    {
        public string id { get; set; }
        public string name { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int energy { get; set; }
        public string description { get; set; }
        public string backgroundUrl { get; set; }
        public string effectIconUrl { get; set; }
    }
}