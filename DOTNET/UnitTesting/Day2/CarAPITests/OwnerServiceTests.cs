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
	public class OwnerServiceTests
	{
		private static Mock<IOwnersRepository> _ownersRepositoryMock;
		private static Mock<ICarsRepository> _carsRepositoryMock;
		private static Mock<IPaymentService> _paymentServiceMock;
		private static OwnersService _ownersService;

		[ClassInitialize]
		public static void CreateOwnerService(TestContext context)
		{
			_ownersRepositoryMock = new Mock<IOwnersRepository>();
			_carsRepositoryMock = new Mock<ICarsRepository>();
			_paymentServiceMock = new Mock<IPaymentService>();
			_ownersService = new OwnersService(_ownersRepositoryMock.Object, _carsRepositoryMock.Object, _paymentServiceMock.Object);
		}

		[TestMethod]
		public void BuyCar_NotFoundCarId10_PrintDoesntExist_Mocking()
		{
			// Arrange           
			var input = new BuyCarInput()
			{
				Amount = 200,
				CarId = 10,
				OwnerId = 1
			};

			_carsRepositoryMock.Setup(m => m.GetCarById(input.CarId)).Returns<Car>(null);
			var expected = "Car doesn't exist";

			// Act
			var result = _ownersService.BuyCar(input);

			// Assert
			StringAssert.Contains(result, expected);
		}

		[TestMethod]
		public void BuyCar_ZeroMoney_PrintAmountShouldBePositive_Mocking()
		{
			// Arrange           
			var input = new BuyCarInput()
			{
				Amount = 0,
				CarId = 1,
				OwnerId = 1
			};
			var car = new Car(input.CarId, CarType.Audi, 0);
			var owner = new Owner(input.OwnerId, "Moustafa");
			_ownersRepositoryMock.Setup(m => m.GetOwnerById(input.OwnerId)).Returns(owner);
			_carsRepositoryMock.Setup(m => m.GetCarById(input.CarId)).Returns(car);
			_paymentServiceMock.Setup(m => m.Pay(input.Amount)).Returns("");
			var expected = "Amount should be positive";

			// Act
			var result = _ownersService.BuyCar(input);

			// Assert
			StringAssert.Contains(result, expected);
		}
	}
}
