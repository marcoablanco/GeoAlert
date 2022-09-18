namespace GeoAlert.App.Controls;

public class ValidatableEntryControl : Entry
{
	public static readonly BindableProperty ValidationMessageProperty = BindableProperty.Create(nameof(ValidationMessage), typeof(string), typeof(ValidatableEntryControl), string.Empty);


	public string ValidationMessage
	{
		get => (string)GetValue(ValidationMessageProperty);
		set => SetValue(ValidationMessageProperty, value);
	}
}
