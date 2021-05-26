using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Command_parser
{
    public partial class Form1 : Form
    {
        Creator factory = new Factory();
        Pen myPen = new Pen(Color.Black);
        int x = 0, y = 0, width, height, radius, repeatval;



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed by Rohit Chapagain copy right 2002");
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();

            string command = textBox1.Text.ToLower();
            string[] commandline = command.Split(new String[] { "\n" },
                StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < commandline.Length; k++)
            {

                string[] cmd = commandline[k].Split(' ');
                if (textBox2.Text.Equals("run") == true)
                {


                    if (textBox1.Text.Equals("clear") == true)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";

                    }
                    else if (textBox1.Text.Equals("exit") == true)
                    {
                        this.Close();
                    }
                    else if (textBox1.Text.Equals("reset") == true)
                    {
                        x = 0;
                        y = 0;
                        width = 0;
                        height = 0;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        panel1.Refresh();
                    }
                    else if (cmd[0].Equals("moveto") == true)
                    {
                        panel1.Refresh();
                        string[] param = cmd[1].Split(',');
                        if (param.Length != 2)
                        { MessageBox.Show("Please input the value as --> moveto 100,200 "); }
                        else
                        {
                            Int32.TryParse(param[0], out x);
                            Int32.TryParse(param[1], out y);
                            moveTo(x, y);
                        }

                    }

                    else if (cmd[0].Equals("width") == true)
                    {
                        int w;
                        if (cmd[1].Equals("=") == true)
                        {
                            Int32.TryParse(cmd[2], out width);
                        }
                        else if (cmd[1].Equals("+") == true)
                        {
                            Int32.TryParse(cmd[2], out w);
                            width = width + w;
                        }
                        else if (cmd[1].Equals("-") == true)
                        {
                            for (int rc = 0; rc < repeatval; rc++)
                            {
                                Int32.TryParse(cmd[2], out w);
                                width = width - w;
                            }
                        }

                        else
                        {
                            MessageBox.Show("Syntax Error");
                        }
                    }
                    else if (cmd[0].Equals("height") == true)
                    {
                        int h;
                        if (cmd[1].Equals("=") == true)
                        {
                            Int32.TryParse(cmd[2], out height);
                        }
                        else if (cmd[1].Equals("+") == true)
                        {
                            Int32.TryParse(cmd[2], out h);
                            height = height + h;
                        }
                        else if (cmd[1].Equals("-") == true)
                        {
                            for (int rc = 0; rc < repeatval; rc++)
                            {
                                Int32.TryParse(cmd[2], out h);
                                height = height - h;

                            }
                        }
                        else
                        {
                            MessageBox.Show("Syntax Error");
                        }
                    }

                    else if (cmd[0].Equals("drawTo") == true)
                    {
                        string[] param = cmd[1].Split(',');
                        int x = 0, y = 0;
                        if (param.Length != 2)
                        {
                            MessageBox.Show("Incorrect Parameter");
                        }
                        else
                        {
                            Int32.TryParse(param[0], out x);
                            Int32.TryParse(param[1], out y);
                            drawTo(x, y);
                        }
                    }

                    else if (cmd[0].Equals("drawline") == true)
                    {
                        string[] param = cmd[1].Split(',');
                        int toX = 0, toY = 0;
                        if (param.Length != 2)
                        {
                            MessageBox.Show("Incorrect parameter please use both width and height");
                        }
                        else
                        {
                            Int32.TryParse(param[0], out toX);
                            Int32.TryParse(param[1], out toY);
                            Ishape line = factory.getShape("line");
                            line.set(x, y, toX, toY);
                            line.draw(g);
                        }

                    }
                    else if (cmd[0].Equals("circle") == true)
                    {
                        if (cmd.Length != 2) { MessageBox.Show("Incorrect parameter"); }

                        {
                            if (cmd[1].Equals("radius") == true)
                            {
                                Ishape circle = factory.getShape("circle");
                                Circle c = new Circle();
                                c.set(x, y, radius);
                                c.draw(g);
                            }
                            else
                            {
                                Int32.TryParse(cmd[1], out radius);
                                Ishape circle = factory.getShape("circle");
                                Circle c = new Circle();
                                c.set(x, y, radius);
                                c.draw(g);
                            }
                        }
                    }

                    else if (cmd[0].Equals("rectangle") == true)
                    {
                        if (cmd.Length != 2)
                        {
                            MessageBox.Show("Incorrect Parameter, give input as: rectangle 100,200");
                        }
                        else
                        {
                            string[] param = cmd[1].Split(',');
                            if (param.Length != 2)
                            {
                                MessageBox.Show("Invalid Parameter, please use only 2 parameter");
                            }
                            else
                            {
                                Int32.TryParse(param[0], out width);
                                Int32.TryParse(param[1], out height);
                                Ishape circle = factory.getShape("rectangle");
                                Rectangle r = new Rectangle();
                                r.set(x, y, width, height);
                                r.draw(g);
                            }
                        }
                    }

                    else if (cmd[0].Equals("triangle") == true)
                    {
                        string[] param = cmd[1].Split(',');
                        if (param.Length != 3)
                        {
                            MessageBox.Show("Incorrect Parameter");

                        }
                        else
                        {
                            Int32.TryParse(param[0], out width);
                            Int32.TryParse(param[1], out height);
                            Ishape circle = factory.getShape("triangle");
                            Triangle r = new Triangle();
                            r.set(x, y, width, height);
                            r.draw(g);
                        }
                    }

                    else if (!cmd[0].Equals(null))
                    {
                        int errorLine = k + 1;
                        MessageBox.Show("Invalid syntax found on line " + errorLine, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Type 'run'  command to get the output", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        public void moveTo(int toX, int toY)
        { x = toX; y = toY; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        public void drawTo(int toX, int toY)
        { x = toX; y = toY; }

    }
}
    