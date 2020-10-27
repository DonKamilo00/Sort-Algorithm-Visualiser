using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace Sort_Algorithm_VIsualiser
{
    class SortEngineBubble : iSortEngine
    {
        private int[] TheArray; //copy of the array 
        private Graphics g; // graphics object
        private int MaxVal; // max value
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White); //drawing white rectangles 
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black); //drawing black rectangles

        public SortEngineBubble(int[] TheArray_In, Graphics g_In, int MaxVal_In)
        {
            TheArray = TheArray_In;
            g = g_In;
            MaxVal = MaxVal_In;


        }


        public void NextStep() // giving local name to variables 
        {
         


            

            for (int i = 0; i < TheArray.Count() - 1; i++) // comparing each element to one after it
            {
                if(TheArray[i] > TheArray[i + 1]) // if array element at current index is greater than the one adjecent to it , 
                                                                                                        //then swap their values 
                {
                    Swap(i, i + 1);

                }

            }



               

            
        }

        private void Swap(int i, int p)
        {
            int temp = TheArray[i];
            TheArray[i] = TheArray[i + 1];          // those 3 lines of code swap the values 
            TheArray[i + 1] = temp;

            DrawBar(i, TheArray[i]);
            DrawBar(p, TheArray[p]);

        }

        private void DrawBar(int position, int height)
        {
            g.FillRectangle(BlackBrush, position, 0, 1, MaxVal);
            g.FillRectangle(WhiteBrush,position, MaxVal - TheArray[position], 1 , MaxVal);



        }



        public bool isSorted()
        {
            for (int i =0; i < TheArray.Count() - 1; i++)
            {

                if (TheArray[i] > TheArray[i + 1]) return false; // finding if element in array is adjecent if so returning false

            }
            return true;
        }


        public void ReDraw()
        {

            for(int i = 0; i < (TheArray.Count() - 1); i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - TheArray[i], 1, MaxVal);
            }




        }

       
    }
}

