namespace GeoAlert.App.Services.Alert;

using System.Threading.Tasks;

public interface IAlertService
{
	Task ShowAlertAsync(string title, string message);
	Task ShowAlertAsync(string title, string message, string cancel);
	Task<bool> ShowAlertAsync(string title, string message, string ok, string cancel);
}