namespace GeoAlert.App.Platforms.Android.Handlers;

using AndroidX.AppCompat.Widget;
using GeoAlert.App.Controls;
using Microsoft.Maui.Handlers;

public class ValidatableEntryControlHandler : EntryHandler
{
	public ValidatableEntryControlHandler() : base()
	{

	}

	protected override void ConnectHandler(AppCompatEditText platformView)
	{
		base.ConnectHandler(platformView);
		Mapper.AppendToMapping("ErrorMapper", (nativeControl, commonControl) =>
		{
			if (commonControl is ValidatableEntryControl validatableEntryControl)
				nativeControl.PlatformView.Error = string.IsNullOrWhiteSpace(validatableEntryControl.ValidationMessage) ? null : validatableEntryControl.ValidationMessage;
		});
	}

	protected override void DisconnectHandler(AppCompatEditText platformView)
	{
		base.DisconnectHandler(platformView);
	}
}
