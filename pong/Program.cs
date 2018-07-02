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

        public static int hits;
        public static int misses;
        public static int bounces;
        public static int fps;

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
            b = new ball(d, 4, pd);

            //c = new Controllers.PlayerController();
            //c = new Controllers.PerfectAI();
            c = new Controllers.PerfectAiHybrid();

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            int counter = 0;

            while (!i.IsKeyFalling(OpenTK.Input.Key.Escape))
            {
                stopwatch.Start();

                i.Update();
                d.draw(false);
                doGameUpdate();

                //System.Threading.Thread.Sleep(5);

                stopwatch.Stop();

                counter++;
                fps = (int)(1.0 / ((double)stopwatch.ElapsedMilliseconds / (double)counter) * 1000.0);

                if (counter > 200)
                {
                    stopwatch.Reset();
                    counter = 0;
                }
            }
        }

        public static void doGameUpdate()
        {
            gb.update();
            pd.update(c.getMove(b.update()));
        }
    }
}
