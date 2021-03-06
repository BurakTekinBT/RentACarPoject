using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarDetailDto:IDto
    {
        public string Description { get; set; }
        public string BrandName { get; set; }

        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
