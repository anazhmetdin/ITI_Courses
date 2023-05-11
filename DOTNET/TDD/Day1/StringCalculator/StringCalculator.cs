using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
	public class StringCalculator
	{
		#region V1
		//public static int Add(string numbers)
		//{
		//	var result = 0;

		//	if (numbers == string.Empty)
		//		return result;

		//	var numsArr = numbers.Split(',');

		//	if (numsArr.Length >= 1 && int.TryParse(numsArr[0], out int num1))
		//	{
		//		result += num1;
		//	}

		//	if (numsArr.Length >= 2 && int.TryParse(numsArr[1], out int num2))
		//	{
		//		result += num2;
		//	}

		//	return result;
		//}
		#endregion

		#region V2
		//public static int Add(string numbers)
		//{
		//	var result = 0;

		//	if (numbers == string.Empty)
		//		return result;

		//	var numsArr = numbers.Split(',');

		//	foreach (var num in numsArr)
		//	{
		//		if (int.TryParse(num, out int numValue))
		//		{
		//			result += numValue;
		//		}
		//	}

		//	return result;
		//}
		#endregion

		#region V3
		//public static int Add(string numbers)
		//{
		//	var result = 0;

		//	if (numbers == string.Empty)
		//		return result;

		//	var numsArr = numbers.Split(new char[] { ',', '\n' });

		//	foreach (var num in numsArr)
		//	{
		//		if (int.TryParse(num, out int numValue))
		//		{
		//			result += numValue;
		//		}
		//	}

		//	return result;
		//}
		#endregion

		#region V4
		public static int Add(string numbers)
		{
			var result = 0;

			if (numbers == string.Empty)
				return result;

			var numsArr = numbers.Split(new char[] { ',', '\n' });

			List<string> negatives = new List<string>();

			foreach (var num in numsArr)
			{
				if (num.StartsWith("-"))
				{
					negatives.Add(num);
				}
				else if (int.TryParse(num, out int numValue))
				{
					result += numValue;
				}
			}

			if (negatives.Count != 0)
			{
				throw new Exception($"Negatives are not allowed: {string.Join(",", negatives)}");
			}

			return result;
		}
		#endregion
	}
}
