using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgrammingII_Project01_FirstPlayable_LucasHardy
{
    public class Map
    {

        static string _map = "Map.txt.txt";
        public string[] _mapLines = File.ReadAllLines(_map);

        private int _mapHeight;

        // used for x and y due to bprders.
        public int _mapOffset = 1;
        public int MapHeight
        {
            get { return _mapLines.Length; }
        }

        private int _mapWidth;

        public int MapWidth
        {
            get { return _mapLines[0].Length; }
        }

        public int _lavaDamage = 25;

        public List<(int x, int y)> _goldList = new List<(int x, int y)>();
        public char _goldIcon = '0';
        public int _goldToCollect = 5;
        public int _goldCollected;

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
            Console.SetCursorPosition(x + _mapOffset, y + _mapOffset);
            if (_goldList.Any(goldInstance => goldInstance.x == x && goldInstance.y == y))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(_goldIcon);
            }
            else
            {
                // 2. If no gold, draw the original tile from the file
                char tile = _mapLines[y][x];
                SetForegroundColor(tile);
                Console.Write(tile);
            }

        }

        public void DrawGold()
        {
            foreach (var g in _goldList)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(g.x + 1, g.y + 1);
                Console.Write(_goldIcon);
            }
            Console.ResetColor();
        }

        public void AddGoldToGame(List<Enemy> enemies)
        {
            /// First checks to see if tile is valid for a coin (If it's grass and no other coin spawned on that tilr.) 
            /// then picks a random x and y variable that is less than 
            /// _mapHeight and _mapWidth respectively.
            /// once _placedGold == _goldToCollect (5) then no more will spawn.
            /// 

            Random random = new Random();
            int _placedGold = 0;

            while (_placedGold < _goldToCollect)
            {
                int xPos = random.Next(0, MapWidth);
                int yPos = random.Next(0, MapHeight);

                bool isGrass = _mapLines[yPos][xPos] == '`';
                bool goldAlreadyThere = _goldList.Contains((xPos, yPos));
                bool enemyThere = enemies.Any(enemyInstance => enemyInstance.XPos == xPos && enemyInstance.YPos == yPos);

                if (isGrass && !goldAlreadyThere && !enemyThere)
                {
                    _goldList.Add((xPos, yPos));
                    _placedGold++;
                }
            }


        }
    }
}
