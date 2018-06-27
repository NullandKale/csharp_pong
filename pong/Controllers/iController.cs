using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    public interface iController
    {
        vector2 getMove(gameState state);
    }

    public struct gameState
    {
        public vector2 ballPos;
        public vector2 ballVelocity;
        public lastMoveOutcome outcome;
        public vector2 paddlePos;

        public gameState(vector2 ballPos, vector2 ballVelocity, lastMoveOutcome outcome, vector2 paddlePos)
        {
            this.ballPos = ballPos;
            this.ballVelocity = ballVelocity;
            this.outcome = outcome;
            this.paddlePos = paddlePos;
        }
    }

    public enum lastMoveOutcome
    {
        good,
        neutral,
        bad
    }
}
