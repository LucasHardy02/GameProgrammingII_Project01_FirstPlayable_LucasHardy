using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameProgrammingII_Project01_FirstPlayable_LucasHardy
{
    internal class Enemy : Character
    {
        Health _enemyHealth = new Health(100);
        Map _map;
        Player player;
        GameManager _gameManager;


        public Enemy(int x, int y) : base('X', x, y)
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

            if (!_enemyHealth.IsDead())
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
            {
                if (GameOver || Winstate)
                {
                    return;
                }

                if (_enemyHealth.IsDead())
                {
                    return;
                }

                int targetX = player.XPos - XPos;
                int targetY = player.YPos - YPos;

                int newXPos = XPos;
                int newYPos = YPos;

                int oldXPos = XPos;
                int oldYPos = YPos;


                if (Math.Abs(targetX) > Math.Abs(targetY))
                {
                    if (targetX > 0)
                    {
                        newXPos = oldXPos + 1;
                    }
                    else
                    {
                        newXPos = oldXPos - 1;
                    }

                }
                else
                {
                    if (targetY > 0)
                    {
                        newYPos = oldYPos + 1;
                    }
                    else
                    {
                        newYPos = oldYPos - 1;
                    }

                }

                if (newXPos == player.XPos && newYPos == player.YPos)
                {
                    Attack(player);
                    player.Draw();
                    return;

                }
                else if (_map._mapLines[newYPos][newXPos] == '░')
                {
                    _enemyHealth.TakeDamage(_map._lavaDamage);

                    if (_enemyHealth.IsDead())
                    {
                        _map.RestoreMapTile(XPos, YPos);

                        if (_map._goldCount == 5)
                        {
                            _gameManager.Winstate = true;
                        }
                        return;
                    }


                    _map.RestoreMapTile(oldXPos, oldYPos);
                    XPos = newXPos;
                    YPos = newYPos;
                    Draw();
                    return;


                }
                else if (!(_map._mapLines[newYPos][newXPos] == '*' || (_map.mapLines[newYPos][newXPos] == '^' || (_map.mapLines[newYPos][newXPos] == '~'))
                {
                    _map.RestoreMapTile(oldXPos, oldYPos);
                    XPos = newXPos;
                    YPos = newYPos;
                    Draw();
                    return;

                }

                return;


            }
        }
    }
}
