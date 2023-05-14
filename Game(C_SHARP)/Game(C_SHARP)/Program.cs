using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using EZInput;
using Game_C_SHARP_.BL;
namespace Game_C_SHARP_
{
    class Program
    {
        static void Main(string[] args)
        {

            //                   ########################### ARRAYS ##############################
                     
            int score = 0;
            int healthE = 100;
            int healthP = 100;
            int enemy1Shot = 0;
            bool enemy1present = true;            
            string enemyDirection1 = "down";
            
            //    PLAYER COORDINATES;

            char up = (char)94;
            char box = (char)219;
            char[,] ship = new char[2, 5]{
                { ' ', ' ', up, ' ', ' '},
                { '-', box, box, box, '-'}
                };

            //  Enemy  PLAYER COORDINATES;

            char[,] enemy = new char[2, 5]{
             { '-', box, box, box, '-'},
             { ' ', ' ', up, ' ', ' '},
            };

            //    Maze;

            char[,] maze2D = new char[26, 130];

       
            //    Classes            
            
            
            List<bulletsP> Q = new List<bulletsP>();
            data game = new data();
            game.shipX = 22;
            game.shipY = 60;

            List<enemyB> W = new List<enemyB>();
            enemy game2 = new enemy();
            game2.enemyX = 3;
            game2.enemyY = 5;


            //                                    ##################### Body #########################       

            int option = 0;
            Console.Clear();
            loading();
            Console.Clear();
            header();
            loadmaze(ref maze2D);
            printingMaze1(ref maze2D);
            storemaze(ref  maze2D);
            
            while(option != 3)
            {
                Console.Clear();
                header();
                
                option = login();
                if (option == 1)
                {
                    
                    int choice = gamemenu();
                    if (choice == 1)
                    {

                        game.shipX = 22;
                        game.shipY = 60;
                        game2.enemyX = 3;
                        game2.enemyY = 5;
                        score = 0;
                        healthE = 100;
                        healthP = 100;

                        startGame(ref enemy1present, ref enemy1Shot, ref enemyDirection1, ref maze2D, ref ship, ref enemy,W, game, game2,Q,ref healthP, ref healthE, ref score);
                      
                    }
                    if (choice == 2)
                    {
                        Console.Write("COMING");
                        Console.ReadKey();
                    }
                }
                if (option == 2)
                {
                    Console.Clear();
                    header();
                    keys();
                    Console.ReadKey();
                    
                }

                if (option == 3)
                {
                    Console.Clear();
                    
                }

            }

        }

