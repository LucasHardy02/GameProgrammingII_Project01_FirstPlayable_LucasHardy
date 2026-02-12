using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameProgrammingII_Project01_FirstPlayable_LucasHardy
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Player _player;
            Enemy _enemy;
            GameManager _gameManager = new GameManager();
            Map _map = new Map();

            _map._goldList = new List<(int x, int y)>();

            _map.AddGoldToGame();
            _gameManager.InitializeGame();

            while (_gameManager._gameOver == false)
            {

                if (_gameManager._winstate == true)
                {
                    Console.ResetColor();
                    Console.SetCursorPosition(0, 19);
                    Console.Write("You win!                                         ");
                    break;

                }
                else if (_gameManager._playersTurn)
                {
                    DisplayHUD();
                    Thread.Sleep(250);
                    _gameManager.Player.Movement();
                    _gameManager._playersTurn = false;
                }
                else
                {
                    if (_gameManager.Enemy.Health.IsDead())
                    {
                        Console.ResetColor();

                        Console.SetCursorPosition(0, 13);
                        Console.Write("Enemy's Turn     ");
                        Thread.Sleep(250);
                        _gameManager.Enemy.Movement();
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 13);
                        Console.Write("                   ");

                    }

                    _gameManager._playersTurn = true;

                }
                if (_gameManager._gameOver == true)
                {
                    Console.ResetColor();
                    Console.SetCursorPosition(0, 19);
                    Console.Write("Game Over                                        ");
                    Console.ReadKey(true);
                    break;
                }
            }
            void DisplayHUD()
            {
                Console.ResetColor();
                Console.SetCursorPosition(0, 15);
                Console.Write("Player's Turn     ");
                Console.SetCursorPosition(0, 17);
                Console.Write($"Player's Health: {_gameManager.Player.Health.CurrentHealth}     ");
                Console.SetCursorPosition(0, 21);
                Console.Write("Collect the gold and defeat the enemy to win!");

            }
        }
    }
}
