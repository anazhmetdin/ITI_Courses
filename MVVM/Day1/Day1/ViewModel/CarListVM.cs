using Day1.Command;
using Day1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Day1.ViewModel
{
	public class CarListVM
	{
		public ObservableCollection<Car>  CarList { get; set; }
		public ICommand AddCar { get; set; }
		public Car Car { get; set; } = new Car();

		public CarListVM()
		{
			AddCar = new AddCarCommand(_AddCar, _CanAddCar);

			CarList = new()
			{
				new Car() { Id = 1, Manufacture = "Ford", Model = "Mustang", Color = "Red", Price = 35000 },
				new Car() { Id = 2, Manufacture = "Chevrolet", Model = "Corvette", Color = "Blue", Price = 45000 },
				new Car() { Id = 3, Manufacture = "Toyota", Model = "Camry", Color = "White", Price = 25000 },
				new Car() { Id = 4, Manufacture = "Honda", Model = "Accord", Color = "Black", Price = 28000 },
				new Car() { Id = 5, Manufacture = "BMW", Model = "M5", Color = "Silver", Price = 60000 },
				new Car() { Id = 6, Manufacture = "Mercedes-Benz", Model = "S-Class", Color = "Black", Price = 80000 },
				new Car() { Id = 7, Manufacture = "Audi", Model = "R8", Color = "Yellow", Price = 120000 },
				new Car() { Id = 8, Manufacture = "Porsche", Model = "911", Color = "Green", Price = 90000 },
			};
		}

		private void _AddCar(object newCar)
		{
			var car = (Car) newCar;

			car.Id = CarList.Count + 1;
			CarList.Add(car);

			MessageBox.Show("Car Added Succesfully");
		}

		private bool _CanAddCar(object? newCar)
		{
			return newCar is Car car && car != null;
		}
	}
}
