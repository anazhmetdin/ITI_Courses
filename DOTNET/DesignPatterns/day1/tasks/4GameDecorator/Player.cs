using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GameDecorator
{
    internal abstract class Player
    {
        public virtual void PassBall()
        {
            Console.WriteLine("player passing");
        }
    }
}
