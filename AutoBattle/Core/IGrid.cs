using AutoBattle.Model;
using System.Collections.Generic;

namespace AutoBattle.Core
{
    public interface IGrid
    {
        GridBox[] M_Grids { get; set; }
        sbyte M_xLenght { get; set; }
        sbyte M_yLength { get; set; }
    }
}
