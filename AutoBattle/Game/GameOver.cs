using AutoBattle.Characters;
using AutoBattle.Core;
using AutoBattle.Model;

namespace AutoBattle.Game
{
    class GameOver : IBehavior
    {
        private TextLoader<GameOverText> M_TextLoader { get; set; }

        private Character M_CharacterKilled { get; set; }

        public GameOver(Character _characterKilled)
        {
            M_CharacterKilled = _characterKilled;
            M_TextLoader = new TextLoader<GameOverText>();
        }

        public void Start()
        {
            if (M_CharacterKilled.M_isPlayerCharacter)
            {
                //Show the result of the game;
                PlayerMessageHandler.Instance.ShowMessageToPlayer(M_TextLoader.Messages.PlayerWin, true);
            }
            else
            {
                //Show the result of the game;
                PlayerMessageHandler.Instance.ShowMessageToPlayer(M_TextLoader.Messages.EnemyWin, true);
            }

            //Play Again message.
            //PlayerMessageHandler.Instance.ShowMessageToPlayer(M_TextLoader.Messages.PlayAgain, true);

        }

        public void End()
        {
            M_TextLoader = null;
            M_CharacterKilled = null;
        }

    }
}
