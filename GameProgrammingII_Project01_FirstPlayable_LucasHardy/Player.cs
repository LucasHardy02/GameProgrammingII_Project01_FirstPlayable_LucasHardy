using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameProgrammingII_Project01_FirstPlayable_LucasHardy
{
    internal class Player : Character
    {
        static int _playerX;
        static int _playerY;

        static Map _map;

        static Health _playerHealth = new Health(100);


        public Player(int x, int y) : base('O', x, y)
        {
            XPos = x;
            YPos = y;
        }

        public override void Attack(Character target)
        {
            target.TakeDamage(Damage);
        }
        public override void Draw()
        {
            if (!_playerHealth.IsDead())
            {
                Console.SetCursorPosition(XPos + _map._mapOffset, YPos + _map._mapOffset);
                Console.ResetColor();

                Console.SetCursorPosition(XPos + _map._mapOffset, YPos + _map._mapOffset);
                Console.Write(Icon);
            }
            else
            {

            }
        }
        public override void Movement()
        {

            if (GameOver || Winstate) return;

            int newX = _playerX;
            int newY = _playerY;

            int oldX = _playerX;
            int oldY = _playerY;

            ConsoleKeyInfo Direction = Console.ReadKey(true);

            if (Direction.Key == ConsoleKey.W)
            {
                newY = newY - 1;
            }

            if (Direction.Key == ConsoleKey.S)
            {
                newY = newY + 1;
            }

            if (Direction.Key == ConsoleKey.D)
            {
                newX = newX + 1;
            }

            if (Direction.Key == ConsoleKey.A)
            {
                newX = newX - 1;
            }

            if (newX >= _map.MapWidth)
            {
                newX = oldX;
            }
            else if (newX < 0)
            {
                newX = oldX;
            }

            if (newY >= _map.MapHeight)
            {
                newY = oldY;
            }
            else if (newY < 0)
            {
                newY = oldY;
            }

            if (newY == enemy.YPos && newX == enemyXPos)
            {
                playerAttack();
                DrawEnemy();
                return;
            }
            else if (mapLines[newY][newX] == '░')
            {
                playerHealth = playerHealth - lavaDamage;

                if (playerHealth <= 0)
                {
                    GameOver = true;
                }

                if (newX >= 0 && newX < mapLines[0].Length)
                {
                    playerXPos = newX;
                }

                if (newY >= 0 && newY < mapLines.Length)
                {
                    playerYPos = newY;
                }

                RestoreMapTile(oldX, oldY);
            }
            else if (!(mapLines[newY][newX] == '*' ||
                       mapLines[newY][newX] == '^' ||
                       mapLines[newY][newX] == '~'))
            {
                for (int i = 0; i < goldList.Count; i++)
                {
                    if (newX == goldList[i].x && newY == goldList[i].y)
                    {
                        goldCollected = goldCollected + 1;
                        goldList.RemoveAt(i);

                        Console.SetCursorPosition(0, 17);
                        Console.Write($"Player's Gold: {goldCollected}");

                        if (goldCollected == 5 && enemy1Health <= 0)
                        {
                            Winstate = true;
                        }

                        break;
                    }
                }

                playerXPos = newX;
                playerYPos = newY;
                RestoreMapTile(oldX, oldY);
            }
            else
            {
                newX = oldX;
                newY = oldY;
            }

            DrawPlayer();
        }
    }
}


