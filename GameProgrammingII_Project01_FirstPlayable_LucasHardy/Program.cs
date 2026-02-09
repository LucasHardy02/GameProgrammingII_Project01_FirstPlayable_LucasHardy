using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgrammingII_Project01_FirstPlayable_LucasHardy
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Map map = new Map();
            map.DisplayMap();

            Player player = new Player(map);
            player.PlayerMovement();
        }
    }
}
