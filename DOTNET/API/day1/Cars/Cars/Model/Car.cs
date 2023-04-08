namespace Cars.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        [PastDate]
        public DateTime ProductionDate { get; set; }
        public String? Type { get; set; }

        public static List<Car> Cars = new List<Car>()
        {
            new Car() { Id = 1, Model = "Honda Civic", ProductionDate = new DateTime(2023,1,1)},
            new Car() { Id = 2, Model = "Toyota Corolla", ProductionDate = new DateTime(2023,2,1)},
        };
    }
}
