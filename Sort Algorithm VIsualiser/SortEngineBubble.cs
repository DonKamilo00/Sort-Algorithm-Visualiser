using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Algorithm_VIsualiser
{
    class SortEngineBubble : iSortEngine
    {
        private bool _sorted = false; // tells whenever array is sorted or not 
        private int[] TheArray; //copy of the array 
        private Graphics g; // graphics object
        private int MaxVal; // max value
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White); //drawing white rectangles 
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black); //drawing black rectangles



        public void DoWork(int[] TheArray_In, Graphics g_In, int MaxVal_In) // giving local name to variables 
        {
            TheArray = TheArray_In;
            g = g_In;
            MaxVal = MaxVal_In;

            while (!_sorted) // loop for array until its sorted 
            {

                for (int i = 0; i < TheArray.Count() - 1; i++) // comparing each element to one after it
                {
                    if(TheArray[i] > TheArray[i + 1]) // if array element at current index is greater than the one adjecent to it , 
                                                                                                            //then swap their values 
                    {
                        Swap(i, i + 1);

                    }

                }



                _sorted = IsSorted(); // checks if it needs to continue 

            }
        }

        private void Swap(int i, int p)
        {
            int temp = TheArray[i];
            TheArray[i] = TheArray[i + 1];          // those 3 lines of code swap the values 
            TheArray[i + 1] = temp;

            g.FillRectangle(BlackBrush, i, 0, 1, MaxVal);  // removing old values from display and showing black background behind it 
            g.FillRectangle(BlackBrush, p, 0, 1, MaxVal);

            g.FillRectangle(WhiteBrush, i, MaxVal - TheArray[i], 1, MaxVal); // showing new values 
            g.FillRectangle(WhiteBrush, p, MaxVal - TheArray[p], 1, MaxVal);
        }

        private bool IsSorted()
        {
            for (int i =0; i < TheArray.Count() - 1; i++)
            {

                if (TheArray[i] > TheArray[i + 1]) return false; // finding if element in array is adjecent if so returning false

            }
            return true;
        }
    }
}

