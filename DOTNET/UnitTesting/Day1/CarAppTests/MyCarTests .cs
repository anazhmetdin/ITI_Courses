using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarAppTests
{
    [TestClass]
    public class MyCarTests
    {

        #region Initialize
        public TestContext TestContext { get; set; }
        #endregion

        #region Assert

        [TestMethod]
        public void TimeToCoverProvidedDistance_Distance0Velocity25_Time0()
        {
            // Arrange
            Car car = new Car
            {
                Velocity = 25
            };
            double distance = 0;
            double expectedResult = 0;

            // Act
            double actualResult = car.TimeToCoverProvidedDistance(distance);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]

        public void DrivingMode_SetDifferentState_EqualNewState()
        {
            // Arrange
            Car car1 = new Car(CarType.Audi, 100, DrivingMode.Forward);

            // Act
            car1.DrivingMode = DrivingMode.Reverse;

            // Assert
            Assert.AreEqual(car1.DrivingMode, DrivingMode.Reverse);
        }

        [TestMethod]
        public void Accelerate_NotEqualInitialVelcity_120()
        {
            // Arrange
            Car car1 = new Car(CarType.Audi, 100, DrivingMode.Forward);

            // Act
            car1.Accelerate();

            // Assert
            Assert.AreEqual(car1.Velocity, 120);
        }
		#endregion


		#region String Assert
		[TestMethod]
        public void DefaultDrivingMode_Stopped_PrintStopped()
        {
			// Arrange
			var car = new Car();

			// Act
            var result = car.GetDirection();

			// Assert
            StringAssert.Matches(result, new System.Text.RegularExpressions.Regex("Stopped"));
        }


		[TestMethod]
		public void GetDirection_Reverse_PrintReverse()
		{
			// Arrange
			var car = new Car()
            {
                DrivingMode = DrivingMode.Reverse,
            };

			// Act
			var result = car.GetDirection();

			// Assert
			StringAssert.Matches(result, new System.Text.RegularExpressions.Regex("Reverse"));
		}
		#endregion
	}
}
