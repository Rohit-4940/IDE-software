using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_parser
{
 class Factory : Creator
    {
        public override Ishape getShape(string shapeType)
        {


            shapeType = shapeType.ToLower().Trim();
            if (shapeType.Equals("line"))
            {
                return new Line();
            }
            else if (shapeType.Equals("rectangle"))
            {
                return new Rectangle();
            }
            else if (shapeType.Equals("circle"))
            {
                return new Circle();
            }
            else if (shapeType.Equals("triangle"))
            {
                return new Triangle();
            }
            else
            {
                //Exception Handling
                System.ArgumentException argEx = new System.ArgumentException("Factory error: " + shapeType + " does not exist");
                throw argEx;
            }
        }
    }
}

