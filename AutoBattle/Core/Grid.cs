using System;
using System.Collections.Generic;
using static AutoBattle.Types;
using AutoBattle.Model;

namespace AutoBattle.Core
{
    public class Grid : IGrid
    {
        public GridBox[] M_Grids { get; set; }
        public int M_xLenght { get; set; }
        public int M_yLength { get; set; }

        public Grid(PredefinedGridOptions _GridOptions)
        {
            this.M_xLenght = _GridOptions.XSize;
            this.M_yLength = _GridOptions.YSize;

            PopulateGridBox();

#if DEBUG
            Console.WriteLine("The battle field has been created\n");
#endif
        }

        public Grid(int _Lines, int _Columns)
        {
            this.M_xLenght = _Lines;
            this.M_yLength = _Columns;

#if DEBUG
            Console.WriteLine("The battle field has been created\n");
#endif

            PopulateGridBox();
        }

        private void PopulateGridBox()
        {
            int index = 0;
            M_Grids = new GridBox[this.M_xLenght * this.M_yLength];

            //Line
            for (int j = 0; j < this.M_yLength; j++)
            {
                //Column
                for (int i = 0; i < this.M_xLenght; i++)
                {
                    this.M_Grids[index] = new GridBox(i, j);
                    index++;
                }
            }
        }
    }

}
