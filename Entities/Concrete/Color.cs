using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Color:IEntity
    {

        public int colorId { get; set; }

        public int colorName { get; set; }
    }
}
