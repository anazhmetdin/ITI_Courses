using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams
{
    internal abstract class Question
    {
        public string Body { get; set; }
        public float Marks { get; set; }
        public string Header { get; set; }

        public AnswerList Choices { get; }

        public Question(string header, float marks, string body, params Answer[] choices)
        {
            Body = body;
            Marks = marks;
            Header = header;
            Choices = new();
            foreach (Answer answer in choices)
            {
                Choices.Add(answer);
            }
        }

        public override string ToString()
        {
            string question = $"{Header}\n\t{Body}\t({Marks} Marks)\n";
            for (int i = 0; i < Choices.Count; i++)
            {
                question += $"\t{(char)(97+i)}) {Choices[i]}\n";
            }
            return question;
        }

        public abstract float GradeQuestion(AnswerList studentChoices);
        public abstract string TrueAnswerString();
    }
}
