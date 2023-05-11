using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAPITests
{
	/// <summary>
	/// Summary description for CarsRepoTests
	/// </summary>
	[TestClass]
	public class OwnersRepositoryTests
	{
		[ClassInitialize]
		public static void CreateOwnerRepository(TestContext context)
		{
			_inMemoryContext = new Mock<InMemoryContext>();

			_inMemoryContext.Setup(x => x.Owners).Returns(new List<Owner>()
			{
				new Owner(1, "Ahmed"),
				new Owner(2, "Hagar"),
				new Owner(3, "Ali"),
				new Owner(4, "Waleed"),
			});

			_ownersRepository = new OwnersRepository(_inMemoryContext.Object);
		}

		private static Mock<InMemoryContext> _inMemoryContext;
		private static OwnersRepository _ownersRepository;

		[TestMethod]
		public void GetOwnerById_OwnerId1_ReturnOwner1_Mocking()
		{
			// Arrange           
			var owner = new Owner(1, "Ahmed");

			// Act
			var result = _ownersRepository.GetOwnerById(owner.Id);

			// Assert
			Assert.AreEqual(result, owner);
		}

		[TestMethod]

		public void AddOwner_AddId1_RetaurnFalse_Mocking()
		{
			// Arrange           
			var owner = new Owner(1, "Test");

			// Act
			var result = _ownersRepository.AddOwner(owner);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]

		public void GetAllOwners_ContainsOwner1_RetaurnTrue_Mocking()
		{
			// Arrange           
			var owner = new Owner(1, "Ahmed");

			// Act
			var result = _ownersRepository.GetAllOwners();

			// Assert
			CollectionAssert.Contains(result, owner);
		}
	}
}
