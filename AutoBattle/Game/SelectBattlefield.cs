using AutoBattle.Core;
using AutoBattle.Model;
using System.Collections.Generic;

namespace AutoBattle.Game
{
    public class SelectBattlefield : IBehavior
    {
        public List<TextMessage> M_BattlefieldIntroductionMessages { get; set; }
        public List<PlayerInputMessage> M_GetPlayerBattlefieldChoiceMessages { get; set; }
        public string M_PlayerNameArg { get; set; }

        public Grid M_Grid;

        public SelectBattlefield()
        {

        }

        public SelectBattlefield(List<TextMessage> _battlefieldIntroductionMessages, List<PlayerInputMessage> _getPlayerBattlefieldChoiceMessages, string _playerNameArg)
        {
            M_BattlefieldIntroductionMessages = _battlefieldIntroductionMessages;
            M_GetPlayerBattlefieldChoiceMessages = _getPlayerBattlefieldChoiceMessages;
            M_PlayerNameArg = _playerNameArg;
        }

        public void Start()
        {
            //Get Battlefield Information, if no predifined BF is set, create a random one and jump this step
            if (GridSettings.Instance.PredefinedGridOptions != null)
            {
                PlayerMessageHandler.Instance.ShowMessageToPlayer(M_BattlefieldIntroductionMessages, true, M_PlayerNameArg);

                //We could pass the list without the method to not add the random value, this could be easily changed.
                M_Grid = new Grid(PlayerMessageHandler.Instance.GetMutipleChoiceInputFromPlayer<PredefinedGridOptions>(M_GetPlayerBattlefieldChoiceMessages, CreateGridOptionWithRandom(GridSettings.Instance.PredefinedGridOptions)));

                //Draw selected grid.
                PlayerMessageHandler.Instance.DrawBattlefield(M_Grid.M_Grids, M_Grid.M_xLenght);
            }
            else
            {
                //Random grid
                M_Grid = new Grid(GridSettings.Instance.CreateRandomGridOption());
            }
        }

        public void End()
        {
            //Cleans resources so GC can free memory space.
            M_BattlefieldIntroductionMessages = null;
            M_GetPlayerBattlefieldChoiceMessages = null;
            M_Grid = null;
            M_PlayerNameArg = string.Empty;
        }


        private List<PredefinedGridOptions> CreateGridOptionWithRandom(List<PredefinedGridOptions> _preExistingList)
        {
            List<PredefinedGridOptions> returnList = new List<PredefinedGridOptions>();
            returnList.AddRange(_preExistingList);

            //Add random in last for the player to choose from.
            returnList.Add(GridSettings.Instance.CreateRandomGridOption());

            return returnList;
        }
    }
}
