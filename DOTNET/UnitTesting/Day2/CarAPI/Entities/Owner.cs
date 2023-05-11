namespace CarAPI.Entities
{
    public class Owner
    {

        public int Id { get; }

        public string Name { get; set; }
        public Car Car { get; set; }

        public Owner(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Owner()
        {

        }

		public override bool Equals(object obj)
		{
            if (obj == null) return false;
            if (obj is Owner owner)
            {
                return Id == owner.Id && Name == owner.Name;
            }
            return false;
		}
	}
}