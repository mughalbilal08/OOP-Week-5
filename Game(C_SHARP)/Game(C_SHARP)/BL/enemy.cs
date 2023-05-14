using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_C_SHARP_.BL
{
    class enemy
    {
        public int enemyX ;                              // enemy coordinates
        public int enemyY;                              // enemy coordinates

        public void enemyPlayer(ref char[,] maze, ref char[,] enemy, enemy game2)
        {
            for (int x = 0; x < enemy.GetLength(0); x++)
            {

                for (int y = 0; y < enemy.GetLength(1); y++)
                {
                    Console.SetCursorPosition(game2.enemyY + y, game2.enemyX + x);
                    Console.Write(enemy[x, y]);
                    maze[game2.enemyX + x, game2.enemyY + y] = enemy[x, y];
                }
            }
        }
        public void eraseEnemyCharacter1(ref char[,] maze, ref char[,] enemy, enemy game2)
        {
            for (int x = 0; x < enemy.GetLength(0); x++)
            {

                for (int y = 0; y < enemy.GetLength(1); y++)
                {
                    Console.SetCursorPosition(game2.enemyY + y, game2.enemyX + x);
                    Console.Write(" ");
                    maze[game2.enemyX + x, game2.enemyY + y] = ' ';
                }
            }
        }
        public void moveenemy1(ref char[,] maze, ref char[,] enemy, enemy game2, ref string enemyDirection1)
        {
            if (enemyDirection1 == "down")
            {
                if (maze[game2.enemyX + 3, game2.enemyY] == ' ')
                {
                    eraseEnemyCharacter1(ref maze, ref enemy, game2);
                    game2.enemyX++;
                    enemyPlayer(ref maze, ref enemy, game2);
                }
                if (game2.enemyX == 10)
                {
                    enemyDirection1 = "up";

                }
            }
            if (enemyDirection1 == "up")
            {
                if ((maze[game2.enemyX - 1, game2.enemyY] == ' '))
                {
                    eraseEnemyCharacter1(ref maze, ref enemy, game2);
                    game2.enemyX--;
                    enemyPlayer(ref maze, ref enemy, game2);
                }
                if (maze[game2.enemyX - 1, game2.enemyY] == '#')
                {
                    enemyDirection1 = "down";
                }
            }
        }
        public void playerBulletCollisionWithE(enemy game2, ref char[,] maze, ref int healthE, ref int score)
        {
            if (maze[game2.enemyX + 3, game2.enemyY] == '*')
            {
                score++;
                healthE = healthE - 10;
            }

            if (maze[game2.enemyX + 3, game2.enemyY + 1] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            if (maze[game2.enemyX + 3, game2.enemyY + 2] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            if (maze[game2.enemyX + 3, game2.enemyY + 3] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            if (maze[game2.enemyX + 3, game2.enemyY + 4] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            if (maze[game2.enemyX + 3, game2.enemyY + 5] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            else if (healthE <= 0)
            {
                healthE = 0;
            }
        }

    }
    class enemyB
    {
       public int bulletenemyX;          // enemy Bullet
       public int bulletenemyY;          // enemy Bullet
        public void generateEbullet(ref char[,] maze, List<enemyB> W, enemy game2, ref int enemy1Shot)
        {
            enemyB v = new enemyB();
            if (enemy1Shot % 4 == 0)
            {
                v.bulletenemyX = game2.enemyX + 2;
                v.bulletenemyY = game2.enemyY + 2;
                char next = maze[v.bulletenemyX, v.bulletenemyY];
                if (next == ' ')
                {
                    printEbullet(ref maze, v.bulletenemyX, v.bulletenemyY);
                    W.Add(v);
                }
            }
            enemy1Shot++;
        }
        public void printEbullet(ref char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write("o");
            maze[x, y] = 'o';
        }
        public void eraseEbullet(ref char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
            maze[x, y] = ' ';
        }
        public void moveEbullet(ref char[,] maze, List<enemyB> W, enemy game2, data game)
        {
            for (int x = 0; x < W.Count; x++)
            {

                char next = maze[W[x].bulletenemyX + 1, W[x].bulletenemyY + 1];

                if (next == ' ')
                {
                    eraseEbullet(ref maze, W[x].bulletenemyX, W[x].bulletenemyY);
                    W[x].bulletenemyX++;
                    if ((game2.enemyX != game.shipY))
                    {
                        W[x].bulletenemyY = W[x].bulletenemyY + 2;
                    }
                    printEbullet(ref maze, W[x].bulletenemyX, W[x].bulletenemyY);
                }
                else if (next != ' ' || (maze[game2.enemyX + 1, game2.enemyY + 2] != ' ') || (maze[game2.enemyX + 2, game2.enemyY + 2] != ' ') || (maze[game2.enemyX + 3, game2.enemyY + 2] != ' ') || (maze[game2.enemyX + 4, game2.enemyY + 2] != ' ') || (maze[game2.enemyX + 5, game2.enemyY + 2] != ' '))
                {
                    eraseEbullet(ref maze, W[x].bulletenemyX, W[x].bulletenemyY);
                    W.RemoveAt(x);
                }

            }
        }

    }

}
