using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong.Controllers
{
    public class PerfectAI : iController
    {
        private vector2 lastVelocity;
        private vector2 lastDest;

        public vector2 getMove(gameState state)
        {
            if(state.ballVelocity.y > 0)
            {
                vector2 dest = getDest(state);
                if(state.paddlePos.x > dest.x)
                {
                    return vector2.left;
                }
                else if(state.paddlePos.x < dest.x)
                {
                    return vector2.right;
                }
            }

            return vector2.zero;
        }

        public vector2 getDest(gameState state)
        {
            vector2 toReturn = state.ballPos;

            while(toReturn.y < state.paddlePos.y)
            {
                toReturn = vector2.add(toReturn, state.ballVelocity);
            }

            return toReturn;
        }
    }
}
