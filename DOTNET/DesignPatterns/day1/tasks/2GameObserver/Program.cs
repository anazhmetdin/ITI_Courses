namespace _2GameObserver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FootBall fb = new(new(1,2,3));

            Player p1 = new("player1", fb);
            Referee r1 = new("ref1", fb);

            fb.AttachObserver(p1);
            fb.AttachObserver(r1);

            fb.Position = new(1,0,0);
        }
    }
}