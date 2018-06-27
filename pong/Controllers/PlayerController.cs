using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong.Controllers
{
    public class PlayerController : iController
    {
        public vector2 getMove(gameState state)
        {
            int xMove = 0;

            if(Program.i.IsKeyHeld(OpenTK.Input.Key.A))
            {
                xMove--;
            }
            
            if(Program.i.IsKeyHeld(OpenTK.Input.Key.D))
            {
                xMove++;
            }

            return new vector2(xMove, 0);
        }
    }
}
