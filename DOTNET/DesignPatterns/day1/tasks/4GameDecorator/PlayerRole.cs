using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GameDecorator
{
    internal abstract class PlayerRole: Player
    {
        protected Player refer;

        public PlayerRole(Player refer)
        {
            this.refer = refer;
        }
    }
}
