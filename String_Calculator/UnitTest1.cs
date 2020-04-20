using System;
using System.Collections.Generic;
using System.Linq;
using NUnit;
using NUnit.Framework;

namespace String_Calculator
{
	[TestFixture]
	public class UnitTest1
	{
		[Test]
		public void GivenNumbers_WithBlankSpace_ShouldReturn0()
		{
			//arrange
			var numbers = "";

			//act
			int expected = 0;
			int actual = Add(numbers);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GivenNumbers_WithOneValue_ShouldReturn1()
		{
			//arrange
			var numbers = "1";

			//act
			int expected = 1;
			int actual = Add(numbers);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GivenNumbers_WithTwoValues_ShouldReturn3()
		{
			//arrange
			var numbers = "1,2";

			//act
			int expected = 3;
			int actual = Add(numbers);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GivenNumbers_WithThreeValues_ShouldReturn6()
		{
			//arrange
			var numbers = "1,2,3";

			//act
			int expected = 6;
			int actual = Add(numbers);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GivenNumbers_WithNewLinesBetweenValues_ShouldReturn6()
		{
			//arrange
			var numbers = "1\n2,3";

			//act
			int expected = 6;
			int actual = Add(numbers);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GivenNumbers_WithNewDelimiterValues_ShouldReturn6()
		{
			//arrange
			var numbers = "|1\n2|3";

			//act
			int expected = 6;
			int actual = Add(numbers);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GivenNumbers_WithNegativeValues_ShouldReturnError()
		{
			//arrange
			var numbers = "-1\n-2,-3";

			//assert
			Assert.Throws<Exception>(() => Add(numbers));
		}


		private int Add(string numbers)
		{
			if (string.IsNullOrEmpty(numbers))
				return 0;

			var delimiters = new List<char>() { ',', '\n' };


			if (!char.IsDigit(numbers[0]) && numbers[0] != '-')
				delimiters.Add(numbers[0]);

			var sumOfNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(int.Parse);

			if (sumOfNumbers.Any(num => num < 0))
				throw new Exception($"Negatives Not Allowed : {string.Join(",", sumOfNumbers.Where(num => num < 0))}");

			return sumOfNumbers.Sum();
		}
	}
}
