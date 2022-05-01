using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface IGridBox
    {
        int xIndex { get; set; }
        int yIndex { get; set; }
        bool ocupied { get; set; }
    }
}
