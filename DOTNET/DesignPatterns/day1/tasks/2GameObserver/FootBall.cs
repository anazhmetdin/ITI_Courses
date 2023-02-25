using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GameObserver
{
    internal class FootBall : Ball
    {
        private Position position;
        public Position Position
        {
            get { return position; }
            set
            {
                if (position != value)
                {
                    position = value;
                    NotifyObservers(value);
                }
            }
        }

        public FootBall(Position position)
        {
            this.position = position;
        }
    }
}
