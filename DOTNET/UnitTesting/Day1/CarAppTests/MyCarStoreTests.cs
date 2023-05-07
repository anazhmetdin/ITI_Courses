using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppTests
{
    [TestClass]
    public class MyCarStoreTests
    {


        #region Collection Assert
        [TestMethod]
        public void GetAllStoreCars_NotEqualCars_NotEqual()
        {
            // Arrange
            var car1 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.Audi, 0, DrivingMode.Reverse);
            var carStore1 = new CarStore(new List<Car> { car1, car2});
            
            var car3 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car4 = new Car(CarType.Audi, 100, DrivingMode.Reverse);
            var carStore2 = new CarStore(new List<Car> { car3, car4});

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreNotEqual(store2Cars, store1Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_ContainDifferentCars_DoesNotContain()
        {
            // Arrange
            var car1 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.Audi, 0, DrivingMode.Reverse);
            var carStore1 = new CarStore(new List<Car> { car1, car2});

			var car3 = new Car(CarType.Audi, 100, DrivingMode.Reverse);

			// Act
			var store1Cars = carStore1.GetAllStoreCars();

            // Assert
            CollectionAssert.DoesNotContain(store1Cars, car3);
        }
        #endregion

        #region Assert
        [TestMethod]
        public void GetAllStoreCars_SameCarsDiffenrent_NotSameCollections()
        {
            // Arrange
            var car1 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.Audi, 0, DrivingMode.Reverse);
            var carStore1 = new CarStore(new List<Car> { car1, car2 });

            var car3 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var carStore2 = new CarStore(new List<Car> { car3, car1 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            Assert.AreNotSame(store2Cars, store1Cars);
        } 
        #endregion
    }
}
