using AutoBattle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoBattle.Core
{
    /// <summary>
    /// Class responsible to show information to the player and also get inputs.
    /// </summary>
    public sealed class PlayerMessageHandler
    {
        /// <summary>
        /// Using Lazy<T> will make sure that the object is only instantiated when it is used somewhere in the calling code.
        /// </summary>
        private static readonly Lazy<PlayerMessageHandler> lazy = new Lazy<PlayerMessageHandler>(() => new PlayerMessageHandler());

        /// <summary>
        /// Instance for Singleton Pattern
        /// </summary>
        public static PlayerMessageHandler Instance { get { return lazy.Value; } }

        /// <summary>
        /// Show messages in the console from within a list
        /// </summary>
        /// <param name="_messages">List containing the messages to be displayed</param>
        public void ShowMessageToPlayer(List<TextMessage> _messages, bool _shouldCleanScreen = true)
        {
            //TODO: Instead of showing the full message right away would be nice to show letter by letter being written.

            //Reorder message list so we know for sure we are showing message in the intended order
            _messages.OrderBy(x => x.ExhibitionOrder);

            //Always clean the console before sending new messages.
            if (_shouldCleanScreen)
                Console.Clear();

            //Show each one of the messages in the list, we wait for the "center" of the player to before proceeding to the next one. using for instead of foreach for a little performance gain.
            for (int i = 0; i < _messages.Count; i++)
            {
                //Show message to the player in order.
                Console.WriteLine(_messages[i].Message + "\n");

                Console.WriteLine("Press Enter to continue");
                Console.ReadKey();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
            }
        }

        public void ShowMessageToPlayer(List<TextMessage> _messages, bool _shouldCleanScreen = true, params object[] _messageArguments)
        {
            //TODO: Instead of showing the full message right away would be nice to show letter by letter being written.

            //Reorder message list so we know for sure we are showing message in the intended order
            _messages.OrderBy(x => x.ExhibitionOrder);

            //Always clean the console before sending new messages.
            if (_shouldCleanScreen)
                Console.Clear();

            //Show each one of the messages in the list, we wait for the "center" of the player to before proceeding to the next one. using for instead of foreach for a little performance gain.
            for (int i = 0; i < _messages.Count; i++)
            {
                //Show message to the player in order.
                Console.WriteLine(String.Format(_messages[i].Message + "\n", _messageArguments));

                Console.WriteLine("Press Enter to continue");
                Console.ReadKey();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
            }
        }

        /// <summary>
        /// Show messages in the console from within a list and don't wait for it1s input
        /// </summary>
        /// <param name="_messages">List containing the messages to be displayed</param>
        public void ShowGameplayMessageToPlayer(List<TextMessage> _messages)
        {
            //Reorder message list so we know for sure we are showing message in the intended order
            _messages.OrderBy(x => x.ExhibitionOrder);

            
            //Show each one of the messages in the list, we wait for the "center" of the player to before proceeding to the next one. using for instead of foreach for a little performance gain.
            for (int i = 0; i < _messages.Count; i++)
            {
                //Show message to the player in order.
                Console.WriteLine(_messages[i].Message + "\n");
            }
        }

        public void ShowGameplayMessageToPlayer(List<TextMessage> _messages, params object[] _messageArguments)
        {
            //Reorder message list so we know for sure we are showing message in the intended order
            _messages.OrderBy(x => x.ExhibitionOrder);

            //Show each one of the messages in the list, we wait for the "center" of the player to before proceeding to the next one. using for instead of foreach for a little performance gain.
            for (int i = 0; i < _messages.Count; i++)
            {
                //Show message to the player in order.
                Console.WriteLine(String.Format(_messages[i].Message + "\n", _messageArguments));
            }
        }

        public string GetInputFromPlayer(List<PlayerInputMessage> _messages)
        {
            //TODO: Instead of showing the full message right away would be nice to show letter by letter being written.
            string returnInput = string.Empty;

            //Reorder message list so we know for sure we are showing message in the intended order
            _messages.OrderBy(x => x.ExhibitionOrder);

            //Clean the console before sending new messages.
            Console.Clear();

            while (string.IsNullOrEmpty(returnInput))
            {

                //Show message to the player before asking for the input. using for instead of foreach for a little performance gain.
                for (int i = 0; i < _messages.Count; i++)
                {
                    //Show message to the player in order.
                    Console.WriteLine(_messages[i].Message + "\n");
                }

                returnInput = Console.ReadLine();

                //If the input is not valid (such as pressing enter with blank input) show the input error message and goes to ask again the information to the player.
                if (string.IsNullOrEmpty(returnInput))
                {
                    Console.Clear();
                    Console.WriteLine(_messages[0].InvalidInput + "\n");
                }
            }

            return returnInput;
        }

        public string GetInputFromPlayer(List<PlayerInputMessage> _messages, params object[] _messageArguments)
        {
            //TODO: Instead of showing the full message right away would be nice to show letter by letter being written.
            string returnInput = string.Empty;

            //Reorder message list so we know for sure we are showing message in the intended order
            _messages.OrderBy(x => x.ExhibitionOrder);

            //Clean the console before sending new messages.
            Console.Clear();

            while (string.IsNullOrEmpty(returnInput))
            {

                //Show message to the player before asking for the input. using for instead of foreach for a little performance gain.
                for (int i = 0; i < _messages.Count; i++)
                {
                    //Show message to the player in order.
                    Console.WriteLine(String.Format(_messages[i].Message + "\n", _messageArguments));
                }

                returnInput = Console.ReadLine();

                //If the input is not valid (such as pressing enter with blank input) show the input error message and goes to ask again the information to the player.
                if (string.IsNullOrEmpty(returnInput))
                {
                    Console.Clear();
                    Console.WriteLine(String.Format(_messages[0].InvalidInput + "\n", _messageArguments));
                }
            }

            return returnInput;
        }

        public dynamic GetMutipleChoiceInputFromPlayer<T>(List<PlayerInputMessage> _messages, List<T> _options)
        {
            //TODO: Instead of showing the full message right away would be nice to show letter by letter being written.
            string returnInput = string.Empty;

            //Reorder message list so we know for sure we are showing message in the intended order
            _messages.OrderBy(x => x.ExhibitionOrder);

            //Clean the console before sending new messages.
            Console.Clear();


            while (string.IsNullOrEmpty(returnInput))
            {

                //Show message to the player before asking for the input. using for instead of foreach for a little performance gain.
                for (int i = 0; i < _messages.Count; i++)
                {
                    //Show message to the player in order.
                    Console.WriteLine(_messages[i].Message + "\n");
                }

                //Prepare the options to be shown to the player
                for (int i = 0; i < _options.Count; i++)
                {
                    Console.WriteLine(string.Format("[{0}] {1}", i, _options[i].GetType().GetProperty("Name").GetValue(_options[i])));
                }

                returnInput = Console.ReadLine();

                //Check if the input was a number
                if (int.TryParse(returnInput, out int n))
                {
                    //lets check if the input was a valid within our list
                    if (_options.ElementAtOrDefault(n) != null)
                        return _options[n];
                }

                //Not a valid input, lets clean the string.
                returnInput = string.Empty;

                //If the input is not valid (such as pressing enter with blank input) show the input error message and goes to ask again the information to the player.
                if (string.IsNullOrEmpty(returnInput))
                {
                    Console.Clear();
                    Console.WriteLine(_messages[0].InvalidInput + "\n");
                }
            }

            return null;
        }

        // prints the matrix that indicates the tiles of the battlefield
        public void DrawBattlefield(GridBox[] _gridBox, short _xLenght)
        {
            Console.Clear();
            for (int i = 0; i < _gridBox.Length; i++)
            {
                if (_gridBox[i].occupied)
                    Console.Write("[X]\t");
                else
                    Console.Write($"[ ]\t");

                //End of the line, move to next one.
                if (_gridBox[i].xIndex == (_xLenght - 1))
                    Console.Write(Environment.NewLine + Environment.NewLine);

            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }

        // prints the matrix that indicates the tiles of the battlefield and paint in green the player position
        public void DrawBattlefield(GridBox[] _gridBox, short _xLenght, short _playerPosition)
        {
            Console.Clear();
            for (int i = 0; i < _gridBox.Length; i++)
            {
                Console.ResetColor();

                if (i == _playerPosition)
                    Console.BackgroundColor = ConsoleColor.Green;

                if (_gridBox[i].occupied)
                    Console.Write("[X]\t");
                else
                    Console.Write($"[ ]\t");

                //End of the line, move to next one.
                if (_gridBox[i].xIndex == (_xLenght - 1))
                    Console.Write(Environment.NewLine + Environment.NewLine);

            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }

        // prints the matrix that indicates the tiles of the battlefield and paint in green the player position and red the enemy position
        public void DrawBattlefield(GridBox[] _gridBox, short _xLenght, short _playerPosition, short _enemyPosition, bool _shoudlClean = true)
        {
            if (_shoudlClean)
                Console.Clear();

            for (int i = 0; i < _gridBox.Length; i++)
            {
                Console.ResetColor();

                if (i == _playerPosition)
                    Console.BackgroundColor = ConsoleColor.Green;
                else if (i == _enemyPosition)
                    Console.BackgroundColor = ConsoleColor.Red;

                if (_gridBox[i].occupied)
                    Console.Write("[X]\t");
                else
                    Console.Write($"[ ]\t");

                //End of the line, move to next one.
                if (_gridBox[i].xIndex == (_xLenght - 1))
                    Console.Write(Environment.NewLine + Environment.NewLine);

            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }

        public void EndTurn()
        {
            Console.WriteLine("Press Enter to continue");
            Console.ReadKey();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
        }

        public void StartTurn()
        {
            Console.Clear();
        }

        /// <summary>
        /// Clean the last line write, mostly to clean "Press Enter to continue" message.
        /// </summary>
        private void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
