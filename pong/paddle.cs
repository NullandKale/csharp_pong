using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    public class paddle
    {
        private display d;
        private int width;
        private int pos;
        public vector2 posCache;

        private int skipAmount;
        private int counter;

        public paddle(int width, display d, int skipAmount)
        {
            this.d = d;
            this.width = width;
            this.skipAmount = skipAmount;
            pos = d.xMax / 2;
            posCache = new vector2(pos, d.yMax);
        }

        public void reDraw(vector2 move)
        {
            if (counter % skipAmount == 0)
            {
                if (width > 1)
                {
                    clearPaddle();
                    tryMove(pos + move.x);
                    setPaddle();
                }
                else
                {
                    d.clear(posCache);
                    tryMove(pos + move.x);
                    d.trySetChar(posCache, '=');
                }
            }
            else
            {

            }

            counter++;
        }

        private bool tryMove(int newPos)
        {
            if(newPos > width && newPos <= d.xMax - width)
            {
                pos = newPos;
                posCache.x = pos;
                return true;
            }

            return false;
        }

        private int startPos;
        private int endPos;

        private void clearPaddle()
        {
            startPos = pos - width;
            endPos = pos + width;

            for(int i = startPos; i <= endPos; i++)
            {
                d.clear(new vector2(i, d.yMax));
            }
        }

        private void setPaddle()
        {
            startPos = pos - width;
            endPos = pos + width;

            for (int i = startPos; i <= endPos; i++)
            {
                d.trySetChar(new vector2(i, d.yMax), '=');
            }
        }
    }
}
