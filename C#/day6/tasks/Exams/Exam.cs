using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams
{
    internal abstract class Exam
    {
        public Subject Course { get; set; }
        public DateTime Time { get; }
        public int Length { get; }
        public Question[] Questions { get; }
        public Answer[][] StudentAnswers { get; }
        public float[] Grades { get; private set; }
        public float Grade { get; private set; }
        protected float Mark;

        public Exam(Subject course,DateTime time, int length)
        {
            Course = course;
            Time = time;
            Length = length;
            Questions = new Question[length];
            StudentAnswers = new Answer[length][];
            Grades = new float[length];
            Grade = 0f;
            Mark = 0f;
        }

        public Exam(Subject course, DateTime time, params Question[] questions): this(course, time, questions.Length)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                Questions[i] = questions[i];
                Mark += Questions[i].Marks;
            }
        }

        public virtual void ShowExam()
        {
            string? choice;
            string[] choices;
            int choiceIndex;
            bool parsed;

            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"{i+1}. {Questions[i]}");

                parsed = true;

                do
                {
                    Console.WriteLine("\nEnter your choice(s)");
                    choice = Console.ReadLine();

                    if (choice != null)
                    {
                        choices = choice.Split(',');

                        StudentAnswers[i] = new Answer[choices.Length];

                        for (int j = 0; j < choices.Length && parsed; j++)
                        {
                            choiceIndex = choices[j][0] - 97;
                            if (choiceIndex >= 0 && choiceIndex < Questions[i].Choices.Length)
                            {
                                StudentAnswers[i][j] = Questions[i].Choices[choiceIndex];
                            }
                            else
                            {
                                parsed = false;
                            }
                        }
                    }

                } while (!parsed);

                Grades[i] = Questions[i].GradeQuestion(StudentAnswers[i]);
                Grade += Grades[i];

                Console.WriteLine("_____________________________________");
                Console.WriteLine();
            }
        }
    }
}
