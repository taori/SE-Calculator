using System.Windows;

namespace Presentation.Framework.Converters
{
	public class BooleanToVisibilityConverterInverted : BooleanConverter<Visibility>
	{
		public BooleanToVisibilityConverterInverted() : base(Visibility.Collapsed, Visibility.Visible)
		{
		}
	}
}