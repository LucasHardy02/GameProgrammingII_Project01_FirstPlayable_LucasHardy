using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameProgrammingII_Project01_FirstPlayable_LucasHardy
{
    public class Player : Character
    {
        Map _map;
        Enemy _enemy;


        public Player(Map map, Enemy enemy) : base('O', 0, 0)
        {
            _map = map;
            _enemy = enemy;
            Health = new Health(100);
        }

        public override void Attack(Character target)
        {
            target.TakeDamage(Damage);
            if (_enemy.Health.IsDead())
            {
                _map.RestoreMapTile(_enemy.XPos, _enemy.YPos);

                if (_map._goldCollected == _map._goldToCollect)
                {
                    GameManager.Winstate = true;
                }
                return;
            }
        }
        public override void Draw()
        {
            if (!Health.IsDead())
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

            if (GameManager.Gameover || GameManager.Winstate) return;

            int newX = XPos;
            int newY = YPos;

            int oldX = XPos;
            int oldY = YPos;

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

            if (newY == _enemy.YPos && newX == _enemy.XPos)
            {
                Attack(_enemy);
                Draw();
                return;
            }
            else if (_map._mapLines[newY][newX] == '░')
            {
                Health.TakeDamage(_map._lavaDamage);

                if (Health.IsDead())
                {
                    GameManager.Gameover = true;
                }

                if (newX >= 0 && newX < _map._mapLines[0].Length)
                {
                    XPos = newX;
                }

                if (newY >= 0 && newY < _map._mapLines.Length)
                {
                    YPos = newY;
                }

                _map.RestoreMapTile(oldX, oldY);
            }
            else if (!(_map._mapLines[newY][newX] == '*' ||
                       _map._mapLines[newY][newX] == '^' ||
                       _map._mapLines[newY][newX] == '~'))
            {
                for (int i = 0; i < _map._goldList.Count; i++)
                {
                    if (newX == _map._goldList[i].x && newY == _map._goldList[i].y)
                    {
                        _map._goldCollected += 1;
                        _map._goldList.RemoveAt(i);

                        Console.SetCursorPosition(0, 17);
                        Console.Write($"Player's Gold: {_map._goldCollected}");

                        if (_map._goldCollected == 5 && _enemy.Health.IsDead())
                        {
                            GameManager.Winstate = true;
                        }

                        break;
                    }
                }

                XPos = newX;
                YPos = newY;
                _map.RestoreMapTile(oldX, oldY);
            }
            else
            {
                newX = oldX;
                newY = oldY;
            }

            Draw();
        }
    }
}


