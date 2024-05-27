using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("BTN1 Clicked.. sender : " + sender);
            Console.WriteLine("BTN1 Clicked.. e : " + e);
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("BTN2 Clicked.. sender : " + sender);
            Console.WriteLine("BTN2 Clicked.. e : " + e);
        }
    }
}
