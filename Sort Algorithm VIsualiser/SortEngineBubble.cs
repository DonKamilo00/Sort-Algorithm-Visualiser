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

                _sorted = IsSorted();

            }
        }

        private bool IsSorted()
        {
            throw new NotImplementedException();
        }
    }
    }
}
