namespace Exams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new("C#", "Introduction to C# syntax and new programming concepts");

            Answer[] answers1 = new Answer[4] 
            {
                new Answer("false answer"),
                new Answer("true answer"),
                new Answer("true answer"),
                new Answer("false answer")
            };

            Question question1 = new MCQuestoin(4, "MCQ Question Body", new int[2] {1, 2}, answers1);

            Answer[] answers2 = new Answer[4]
            {
                new Answer("false answer"),
                new Answer("false answer"),
                new Answer("true answer"),
                new Answer("false answer")
            };

            Question question2 = new SMCQuestion(1, "SMCQ Question Body", 2, answers2);

            Question question3 = new TFQuestion(1, "TF Question Body", true);

            Exam practiceExam = new PracticeExam(subject, DateTime.Now, question1, question2, question3);
            Exam final = new FinalExam(subject, DateTime.Now, question1, question2, question3);

            Console.WriteLine("practice or final?");
            if (Console.ReadLine() == "final")
            {
                final.ShowExam();
            }
            else
            {
                practiceExam.ShowExam();
            }
        }
    }
}