using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GameDecorator
{
    internal class FieldPlayer: Player
    {
        public override void PassBall()
        {
            Console.WriteLine("Field player passing");
        }
    }
}
