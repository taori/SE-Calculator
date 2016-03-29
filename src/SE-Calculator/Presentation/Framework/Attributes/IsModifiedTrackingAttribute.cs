using System;

namespace Presentation.Framework.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class IsModifiedTrackingAttribute : Attribute
	{
	}
}