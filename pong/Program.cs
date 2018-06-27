using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    class Program
    {
        public static InputManager i;
        public static int points;
        private static display d;
        private static gameBoard gb;
        private static paddle pd;
        private static ball b;
        private static iController c;

        static void Main(string[] args)
        {
            i = new InputManager();
            d = new display();
            gb = new gameBoard(d);
            pd = new paddle(2, d, 1);
            b = new ball(d, 3, pd);

            //c = new Controllers.PlayerController();
            c = new Controllers.PerfectAI();

            while (!i.IsKeyFalling(OpenTK.Input.Key.Escape))
            {
                i.Update();
                d.draw();
                doGameUpdate();
                drawPoints();

                System.Threading.Thread.Sleep(20);
            }
        }

        public static void doGameUpdate()
        {
            gb.update();
            pd.reDraw(c.getMove(b.update()));
        }

        public static void drawPoints()
        {
            Console.SetCursorPosition(0, d.yMax + 1);
            Console.Write("Points: " + points + "                        ");
        }
    }
}
