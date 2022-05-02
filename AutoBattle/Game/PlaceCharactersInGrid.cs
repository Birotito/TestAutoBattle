using AutoBattle.Characters;
using AutoBattle.Core;
using AutoBattle.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoBattle.Game
{
    /// <summary>
    /// Places all or selected characters somewhere in the Grid. 
    /// </summary>
    class PlaceCharactersInGrid : IBehavior
    {
        private Grid M_Grid { get; set; }
        private List<Character> M_CharactersToPlace { get; set; }

        private List<GridBox> M_AvailablePlaces;
        public PlaceCharactersInGrid(Grid _Grid, List<Character> _CharactersToPlace)
        {
            M_Grid = _Grid;
            M_CharactersToPlace = _CharactersToPlace;
        }


        public void Start()
        {
            //We can only place something if the Grid Box is free, the class cannot assume everything will be empty since it should not care when is called.
            FindAvailablePlaces();

            //Find the information and change it.
            if (M_AvailablePlaces.Count > 0)
            {
                foreach (var character in M_CharactersToPlace)
                {
                    GridBox newPlace = M_AvailablePlaces[Core.Random.Instance.Next((short)(M_AvailablePlaces.Count - 1))];
                    int NewPlaceIndex = Array.IndexOf(M_Grid.M_Grids, M_Grid.M_Grids.SingleOrDefault(x => x.yIndex == newPlace.yIndex && x.xIndex == newPlace.xIndex));

                    M_Grid.M_Grids[NewPlaceIndex].OccupyBox();
                    character.SetCharacterPlaceInGrid((short)NewPlaceIndex);
                    M_AvailablePlaces.Remove(newPlace);
                }
            }
        }

        public void End()
        {
            //Cleans resources so GC can free memory space.
            M_CharactersToPlace = null;
            M_Grid = null;
        }

        private void FindAvailablePlaces() => M_AvailablePlaces = M_Grid.M_Grids.Where(x => !x.occupied).ToList();

        #region Return Private Fields Methods
        public Grid GetGrid() => M_Grid;

        //TODO: Right now we only have 2 characters, and we now that we pass them in this order, but in the future find a way to differentiate each team
        public Character GetPlayerCharcter() => M_CharactersToPlace.SingleOrDefault(x => x.M_isPlayerCharacter);

        public Character GetEnemmyCharcter() => M_CharactersToPlace.SingleOrDefault(x => !x.M_isPlayerCharacter);
        #endregion
    }
}

