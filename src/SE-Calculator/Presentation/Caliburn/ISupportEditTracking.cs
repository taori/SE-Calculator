using System;

namespace Presentation.Caliburn
{
	public interface ISupportEditTracking
	{
		bool IsModified { get; }
		event EventHandler<bool> IsModifiedChanged;
		void ClearEditState();
	}
}