using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_parser
{
    class Rectangle : Ishape
    {


        public int x, y, width, height;

        /// <summary>
        /// initializing the value of variables width and height 
        /// </summary>
        public Rectangle() : base()
        {
            width = 0;
            height = 0;
        }
        public Rectangle(int x, int y, int width, int height)
        {
            this.width = width;
            this.height = height;
        }
      
        public void draw(Graphics g)
        {
            try
            {
                Pen p = new Pen(Color.Black, 2);
                g.DrawRectangle(p, x - (width / 2), y - (height / 2), width * 2, height * 2);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void set(params int[] list)
        {
            try
            {
                this.x = list[0];
                this.y = list[1];
                this.width = list[2];
                this.height = list[3];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}


