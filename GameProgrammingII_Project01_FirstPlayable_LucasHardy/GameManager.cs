using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgrammingII_Project01_FirstPlayable_LucasHardy
{
    public class GameManager
    {
        private Map _map;
        private Player _player;
        private Enemy _enemy;
        public Player Player
        {
            get { return _player; }
        }

        public Enemy Enemy
        {
            get { return _enemy; }
        }
        public bool _gameOver = false;
        public bool _winstate = false;
        public bool _playersTurn = true;
        public bool _gameRunning = true;


        public int _playerXSpawnPos = 0;
        public int _playerYSpawnPos = 0;
        public int _enemyXSpawnPos = 26;
        public int _enemyYSpawnPos = 10;
        public static bool Gameover { get; internal set; }
        public static bool Winstate { get; internal set; }
    

        public void InitializeGame()
        {
            Console.SetCursorPosition(0, 0);
            _map = new Map();
            /// I have to temporarily pass through null because enemy and player rely on eachother.
            _enemy = new Enemy(_map, null);
            _player = new Player(_map, _enemy);

            _enemy.SetPlayer(_player);

            _map.DisplayMap();
            _player.Draw();
            _enemy.Draw();
            _map.AddGoldToGame();
            _map.DrawGold();
            _gameRunning = true;
        }
    }
}
