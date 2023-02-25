using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3GameStrategy
{
    internal class Team
    {
        public string Name { get; set; }
        public TeamStrategy Strategy { get; set; }

        public Team(string name)
        {
            Name = name;
            Strategy = new DefendStrategy();
        }

        public void play()
        {
            Strategy.play();
        }
    }
}
