using System;

namespace SpaceEngineersCalculator.Desktop.Extensions
{
	public static class MathHelper
	{
		public static int Clamp(this int value, int min, int max)
		{
			return Math.Max(min, Math.Min(max, value));
		}

		public static double Clamp(this double value, double min, double max)
		{
			return Math.Max(min, Math.Min(max, value));
		}

		public static byte Clamp(this byte value, byte min, byte max)
		{
			return Math.Max(min, Math.Min(max, value));
		}

		public static float Clamp(this float value, float min, float max)
		{
			return Math.Max(min, Math.Min(max, value));
		}

		public static decimal Clamp(this decimal value, decimal min, decimal max)
		{
			return Math.Max(min, Math.Min(max, value));
		}

		public static long Clamp(this long value, long min, long max)
		{
			return Math.Max(min, Math.Min(max, value));
		}

		public static sbyte Clamp(this sbyte value, sbyte min, sbyte max)
		{
			return Math.Max(min, Math.Min(max, value));
		}

		public static short Clamp(this short value, short min, short max)
		{
			return Math.Max(min, Math.Min(max, value));
		}

		public static ushort Clamp(this ushort value, ushort min, ushort max)
		{
			return Math.Max(min, Math.Min(max, value));
		}

		public static ulong Clamp(this ulong value, ulong min, ulong max)
		{
			return Math.Max(min, Math.Min(max, value));
		}
	}
}