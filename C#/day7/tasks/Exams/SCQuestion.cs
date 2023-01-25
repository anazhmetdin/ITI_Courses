using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams
{
    internal class SMCQuestion: Question
    {
        public Answer TrueAnswer { get; }

        public SMCQuestion(float marks, string header, int correct, params Answer[] choices) : base("Select one answer only", marks, header, choices)
        {
            if (correct < 0 || correct >= Choices.Count)
                throw new ArgumentException("Choice number is out of range");

            TrueAnswer = Choices[correct];
        }

        public override float GradeQuestion(AnswerList studentChoices)
        {
            if (studentChoices == null || studentChoices.Count != 1) return 0f;

            if (TrueAnswer.Equals(studentChoices[0])) return Marks;

            return 0f;
        }

        public override string TrueAnswerString()
        {
            return TrueAnswer.ToString();
        }
    }
}
