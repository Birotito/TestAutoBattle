using AutoBattle.Core;
using AutoBattle.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Game
{
    class GetPlayerName : IBehavior
    {
        public string M_PlayerName { get; set; }
        public List<TextMessage> M_IntroductionMessage { get; set; }
        public List<PlayerInputMessage> M_GetPlayerNameMessage { get; set; }


        public GetPlayerName()
        {

        }

        public GetPlayerName(List<TextMessage> _IntroductionMessage, List<PlayerInputMessage> _GetPlayerNameMessage)
        {
            M_IntroductionMessage = _IntroductionMessage;
            M_GetPlayerNameMessage = _GetPlayerNameMessage;
        }

        public void Start()
        {
            //First we show to the player the introduction text.
            PlayerMessageHandler.Instance.ShowMessageToPlayer(M_IntroductionMessage);

            //After that we need to get the player name
            M_PlayerName = PlayerMessageHandler.Instance.GetInputFromPlayer(M_GetPlayerNameMessage);
        }

        public void End()
        {
            //Cleans resources so GC can free memory space.
            M_IntroductionMessage = null;
            M_GetPlayerNameMessage = null;
            M_PlayerName = string.Empty;
        }
    }
}
