using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GameDecorator
{
    internal class MiddleField : PlayerRole
    {
        public MiddleField(Player refer) : base(refer) { }

        public void Dribble()
        {
            Console.WriteLine("MiddleField Dribbling");
        }

        public override void PassBall()
        {
            Console.WriteLine("MiddleField passing");
        }
    }
}
