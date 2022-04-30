using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface IGridSettings
    {
        int MinYSize { get; set; }
        int MaxYSize { get; set; }
        int MinXSize { get; set; }
        int MaxXSize { get; set; }

    }
}
