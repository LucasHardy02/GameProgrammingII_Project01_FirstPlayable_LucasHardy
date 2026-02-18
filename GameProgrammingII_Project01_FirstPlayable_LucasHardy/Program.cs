using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            
            _gameManager.InitializeGame();

            _gameManager.Map._goldList = new List<(int x, int y)>();

            _gameManager.Map.AddGoldToGame(_gameManager.Enemies);

            while (_gameManager._gameOver == false)
            {
                if (_gameManager.Enemies.All(e => e.Health.IsDead()) && _gameManager.Map._goldCollected >= _gameManager.Map._goldToCollect)
                {
                    _gameManager._winstate = true;
                }
                if (_gameManager._winstate == true)
                {
                    Console.Clear();
                    Console.Write("You win!                                         ");
                    break;

                }
                if (_gameManager._playersTurn)
                {
                    if (!_gameManager.Player.Health.IsDead())
                    {
                        DisplayHUD();
                        _gameManager.Player.Movement();
                        _gameManager._playersTurn = false;
                    }
                    else
                    {
                        _gameManager._gameOver = true;
                        GameOverDisplay();
                    }

                }
                else /// enemys turn
                {
                    foreach (Enemy enemyInstance in _gameManager.Enemies)
                    {
                        if (!enemyInstance.Health.IsDead())
                        {
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 18);
                            Console.Write("Enemies Turn     ");
                            Thread.Sleep(150);
                            enemyInstance.Movement();

                            if (enemyInstance.Health.IsDead())
                            {
                                _gameManager.Map.RestoreMapTile(enemyInstance.XPos, enemyInstance.YPos);
                            }
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 18);
                            Console.Write("                   ");

                        }
                    }
                    _gameManager._playersTurn = true;

                }

                if (_gameManager._gameOver == true)
                {
                    GameOverDisplay();
                }
            }
            void DisplayHUD()
            {
                Console.ResetColor();
                Console.SetCursorPosition(0, 18);
                Console.Write("Player's Turn     ");
                Console.SetCursorPosition(0, 19);
                Console.Write($"Player's Health: {_gameManager.Player.Health.CurrentHealth}     ");
                Console.SetCursorPosition(0, 21);
                Console.Write("Collect the gold and defeat the enemy to win!");

            }
            void GameOverDisplay()
            {
                Console.ResetColor();
                Console.Clear();
                Console.Write("Game over pal, back to the lobby!");

            }
        }
    }
}
