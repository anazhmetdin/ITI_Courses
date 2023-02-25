using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GameObserver
{
    internal class Referee: IObserver<Position>
    {
        public string Name { get; set; }
        private Position? ballPosition;
        private FootBall footBall;

        public Referee(string name, FootBall footBall)
        {
            Name = name;
            this.footBall = footBall;
            ballPosition = footBall.Position;
        }
        public void OnCompleted()
        {
            Console.WriteLine($"{Name}: referee ball position changed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"{Name}: referee ball position didn't update");
        }

        public void OnNext(Position position)
        {
            ballPosition = position;
        }
    }
}
