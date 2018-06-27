using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    public class gameBoard
    {
        private display d;
        private bool isInitialized;

        public gameBoard(display d)
        {
            this.d = d;
            isInitialized = false;
        }

        public void update()
        {
            if(isInitialized)
            {

            }
            else
            {
                drawWalls();
                isInitialized = true;
            }
        }

        private void drawWalls()
        {
            vector2 topRow = new vector2(0, 0);

            for(int x = 1; x < d.xMax; x++)
            {
                topRow.x = x;

                if(!d.trySetChar(topRow, '='))
                {
                    Log.e("Failed to SetChar");
                }
            }

            vector2 leftRow = new vector2(0, 0);
            vector2 rightRow = new vector2(d.xMax, 0);

            for (int y = 0; y < d.yMax; y++)
            {
                leftRow.y = y;

                if (!d.trySetChar(leftRow, '|'))
                {
                    Log.e("Failed to SetChar");
                }

                rightRow.y = y;

                if (!d.trySetChar(rightRow, '|'))
                {
                    Log.e("Failed to SetChar");
                }
            }
        }
    }
}
