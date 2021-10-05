using AIC.Tools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIC.Tools.Domain.DTO
{
    public class AxieDetailDTO
    {
        public int axieId1 { get; set; }
        public int axieId2 { get; set; }
        public int axieId3 { get; set; }
        public List<AxieDetail> AxiesDetails { get; set; }
    }
}