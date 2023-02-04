using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams
{
    internal class MCQuestoin: Question
    {
        public Answer[] TrueAnswer { get; private set; }

        public MCQuestoin(float marks, string header, int[] correct, params Answer[] choices) : base("Select all that apply  (x,y,...)", marks, header, choices)
        {
            TrueAnswer = new Answer[correct.Length];
            SetTrueAnswers(correct);
        }

        private void SetTrueAnswers(int[] correct)
        {
            if (correct == null || correct.Length > Choices.Length || correct.Length == 0)
            {
                throw new ArgumentException("Wrong list of correct answers");
            }

            for (int c = 0; c < correct.Length; c++)
            {
                if (correct[c] < 0 || correct[c] >= Choices.Length)
                {
                    throw new ArgumentException("Wrong list of correct answers");
                }

                TrueAnswer[c] = Choices[correct[c]];
            }
        }

        public override float GradeQuestion(params Answer[] studentChoices)
        {
            if (studentChoices == null || studentChoices.Length > TrueAnswer.Length) return 0f;
            
            float score = 0f;

            bool found;
            foreach (Answer correct in TrueAnswer)
            {
                found = false;
                for (int i = 0; i < studentChoices.Length && !found; i++)
                {
                    found = studentChoices[i] == correct;
                }

                if (found)
                {
                    score += Marks / TrueAnswer.Length;
                }
            }

            return score;
        }

        public override string TrueAnswerString()
        {
            string result = string.Empty;

            foreach(Answer answer in TrueAnswer)
            {
                result += (answer.ToString() + "\n");
            }

            return result.Trim();
        }
    }
}
