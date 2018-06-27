using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    public class ball
    {
        private vector2 pos;
        private vector2 velocity;
        private display d;
        private paddle pd;

        private int skipCounter;

        public ball(display d, int skipAmount, paddle pd)
        {
            this.d = d;
            this.pd = pd;
            skipCounter = skipAmount;
            randomizeBall();
        }

        private int counter = 0;

        public gameState update()
        {
            lastMoveOutcome outcome = lastMoveOutcome.neutral;

            if (counter % skipCounter == 0)
            {
                d.clear(pos);
                vector2 newPos = vector2.add(pos, velocity);

                if (d.screenBuffer.ContainsKey(newPos))
                {
                    outcome = bounce(newPos);
                }
                else
                {
                    if (newPos.y >= d.yMax)
                    {
                        randomizeBall();
                        outcome = lastMoveOutcome.bad;
                    }
                    else
                    {
                        pos = newPos;
                    }
                }

                d.trySetChar(pos, '@');

            }

            counter++;

            switch (outcome)
            {
                case lastMoveOutcome.good:
                    Program.points++;
                    break;
                case lastMoveOutcome.neutral:
                    break;
                case lastMoveOutcome.bad:
                    Program.points--;
                    break;
            }

            return new gameState(pos, velocity, outcome, pd.posCache);
        }

        private void randomizeBall()
        {
            Random r = new Random();

            pos = new vector2(r.Next(1, d.xMax), 1);
            if(r.Next() % 2 == 1)
            {
                velocity.x = 1;
            }
            else
            {
                velocity.x = -1;
            }

            if (r.Next() % 2 == 1)
            {
                velocity.y = 1;
            }
            else
            {
                velocity.y = -1;
            }
        }

        private lastMoveOutcome bounce(vector2 newPos)
        {
            if (newPos.x < 1)
            {
                velocity.x = 1;
                return lastMoveOutcome.neutral;
            }
            else if (newPos.x > d.xMax - 1)
            {
                velocity.x = -1;
                return lastMoveOutcome.neutral;
            }

            if (newPos.y < 1)
            {
                velocity.y = 1;
                return lastMoveOutcome.neutral;
            }
            else if (newPos.y > d.yMax - 1)
            {
                velocity.y = -1;
                return lastMoveOutcome.good;
            }

            return lastMoveOutcome.neutral;
        }
    }
}
