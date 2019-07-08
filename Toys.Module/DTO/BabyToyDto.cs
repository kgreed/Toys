using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toys.Module.BusinessObjects;

namespace Toys.Module.DTO
{
    public class BabyToyDto
    {
        public BabyToyDto(BabyToy babyToy)
        {
            HelpsTeething = babyToy.HelpsTeething;
            GoodForCrawling = babyToy.GoodForCrawling;
        }

        public bool HelpsTeething { get; set; }
        public bool GoodForCrawling { get; set; }
    }
}
