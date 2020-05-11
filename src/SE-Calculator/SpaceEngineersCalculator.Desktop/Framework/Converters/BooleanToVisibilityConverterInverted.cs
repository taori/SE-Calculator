using System.Windows;

namespace SpaceEngineersCalculator.Desktop.Framework.Converters
{
	public class BooleanToVisibilityConverterInverted : BooleanConverter<Visibility>
	{
		public BooleanToVisibilityConverterInverted() : base(Visibility.Collapsed, Visibility.Visible)
		{
		}
	}
}