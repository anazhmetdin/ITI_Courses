using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams
{
    internal class QuestionList: List<Question>
    {
        new public void Add(Question question)
        {
            base.Add(question);

            using (StreamWriter oFile = File.AppendText(GetHashCode() + ".txt"))
            {
                oFile.WriteLine(question);
            }
        }
    }
}
