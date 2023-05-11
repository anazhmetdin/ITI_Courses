using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CarAPITests
{
	[TestClass]
	public class CarsServiceTests
	{
		private static Mock<ICarsRepository> _carsRepositoryMock;
		private static CarsService _carsService;

		[ClassInitialize]
		public static void CreateOwnerService(TestContext context)
		{
			_carsRepositoryMock = new Mock<ICarsRepository>();
			_carsService = new CarsService(_carsRepositoryMock.Object);
		}

		[TestMethod]
		public void GetCarById_RepoReturnsCarId1_ReturnsCarId1_Mocking()
		{
			// Arrange
			var car = new Car(1, CarType.BMW, 100);
			_carsRepositoryMock.Setup(m => m.GetCarById(1)).Returns(car);

			// Act
			var result = _carsService.GetCarById(1);

			// Assert
			Assert.AreEqual(result, car);
		}
	}
}
