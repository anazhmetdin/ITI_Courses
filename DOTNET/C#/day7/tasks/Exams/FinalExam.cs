using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams
{
    internal class FinalExam : Exam
    {
        public FinalExam(Subject course, DateTime time, int length) : base(course, time, length)
        {
        }

        public FinalExam(Subject course, DateTime time, params Question[] questions) : base(course, time, questions)
        {
        }

        public override void ShowExam()
        {
            base.ShowExam();

            Console.WriteLine("_____________________________________");
            Console.WriteLine($"Grade: {100 * Grade / Mark}");
        }
    }
}
