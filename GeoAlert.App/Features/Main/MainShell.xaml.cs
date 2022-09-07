namespace GeoAlert.App.Features.Main;

public partial class MainShell : Shell
{
	public MainShell()
	{
		InitializeComponent();
	}

	public async Task NavigateToAddPoint()
	{
		await GoToAsync("Points/AddPoints", true);
	}
}
