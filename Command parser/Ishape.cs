using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_parser
{
    interface Ishape
    {
 
        void draw(Graphics g);

        void set(params int[] list);
    }
}
