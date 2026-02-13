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
        public Map Map => _map;
        private Player _player;
        private List<Enemy> _enemies = new List<Enemy>();
        public List<Enemy> Enemies => _enemies;
        public Player Player
        {
            get { return _player; }
        }

        public bool _gameOver = false;
        public bool _winstate = false;
        public bool _playersTurn = true;
        public bool _gameRunning = true;

        public static bool Gameover { get; internal set; }
        public static bool Winstate { get; internal set; }
    

        public void InitializeGame()
        {
            Console.SetCursorPosition(0, 0);
            _map = new Map();
            /// I have to temporarily pass through null because enemy and player rely on eachother.
            _enemies = new List<Enemy>();
            _enemies.Add(new Enemy(_map,null) { XPos = 14, YPos = 14 });
            _enemies.Add(new Enemy(_map, null) { XPos = 10, YPos = 14 });




            _player = new Player(_map, _enemies);


            foreach (Enemy enemyInstance in _enemies)
            {
                enemyInstance.SetPlayer(_player);
            }

            _map.DisplayMap();
            _player.Draw();
            foreach (Enemy enemyInstance in _enemies)
            {
                enemyInstance.Draw();
            }
            _map.AddGoldToGame(_enemies);
            _map.DrawGold();
            _gameRunning = true;
        }
    }
}