        //                                           ################### Printing ######################## 
        public static int login()
        {
            int choice;
            Console.WriteLine("Press 1 To Start The Game: ");
            Console.WriteLine("Press 2 to Read Instructions oF the Game: ");
            Console.WriteLine("Press 3 To Exit The Game: ");
            Console.WriteLine("...................................");
            Console.WriteLine("Enter Your Choice ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static void header()
        {
            Console.WriteLine();
            Console.WriteLine("         _______   __   __   ___   _______    _     _   _______   ______    ");
            Console.WriteLine("        |       | |  | |  | |   | |       |  | | _ | | |   _   | |    _ |   ");
            Console.WriteLine("        |  _____| |  |_|  | |   | |    _  |  | || || | |  |_|  | |   | ||   ");
            Console.WriteLine("        | |_____  |       | |   | |   |_| |  |       | |       | |   |_||_  ");
            Console.WriteLine("        |_____  | |       | |   | |    ___|  |       | |       | |    __  | ");
            Console.WriteLine("         _____| | |   _   | |   | |   |      |   _   | |   _   | |   |  | | ");
            Console.WriteLine("        |_______| |__| |__| |___| |___|      |__| |__| |__| |__| |___|  |_| ");
            Console.WriteLine();
        }
        public static void clear()
        {
            Console.WriteLine();
            Console.Write("Press Any Key To Continuou");
            Console.Clear();
            Console.WriteLine();
        }
        public static void keys()
        {
            Console.WriteLine("1. UP         GO UP");
            Console.WriteLine("2. DOWN       GO DOWN");
            Console.WriteLine("3. LEFT       GO LEFT");
            Console.WriteLine("4. RIGHT      GO RIGHT");
            Console.WriteLine("5. SPACE      Fire");
        }
        public static int gamemenu()
        {

            int choice = 0;
            Console.Clear();
            header();
            Console.WriteLine("Press 1 To Start The New Game: " );
            Console.WriteLine("Press 2 To Load Old Saved Game: " );
            Console.WriteLine("Press 3 To Exit The Game: " );
            Console.WriteLine("..................................." );
            Console.WriteLine("Enter Your Choice " );
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static void loading()

        {
  
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine( "                                   .                                                 # #  ( )                      .                   .                                            " );
            Console.WriteLine( "                                     ..                                       ___#_#___|__                             .                                                            " );
            Console.WriteLine( "             .        .          .                                        _  |____________|  _                                 .               .                                    " );
            Console.WriteLine( "          .    .        .                                          _=====| | |            | | |====_                               .     .                                          " );
            Console.WriteLine( "               .                                            =====| |.---------------------------. | |====                  . ..         .                                          " );
            Console.WriteLine( "         .        . .                         <--------------------'   .  .  .  .  .  .  .  .   '----------------//                 ..                                               " );
            Console.WriteLine( "                     .                          \\                                                               //                .                                                  " );
            Console.WriteLine( "         .             ..     ..                 \\                                                             //        ..    .. .                                                 " );
            Console.WriteLine( "                ..       .    .                   \\_______________________________________________WWS_________//            .           .                                         " );
            Console.WriteLine( "        .                ..              wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww         . .     . .                                         " );
            Console.WriteLine( "          ..              ..            wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww        .                                               " );
            Console.WriteLine( "                                          wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww                   . .                                    " );

 
            Console.WriteLine( "        --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- " );
            Console.WriteLine( );
            Console.WriteLine( );
            Console.WriteLine( );
            Console.WriteLine( );

            char box =(char) 219;

           

            Console.WriteLine( "                                                          Your Game Is Loading ");
            for (int i = 0; i < 9; i++)
            {
                Thread.Sleep(300);
            }
            Console.WriteLine( );
        }
        static void printScore(int healthP, int healthE, int score)
        {
            Console.SetCursorPosition(140, 11);
            Console.WriteLine("Score: " + score);

            Console.SetCursorPosition(140, 10);
            Console.WriteLine("Health is: " + healthP);
          
            Console.SetCursorPosition(140, 12);
            Console.WriteLine("Enemy Health is: " + healthE);

        }

        //                                           ################# MAZE PRINTING ######################

        public static void loadmaze(ref char[,] maze)
        {
            
            string line;
            
            string path = "P:\\OPP Week 2\\Game(C_SHARP)\\Game(C_SHARP)\\maze.txt";
            int row = 0;
            StreamReader myFile = new StreamReader(path);
            while ((line = myFile.ReadLine()) != null)
            {
                for (int colom = 0; colom < 130; colom++)
                {
                    maze[row,colom] = line[colom];
                }
                Console.WriteLine();
                row++;
            }
            myFile.Close();
        }
        public static void printingMaze1(ref char[,] maze)
        {
            for (int x = 0; x < 26; x++)
            {
                for (int y = 0; y < 130; y++)
                {

                    if ((x == 0) && (y > -1 && y < 130))

                    {
                        maze[x, y] = '_';
                    }

                    else if ((x == 24) && (y > 2 && y < 127))

                    {
                        maze[x, y] = '_';
                    }

                    else if ((x == 1) && (y > 2 && y < 127))

                    {
                        maze[x, y] = '#';
                    }

                    else if ((x == 25) && (y > -1 && y < 130))

                    {
                        maze[x, y] = '#';
                    }

                     else if ((x == 19) && (y >= 40 && y <= 85))

                     {
                         maze[x,y] = '#';
                     }

                    else if ((y == 0 || y == 129) && (x > 0 && x < 25))

                    {
                        maze[x, y] = '|';
                    }

                    else if ((y == 1 || y == 128) && (x > 0 && x < 25))

                    {
                        maze[x, y] = '@';
                    }

                    else if ((y == 2 || y == 127) && (x > 0 && x < 25))
                    {
                        maze[x, y] = '|';
                    }

                    else
                    {
                        maze[x, y] = ' ';
                    }            
                }             
            }
        }
        public static void storemaze(ref char[,] maze)
        {
            string line;
            string path = "P:\\OPP Week 2\\Game(C_SHARP)\\Game(C_SHARP)\\maze.txt";
            int row = 0;
            StreamWriter myFile = new StreamWriter(path, false);
            {
                for (int x = 0; x < 26; x++)
                {
                    for (int y = 0; y < 130; y++)
                    {
                        myFile.Write(maze[x, y]);
                    }
                    myFile.WriteLine();
                }
            }
            myFile.Close();
        }
        public static void maze12D(ref char[,] maze)
        {

            Console.Clear();
            

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write( maze[x,y]);
                }
                Console.WriteLine();
            }
        }

        //                                          ################ MOVEMENT OF PlaYer #####################

        static void movePlayer(ref char[,] maze2D, ref char[,] ship, data game, List<bulletsP> Q)
        {
            data objdat = new data();
            bulletsP objbul = new bulletsP();
            Thread.Sleep(90);

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                objdat.moveShipRight(ref maze2D, ship, game);
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                objdat.moveShipLeft(ref maze2D, ship, game);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                objbul.generateBulletPlayer(ref maze2D, game, Q);
            }
        }

