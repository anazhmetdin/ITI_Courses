namespace _4GameDecorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player fieldPlayer = new FieldPlayer();

            fieldPlayer = new Forward(fieldPlayer);

            fieldPlayer.PassBall();
            if (fieldPlayer is Forward fwd)
            {
                fwd.ShootGoal();
            }

            Console.WriteLine("--------------");

            Player goalkeeper = new GoalKeeper();

            goalkeeper = new Defender(goalkeeper);

            goalkeeper.PassBall();
            if (goalkeeper is Defender df)
            {
                df.Defend();
            }
        }
    }
}