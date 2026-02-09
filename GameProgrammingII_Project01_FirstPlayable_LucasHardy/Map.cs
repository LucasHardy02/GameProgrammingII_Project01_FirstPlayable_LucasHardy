using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgrammingII_Project01_FirstPlayable_LucasHardy
{
    internal class Map
    {
        static string _map = "Map.txt";
        static string[] _mapLines = Array.Empty<string>();

        private int _mapHeight;

        public int MapHeight
        {
            get { return _mapHeight; }
        }

        private int _mapWidth;

        public int MapWidth
        {
            get { return _mapWidth; }
        }

        static List<(int x, int y)> _goldList;
        static char gold = '0';
        static int _goldCount;


        static void DrawPlayer()
        {
            if (_playerHealth > 0)
            {
                Console.SetCursorPosition(_playerX + 1, _playerY + 1);
                Console.ResetColor();

                Console.SetCursorPosition(_playerX + 1, _playerY + 1);
                Console.Write(_playerIcon);
            }
            else
            {
            }
        }
        public  void DisplayMap()
        {

            _mapHeight = _mapLines.Length;
            _mapWidth = _mapLines[0].Length;
            string _topBottomBorder = "═";



            for (int i = 0; i < _mapWidth + 2; i++)
            {
                Console.ResetColor();
                Console.Write(_topBottomBorder);
            }

            Console.Write("\n");
            for (int y = 0; y < _mapHeight; y++)

            {
                Console.ResetColor();
                Console.Write('║');
                for (int x = 0; x < _mapLines[y].Length; x++)
                {
                    char tile = _mapLines[y][x];
                    SetForegroundColor(tile);
                    Console.Write(tile);
                }
                Console.ResetColor();
                Console.Write('║');
                Console.Write("\n");


            }
            for (int i = 0; i < _mapWidth + 2; i++)
            {
                Console.ResetColor();
                Console.Write(_topBottomBorder);
            }
        }
        static void SetForegroundColor(char mapCharacter)
        {
            if (mapCharacter == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            else if (mapCharacter == '`')
            {
                Console.ForegroundColor = ConsoleColor.Green;

            }
            else if (mapCharacter == '~')
            {
                Console.ForegroundColor = ConsoleColor.Blue;

            }
            else if (mapCharacter == '*')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;

            }
            else if (mapCharacter == '"')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (mapCharacter == '░')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ResetColor();
            }
        }
        static void RestoreMapTile(int x, int y)
        {
            char tile = _mapLines[y][x];
            Console.SetCursorPosition(x + 1, y + 1);
            SetForegroundColor(tile);
            Console.Write(tile);
        }

        static void DrawGold()
        {
            foreach (var g in _goldList)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(g.x + 1, g.y + 1);
                Console.Write(gold);
            }
            Console.ResetColor();
        }
    }
}
