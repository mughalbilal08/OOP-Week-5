using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_C_SHARP_.BL
{
    class data
    {
        public int shipX ;                              // player coordinates
        public int shipY;                              // player coordinates
        public void player(ref char[,] maze, char[,] ship, data game)
        {
            for (int x = 0; x < ship.GetLength(0); x++)
            {
                for (int y = 0; y < ship.GetLength(1); y++)
                {
                    Console.SetCursorPosition(game.shipY + y, game.shipX + x);
                    Console.Write(ship[x, y]);
                    maze[game.shipX + x, game.shipY + y] = ship[x, y];
                }
            }
        }
        public void Eraseplayer(ref char[,] maze, char[,] ship, data game)
        {
            for (int x = 0; x < ship.GetLength(0); x++)
            {
                for (int y = 0; y < ship.GetLength(1); y++)
                {
                    Console.SetCursorPosition(game.shipY + y, game.shipX + x);
                    Console.Write(" ");
                    maze[game.shipX + x, game.shipY + y] = ' ';
                }
            }
        }
        public  void moveShipRight(ref char[,] maze, char[,] ship, data game)
        {
            if (maze[game.shipX, game.shipY + 5] == ' ' && maze[game.shipX + 1, game.shipY + 5] == ' ')
            {

                Eraseplayer(ref maze, ship, game);

                game.shipY = game.shipY + 1;
                player(ref maze, ship, game);
            }
        }
        public void moveShipLeft(ref char[,] maze, char[,] ship, data game)
        {
            if (maze[game.shipX, game.shipY - 1] == ' ' && maze[game.shipX - 1, game.shipY - 1] == ' ')
            {

                Eraseplayer(ref maze, ship, game);

                game.shipY = game.shipY - 1;
                player(ref maze, ship, game);
            }
        }
        public void enemyBulletCollisionWithPlayer(data game, ref char[,] maze, ref int healthP)
        {
            if (maze[game.shipX + 1, game.shipY] == 'o')
            {
                healthP = healthP - 10;
            }
            if (maze[game.shipX - 2, game.shipY - 3] == 'o')
            {
                healthP = healthP - 10;
            }
            if (maze[game.shipX - 3, game.shipY - 3] == 'o')
            {
                healthP = healthP - 10;
            }
            if (maze[game.shipX - 4, game.shipY - 3] == 'o')
            {
                healthP = healthP - 10;
            }
            if (maze[game.shipX - 5, game.shipY - 3] == 'o')
            {
                healthP = healthP - 10;
            }
            else if (healthP <= 0)
            {
                healthP = 0;
            }
        }
        
    }

    
    class bulletsP
    {
       public int bulletshipX ;          // Ship Bullet
       public int bulletshipY ;           // Ship Bullet
       public  void generateBulletPlayer(ref char[,] maze, data game, List<bulletsP> game2)
        {
            bulletsP d = new bulletsP();
            bulletsP f = new bulletsP();
            d.bulletshipX = game.shipX - 1;
            d.bulletshipY = game.shipY + 2;
            char next = maze[d.bulletshipX, d.bulletshipY];
            if (next == ' ')
            {
                printbullet(ref maze, d.bulletshipX, d.bulletshipY);
                game2.Add(d);

            }
        }
       
        public void erasebullet(ref char[,] maze, int x, int y, List<bulletsP> game3)
        {
            bulletsP Bulets = new bulletsP();
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
            maze[x, y] = ' ';
            game3.Remove(Bulets);
        }
        public void movebullet(ref char[,] maze, List<bulletsP> game3)
        {
            for (int x = 0; x < game3.Count; x++)
            {

                char next = maze[game3[x].bulletshipX - 1, game3[x].bulletshipY];
                if (next == ' ')
                {
                    erasebullet(ref maze, game3[x].bulletshipX, game3[x].bulletshipY, game3);
                    game3[x].bulletshipX--;
                    printbullet(ref maze, game3[x].bulletshipX, game3[x].bulletshipY);


                }
                else if (next != ' ')
                {
                    erasebullet(ref maze, game3[x].bulletshipX, game3[x].bulletshipY, game3);
                    game3.RemoveAt(x);
                }

            }
        }
    }

}
