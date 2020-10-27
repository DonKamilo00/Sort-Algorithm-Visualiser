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



        void NextStep();
        bool isSorted(); 

        void ReDraw(); //used to pause and resume or refresh the graphic object 


    }
}
