using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Game
{
    public interface ITurn : IBehavior
    {
        bool DoTurn();
    }
}
