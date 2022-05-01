using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public struct PredefinedGridOptions : IPredefinedGridOptions
    {
        /// <summary>
        /// Constructor of a new Prefefined Grid
        /// </summary>
        /// <param name="Name">Name to be exhibit to the player</param>
        /// <param name="YSize">Y size of the grid</param>
        /// <param name="XSize">X size of the grid</param>
        public PredefinedGridOptions(String Name, int YSize, int XSize)
        {
            this.Name = Name;
            this.YSize = YSize;
            this.XSize = XSize;
        }

        public String Name { get; set; }
        public int YSize { get; set; }
        public int XSize { get; set; }
       
    }
}
