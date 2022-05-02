using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public struct GridBox : IGridBox
    {
        public sbyte xIndex {get; set;}
        public sbyte yIndex { get; set; }
        public bool ocupied { get; set; }

        public GridBox(sbyte _x, sbyte _y, bool _ocupied = false)
        {
            this.xIndex = _x;
            this.yIndex = _y;
            this.ocupied = _ocupied;
        }

    }
}
