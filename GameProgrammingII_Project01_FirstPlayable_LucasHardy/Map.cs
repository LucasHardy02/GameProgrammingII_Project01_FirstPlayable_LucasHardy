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
        public static string[] _mapLines = Array.Empty<string>();

        private int _mapHeight;
        // used for x and y due to bprders.
        public int _mapOffset = 1;
        public int MapHeight
        {
            get { return _mapHeight; }
        }

        private int _mapWidth;

        public int MapWidth
        {
            get { return _mapWidth; }
        }

        public int _lavaDamage = 25;

        public List<(int x, int y)> _goldList;
        public char gold = '0';
        public int _goldCount;

        public void DisplayMap()
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
        public void SetForegroundColor(char mapCharacter)
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
        public void RestoreMapTile(int x, int y)
        {
            char tile = _mapLines[y][x];
            Console.SetCursorPosition(x + 1, y + 1);
            SetForegroundColor(tile);
            Console.Write(tile);
        }

        public void DrawGold()
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
