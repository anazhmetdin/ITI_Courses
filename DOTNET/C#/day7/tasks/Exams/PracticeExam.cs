using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams
{
    internal class PracticeExam : Exam
    {
        public PracticeExam(Subject course, DateTime time, int length) : base(course, time, length)
        {
        }

        public PracticeExam(Subject course, DateTime time, params Question[] questions): base(course, time, questions)
        {
        }

        public override void ShowExam()
        {
            base.ShowExam();
            Console.WriteLine("_____________________________________");

            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine(Questions[i]);
                Console.WriteLine($"True Answer:\n{Questions[i].TrueAnswerString()}");
                Console.WriteLine($"Your Answer:");
                foreach (Answer choice in StudentAnswers[Questions[i]])
                {
                    Console.WriteLine(choice);
                }
                Console.WriteLine($"Score: {Grades[i]}");
                Console.WriteLine("_____________________________________");
            }

            Console.WriteLine($"Your Overall Grade {100 * Grade / Mark}");
        }
    }
}
