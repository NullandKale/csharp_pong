using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong.Controllers
{
    public class PerfectAiHybrid : iController
    {
        private PlayerController pc = new PlayerController();
        private PerfectAI ai = new PerfectAI();

        public vector2 getMove(gameState state)
        {
            vector2 toReturn = pc.getMove(state);

            if (!toReturn.Equals(vector2.zero))
            {
                return toReturn;
            }
            else
            {
                return ai.getMove(state);
            }
        }
    }
}
