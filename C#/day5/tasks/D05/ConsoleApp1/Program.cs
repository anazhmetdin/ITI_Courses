namespace ConsoleApp1
{
    enum CardType
    {
        Ethernet, TokenRing
    }

    class NIC
    {
        public string Manufacture { get; init; } = "DELL";
        public string MAC { get; init; } = "00:00:00:00";
        public string Adress { get; set; } = "0.0.0.0";
        public CardType Type { get; init; } = CardType.Ethernet;

        public static NIC Card { get; } = new NIC();

        private NIC() { }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            NIC card = NIC.Card;

            Console.WriteLine(card.Manufacture);
        }
    }
}