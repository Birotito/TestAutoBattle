using AutoBattle.Model;
using System.Collections.Generic;

namespace AutoBattle.Core
{
    public interface IGrid
    {
        public GridBox[] M_Grids { get; set; }
        public int M_xLenght { get; set; }
        public int M_yLength { get; set; }
    }
}
