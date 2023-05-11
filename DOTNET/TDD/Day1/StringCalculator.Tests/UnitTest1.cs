namespace StringCalculator.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Add_EmptyString_ReturnsZero()
		{
			// Arrange
			var empty = string.Empty;

			// Act
			var result = StringCalculator.Add(empty);

			// Assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Add_StringOneNumber_ReturnsSameNumber()
		{
			// Arrange
			var oneNumber = "5";

			// Act
			var result = StringCalculator.Add(oneNumber);

			// Assert
			Assert.AreEqual(5, result);
		}

		[TestMethod]
		public void Add_StringTwoNumbers5And4_Returns9()
		{
			// Arrange
			var TwoNumbers = "5,4";

			// Act
			var result = StringCalculator.Add(TwoNumbers);

			// Assert
			Assert.AreEqual(9, result);
		}

		[TestMethod]
		public void Add_StringNumbers5_4_7_10_4_Returns30()
		{
			// Arrange
			var numbers = "5,4,7,10,4";

			// Act
			var result = StringCalculator.Add(numbers);

			// Assert
			Assert.AreEqual(30, result);
		}

		[TestMethod]
		public void Add_StringNumbers1newLine2_3_Returns6()
		{
			// Arrange
			var numbers = "1\n2,3";

			// Act
			var result = StringCalculator.Add(numbers);

			// Assert
			Assert.AreEqual(6, result);
		}

		[TestMethod]
		public void Add_StringNumbersWithNegatives2_4_ThrowsExceptionWithNegatives()
		{
			// Arrange
			var numbers = "1\n2,-2,3\n-4";
			var message = "Negatives are not allowed: -2,-4";
			
			// Act
			// Assert
			var ex = Assert.ThrowsException<Exception>(() => StringCalculator.Add(numbers));
			Assert.AreEqual(message, ex.Message);
		}
	}
}