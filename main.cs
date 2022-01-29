using System;
using System.Collections.Generic;
using System.Text;

namespace unityclass
{
  
    class main
    {
        static void Main()
         {
            Game game = new Game();

            while(true)
            {
                game.Process();
            }
         }
    }
}
