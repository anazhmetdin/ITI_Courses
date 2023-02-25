using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GameDecorator
{
    internal class Defender : PlayerRole
    {
        public Defender(Player refer) : base(refer) { }

        public void Defend()
        {
            Console.WriteLine("Defender Defending");
        }
    }
}
