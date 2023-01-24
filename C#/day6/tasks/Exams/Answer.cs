using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams
{
    internal class Answer
    {
        public string Value { get; set; }

        public Answer(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object? obj)
        {
            Answer? answer = obj as Answer;
            if (answer != null)
            {
                return answer.Value == Value;
            }
            return false;
        }
    }
}
