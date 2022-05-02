using System.Collections.Generic;

namespace AutoBattle.Model
{
    public class GameOverText : IGameOverText<TextMessage, PlayerInputMessage>
    {
        public List<TextMessage> PlayerWin { get; set; }
        public List<TextMessage> EnemyWin { get; set; }
        public List<PlayerInputMessage> PlayAgain { get; set; }
        public List<TextMessage> EndGreetings { get; set; } //TODO: change to be multiple options

    }
}

