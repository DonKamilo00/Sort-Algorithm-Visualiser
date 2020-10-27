using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort_Algorithm_VIsualiser
{
    public partial class Form1 : Form
    {
        //Array variable
        int[] TheArray;
        //Displaying current state on screen
        Graphics g;


        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Closing the software
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();  //Creating graphic object on panel
            int NumEntries = panel1.Width; //Changing number of integers to sort based on width of the panel
            int MaxVal = panel1.Height;    //Changing number of integers to sort based on height of the panel
            TheArray = new int[NumEntries]; //Creating array based on amount of entries 
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, NumEntries, MaxVal); //Initialising colour 
                                                                                                                  //of background to black
            Random rand = new Random(); // Random number generator

            for (int i = 0; i < NumEntries; i++)
            {
                TheArray[i] = rand.Next(0, MaxVal); // Initialising each member of array which is a random number between 0 and MaxVal
            }
            for (int i = 0; i < NumEntries; i++)
            {

                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - TheArray[i], 1, MaxVal); // Drawing 
                                                                                                                                //the Bars

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }
    }
}
