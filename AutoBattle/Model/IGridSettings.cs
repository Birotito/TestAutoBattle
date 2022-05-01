using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface IGridSettings : ISettings
    {
        int MinYSize { get; set; }
        int MaxYSize { get; set; }
        int MinXSize { get; set; }
        int MaxXSize { get; set; }
        List<PredefinedGridOptions> PredefinedGridOptions { get; set; }

    }
}
