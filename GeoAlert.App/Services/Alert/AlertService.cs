namespace GeoAlert.App.Services.Alert;

using GeoAlert.App.Resources.Translations;
using System;
using System.Threading.Tasks;

internal class AlertService : IAlertService
{
	public async Task ShowAlertAsync(string title, string message)
	{
		Page currentPage = GetCurrentPage();
		await currentPage.DisplayAlert(title, message, MainText.AlertAccept);
	}
	public async Task ShowAlertAsync(string title, string message, string cancel)
	{
		Page currentPage = GetCurrentPage();
		await currentPage.DisplayAlert(title, message, cancel);
	}

	public async Task<bool> ShowAlertAsync(string title, string message, string ok, string cancel)
	{
		Page currentPage = GetCurrentPage();
		return await currentPage.DisplayAlert(title, message, ok, cancel);
	}

	private Page GetCurrentPage()
	{
		Page? page = Application.Current?.MainPage;
		if (page is null)
			throw new NotSupportedException("Can't access to current page.");
		return page;
	}
}
