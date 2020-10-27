using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;



namespace Sort_Algorithm_VIsualiser
{
    public partial class Form1 : MetroForm
    {
        //Array variable
        int[] TheArray;
        //Displaying current state on screen
        Graphics g;
        BackgroundWorker bgv = null; // entity that is going to run the code on a different thread
        bool Paused = false;


        public Form1()
        {
            InitializeComponent();
            PopulateDropdown();
        }

        private void PopulateDropdown()
        {
            List<string> ClassList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()) // going through AppDomain to 
                                                            //get the assemblies which are implementations of the iSortEngine interface. 
                .Where(x => typeof(iSortEngine).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract) // excluding the interface it 
                                                                                                        //self and any abstract classes 
                .Select(x => x.Name).ToList(); //getting name of candidates and casting as a list and putting in variable 

            ClassList.Sort(); // sorting alfabeticly 
            foreach (string entry in ClassList) // populating the dropdown list with name of candidates 
            {

                comboBox1.Items.Add(entry); // for each entry add it to dropdown

            }
            comboBox1.SelectedIndex = 0; // setting the index to first entry in it
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Closing the software
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            bgv = new BackgroundWorker();       //creating new background worker and making sure that user can cancel it
            bgv.WorkerSupportsCancellation = true;
            bgv.DoWork += new DoWorkEventHandler(bgv_DoWork);
            bgv.RunWorkerAsync(argument: comboBox1.SelectedItem); // running bg worker and passing value selected in dropdown
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            if(!Paused)
            {
                bgv.CancelAsync();
                Paused = true;
            }
            else
            {
                int NumEntries = panel1.Width;
                int maxVal = panel1.Height;
                Paused = false;
                for (int i = 0; i < NumEntries; i++)
                {
                    g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), i, 0, i, maxVal);
                    g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, maxVal - TheArray[i], i, maxVal);

                }
                bgv.RunWorkerAsync(argument: comboBox1.SelectedItem);
            }
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

        #region BackGroundStuff

        public void bgv_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            BackgroundWorker bw = sender as BackgroundWorker;
            string SortEngineName = (string)e.Argument;
            Type type = Type.GetType("Sort_Algorithm_VIsualiser." + SortEngineName);
            var ctors = type.GetConstructors();
            try
            {
                iSortEngine se = (iSortEngine)ctors[0].Invoke(new object[] { TheArray, g, panel1.Height });
                while (!se.isSorted() && (!bgv.CancellationPending))
                {
                    se.NextStep();
                }
            }
            catch (Exception ex)
            {
            }
        }





        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
