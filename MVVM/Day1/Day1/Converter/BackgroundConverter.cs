using Day1.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Day1.Converter
{
	internal class BackgroundConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			decimal range1Max = 30000;
			decimal range2Max = 70000;

			if (value is decimal price)
			{
				if (price <= range1Max)
				{
					return "#74B3CE";
				}
				else if (price <= range2Max)
				{
					return "#A5A5A5";
				}
				else
				{
					return "#D76E6E";
				}
			}

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
