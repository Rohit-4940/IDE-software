using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_parser
{
   abstract class Creator
    {
        public abstract Ishape getShape(string ShapeType);
    }
}
