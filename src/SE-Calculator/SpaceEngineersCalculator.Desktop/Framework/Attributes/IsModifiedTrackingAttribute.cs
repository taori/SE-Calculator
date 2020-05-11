using System;

namespace SpaceEngineersCalculator.Desktop.Framework.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class IsModifiedTrackingAttribute : Attribute
	{
	}
}