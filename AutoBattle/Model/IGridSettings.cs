using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface IGridSettings : ISettings
    {
        sbyte MinYSize { get; set; }
        sbyte MaxYSize { get; set; }
        sbyte MinXSize { get; set; }
        sbyte MaxXSize { get; set; }
        string RandomGridName { get; set; }
        List<PredefinedGridOptions> PredefinedGridOptions { get; set; }

    }
}
