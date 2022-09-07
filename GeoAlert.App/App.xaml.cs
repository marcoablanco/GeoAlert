namespace GeoAlert.App;

using GeoAlert.App.Features.Main;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainShell();
	}
}
