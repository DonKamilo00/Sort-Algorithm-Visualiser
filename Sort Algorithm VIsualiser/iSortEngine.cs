using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Algorithm_VIsualiser
{
    interface iSortEngine
    {
        void DoWork(int[] TheArray, Graphics g, int MaxVal); // method which takes the integer , array , graphic object and highest value
                                                                                                                            //thats allowed

    }
}
