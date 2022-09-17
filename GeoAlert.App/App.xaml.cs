namespace GeoAlert.App;

using GeoAlert.App.Features.Main;

public partial class App : Application
{
	public App(MainShell mainShell)
	{
		InitializeComponent();

		MainPage = mainShell;
	}
}