        //                                          ################ GaMe StaRt ###########################

        static void startGame(ref bool enemy1present,ref int enemy1Shot ,ref string enemyDirection1, ref char[,] maze2D, ref char[,] ship, ref char[,] enemy,List<enemyB> W, data game,enemy game2,List<bulletsP>Q, ref int healthP, ref int healthE, ref int score)
        {

            W.Clear();
            Q.Clear();
            loadmaze(ref maze2D);
            Console.Clear();
            enemy1present = true;

            maze12D(ref maze2D);

            bool gamerunning = true;
            bulletsP a = new bulletsP();
            enemyB s = new enemyB();

            while (gamerunning)
            {
                data objdat = new data();
                bulletsP objbul = new bulletsP();
                enemy objdat1 = new enemy();
                enemyB objbul1 = new enemyB();

                if (enemy1present == true)
                {
                    
                    objdat1.enemyPlayer(ref maze2D, ref enemy, game2);
                    objbul1.generateEbullet(ref maze2D,W, game2, ref enemy1Shot);
                    objdat1.moveenemy1(ref maze2D, ref enemy, game2, ref enemyDirection1);
                    printScore( healthP,  healthE, score);
                }
                if (healthP == 0 || healthE == 0)
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Game Ends");
                    Console.WriteLine("Score:" + score);

                    gamerunning = false;

                    objdat.Eraseplayer(ref maze2D, ship, game);
                    objbul.erasebullet(ref maze2D, a.bulletshipX, a.bulletshipY, Q);
                    objdat1.eraseEnemyCharacter1(ref maze2D, ref enemy, game2);
                    objbul1.eraseEbullet(ref maze2D, s.bulletenemyX, s.bulletenemyY);
                    loadmaze(ref maze2D);

                    Thread.Sleep(2000);
                }

                if (Keyboard.IsKeyPressed(Key.Escape))
                {
                    storemaze(ref maze2D);
                    gamerunning = false;
                    break;
                }

                objdat.player(ref maze2D, ship, game);
                movePlayer(ref maze2D, ref ship, game,Q);

                objbul.movebullet(ref maze2D,Q);
                objbul1.moveEbullet(ref maze2D,W, game2, game);

                objdat1.playerBulletCollisionWithE(game2, ref maze2D, ref healthE, ref score);
                objdat.enemyBulletCollisionWithPlayer(game, ref maze2D, ref healthP);
            }

        }
        public static void printbullet(ref char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write("*");
            maze[x, y] = '*';
        }
    }

}

