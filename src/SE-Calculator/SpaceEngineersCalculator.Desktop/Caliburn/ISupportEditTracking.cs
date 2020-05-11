using System;

namespace SpaceEngineersCalculator.Desktop.Caliburn
{
	public interface ISupportEditTracking
	{
		bool IsModified { get; }
		event EventHandler<bool> IsModifiedChanged;
		void ClearEditState();
	}
}