using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface IPredefinedGridOptions
    {
        String Name { get; set; }
        int YSize { get; set; }
        int XSize { get; set; }
    }
}
