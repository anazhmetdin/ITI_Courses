using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GameDecorator
{
    internal class Forward : PlayerRole
    {
        public Forward(Player refer): base(refer) { }

        public void ShootGoal()
        {
            Console.WriteLine("Forward Shooting");
        }

        public override void PassBall()
        {
            Console.WriteLine("Forward passing");
            refer.PassBall();
        }
    }
}
