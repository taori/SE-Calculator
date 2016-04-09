using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Presentation.Extensions;

namespace Presentation.Framework.Converters
{
	public class ColorTintConverter : IValueConverter
	{
		public int AlphaPercent { get; set; } = 100;

		public int RedPercent { get; set; } = 100;

		public int BluePercent { get; set; } = 100;

		public int GreenPercent { get; set; } = 100;

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var scb = value as SolidColorBrush;
			if (scb != null)
			{
				return new SolidColorBrush(new Color()
				{
					R = TintValue(AlphaPercent, scb.Color.R),
					G = TintValue(AlphaPercent, scb.Color.G),
					B = TintValue(AlphaPercent, scb.Color.B),
					A = TintValue(AlphaPercent, scb.Color.A)
				});
			}

			return value;
		}

		private byte TintValue(int percentValue, byte byteValue)
		{
			var calcPercent = Math.Max(0, Math.Min(100, percentValue))*0.01;
			// 0-100
			var currentByteValue = ((float) 100/(float) 255)*(float) Math.Max(byteValue, (byte) 1);
			var newAlphaPercent = calcPercent*currentByteValue;
			var newAlphaCalc = (currentByteValue + newAlphaPercent)*0.01;
			var newAlphaValue = (byte) (255*newAlphaCalc).Clamp(0, 255);
			return newAlphaValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
