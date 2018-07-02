using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    public class display
    {
        public readonly int xMax;
        public readonly int yMax;

        public readonly Dictionary<vector2, char> screenBuffer;

        private char[] toDisplay;

        public display()
        {
            xMax = Console.WindowWidth - 2;
            yMax = Console.WindowHeight - 2;
            screenBuffer = new Dictionary<vector2, char>((xMax * yMax / 2), new vector2HashCode());
            toDisplay = new char[xMax + 1];
        }

        public display(int x, int y)
        {
            xMax = x;
            yMax = y;
            screenBuffer = new Dictionary<vector2, char>((xMax * yMax / 2), new vector2HashCode());
            toDisplay = new char[xMax];
        }

        public bool trySetChar(vector2 pos, char toSet)
        {
            if(screenBuffer.ContainsKey(pos))
            {
                return false;
            }
            else
            {
                screenBuffer.Add(pos, toSet);
                return true;
            }
        }

        public bool clear(vector2 pos)
        {
            return screenBuffer.Remove(pos);
        }

        public void draw(bool doFullDraw)
        {
            if(doFullDraw)
            {
                fullDraw();
            }
            else
            {
                onlyScoreDraw();
            }
        }

        private int drawCounter;
        private int drawAmount = 1000;

        private void onlyScoreDraw()
        {
            if(drawCounter > drawAmount)
            {
                //Console.SetCursorPosition(0, 0);
                drawPoints();
                drawCounter = 0;
            }

            drawCounter++;
        }

        private void fullDraw()
        {
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y <= yMax; y++)
            {
                for (int x = 0; x <= xMax; x++)
                {
                    toDisplay[x] = getChar(x, y);
                }

                Console.WriteLine(toDisplay);
            }
            drawPoints();
        }

        public static void drawPoints()
        {
            Console.WriteLine("Hits/Misses/Bounces: " + Program.hits + "/" + Program.misses + "/" + Program.bounces + " FPS: " + Program.fps + "                       ");
        }

        private vector2 getCache;

        public char getChar(int x, int y)
        {
            getCache.x = x;
            getCache.y = y;

            char toReturn = ' ';

            if(screenBuffer.TryGetValue(getCache, out toReturn))
            {
                return toReturn;
            }
            else
            {
                return toReturn;
            }
        }
    }

    public struct vector2
    {
        public static readonly vector2 zero = new vector2();
        public static readonly vector2 up = new vector2(0, -1);
        public static readonly vector2 down = new vector2(0, 1);
        public static readonly vector2 left = new vector2(-1, 0);
        public static readonly vector2 right = new vector2(1, 0);

        public int x;
        public int y;

        public vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public string toString()
        {
            return x + "," + y;
        }

        public static vector2 add(vector2 v1, vector2 v2)
        {
            return new vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static vector2 fromString(string a, string b)
        {
            int x;
            int y;

            if (!int.TryParse(a, out x))
            {
                x = -1;
            }

            if (!int.TryParse(b, out y))
            {
                y = -1;
            }

            return new vector2(x, y);
        }

        public static vector2 fromString(string line)
        {
            string[] lines = line.Split(',');

            int x;
            int y;

            if (!int.TryParse(lines[0], out x))
            {
                x = -1;
            }

            if (!int.TryParse(lines[1], out y))
            {
                y = -1;
            }

            return new vector2(x, y);
        }

        public int toInt(int width)
        {
            return y * width + x;
        }

        public float dist(vector2 other)
        {
            return (float)Math.Sqrt(Math.Pow(x - other.x, 2) + Math.Pow(y - other.y, 2));
        }

        public static bool Equals(vector2 X, vector2 Y)
        {
            return (X.x == Y.x && X.y == Y.y);
        }

        public bool Equals(vector2 Y)
        {
            return (x == Y.x && y == Y.y);
        }


        public override int GetHashCode()
        {
            return this.x << 16 + (short)this.y;
        }
    }

    public class vector2HashCode : IEqualityComparer<vector2>
    {
        public bool Equals(vector2 X, vector2 Y)
        {
            return (X.x == Y.x && X.y == Y.y);
        }

        public int GetHashCode(vector2 obj)
        {
            return obj.x << 16 + (short)obj.y;
        }
    }

}
