using System;
using AutoBattle.Model;

namespace AutoBattle.Core
{
    public class Grid : IGrid
    {
        public GridBox[] M_Grids { get; set; }
        public sbyte M_xLenght { get; set; }
        public sbyte M_yLength { get; set; }

        public Grid(PredefinedGridOptions _GridOptions)
        {
            this.M_xLenght = Convert.ToSByte(_GridOptions.XSize);
            this.M_yLength = Convert.ToSByte(_GridOptions.YSize);

            PopulateGridBox();

#if DEBUG
            Console.WriteLine("The battle field has been created\n");
#endif
        }

        public Grid(sbyte _Lines, sbyte _Columns)
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
            sbyte index = 0;
            M_Grids = new GridBox[this.M_xLenght * this.M_yLength];

            //Line
            for (sbyte j = 0; j < this.M_yLength; j++)
            {
                //Column
                for (sbyte i = 0; i < this.M_xLenght; i++)
                {
                    this.M_Grids[index] = new GridBox(i, j);
                    index++;
                }
            }
        }
    }

}
