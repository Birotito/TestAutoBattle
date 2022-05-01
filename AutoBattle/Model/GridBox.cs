using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public struct GridBox : IGridBox
    {
        public int xIndex {get; set;}
        public int yIndex { get; set; }
        public bool ocupied { get; set; }

        public GridBox(int x, int y, bool ocupied = false)
        {
            this.xIndex = x;
            this.yIndex = y;
            this.ocupied = ocupied;
        }

    }
}
