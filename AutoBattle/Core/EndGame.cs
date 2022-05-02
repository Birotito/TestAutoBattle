using AutoBattle.Game;
using AutoBattle.Model;

namespace AutoBattle.Core
{
    class EndGame : IBehavior
    {
        private TextLoader<GameOverText> M_TextLoader { get; set; }
        public void Start()
        {
            M_TextLoader = new TextLoader<GameOverText>();
             
            PlayerMessageHandler.Instance.ShowMessageToPlayer(M_TextLoader.Messages.EndGreetings, true);
        }

        public void End()
        {
            M_TextLoader = null;
        }
    }
}
