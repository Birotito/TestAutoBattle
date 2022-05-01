using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public class PredefinedGridOptions : IPredefinedGridOptions
    {
        public String Name { get; set; }
        public int YSize { get; set; }
        public int XSize { get; set; }
    }
}
