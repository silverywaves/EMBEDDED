namespace INIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ¹öÆ°1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Btn1 Clicked.. sender : " + sender);
            Console.WriteLine("Btn1 Clicked.. e : " + e);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Btn2 Clicked.. sender : " + sender);
            Console.WriteLine("Btn2 Clicked.. e : " + e);
        }
    }
}
