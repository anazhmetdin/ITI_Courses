using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams
{
    internal class TFQuestion : SMCQuestion
    {
        public static Answer _true { get; } = new Answer("True");
        public static Answer _false { get; } = new Answer("False");

        public TFQuestion(float marks, string header, bool correct) : base(marks, header, correct?0:1, _true, _false)
        {
        }
    }
}
