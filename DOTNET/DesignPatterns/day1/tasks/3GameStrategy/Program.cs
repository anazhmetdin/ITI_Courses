namespace _3GameStrategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Team team = new("team1");
            team.play();

            team.Strategy = new AttackStrategy();
            team.play();
        }
    }
}