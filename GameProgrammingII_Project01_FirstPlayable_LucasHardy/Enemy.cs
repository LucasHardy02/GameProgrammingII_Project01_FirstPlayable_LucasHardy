using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameProgrammingII_Project01_FirstPlayable_LucasHardy
{
    public class Enemy : Character
    {
        private Map _map;
        private Player _player;
        public Enemy(Map map, Player player) : base('X', 15, 15)
        {
            _map = map;
            _player = player;
            Health = new Health(100);
        }
        public override void Attack(Character target)
        {
            target.TakeDamage(Damage);
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
            {
                if (GameManager.Gameover || GameManager.Winstate)
                {
                    return;
                }

                if (Health.IsDead())
                {
                    return;
                }

                int targetX = _player.XPos - XPos;
                int targetY = _player.YPos - YPos;

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

                if (newXPos == _player.XPos && newYPos == _player.YPos)
                {
                    Attack(_player);
                    _player.Draw();
                    return;

                }
                else if (_map._mapLines[newYPos][newXPos] == '░')
                {
                    Health.TakeDamage(_map._lavaDamage);

                    if (Health.IsDead())
                    {
                        _map.RestoreMapTile(XPos, YPos);

                        if (_map._goldCollected == 5)
                        {
                            GameManager.Winstate = true;
                        }
                        return;
                    }


                    _map.RestoreMapTile(oldXPos, oldYPos);
                    XPos = newXPos;
                    YPos = newYPos;
                    Draw();
                    return;


                }
                else if (!(
                    _map._mapLines[newYPos][newXPos] == '*' || 
                    _map._mapLines[newYPos][newXPos] == '^' || 
                    _map._mapLines[newYPos][newXPos] == '~'
                    ))
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
