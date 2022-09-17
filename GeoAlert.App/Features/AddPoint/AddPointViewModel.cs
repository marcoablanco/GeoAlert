namespace GeoAlert.App.Features.AddPoint;

using GeoAlert.App.Bases;
using GeoAlert.App.Models;
using GeoAlert.App.Resources.Translations;
using GeoAlert.App.Services.Alert;
using GeoAlert.App.Services.AppLog;
using GeoAlert.App.Services.Geofencing;
using GeoAlert.App.Services.Preferences;
using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;

public class AddPointViewModel : BasePageViewModel
{
	private readonly IAlertService alertService;
	private readonly IGeofencingService geofencingService;
	private readonly IPreferencesService preferencesService;
	private readonly ILogService logService;
	private string name;
	private string shortDescription;
	private string description;
	private double latitude;
	private double longitude;
	private float ratio;
	private bool watchDwell;
	private bool watchExit;
	private bool watchEnter;

	public AddPointViewModel(ILogService logService, IAlertService alertService, IGeofencingService geofencingService, IPreferencesService preferencesService) : base(logService)
	{
		this.logService = logService;
		this.alertService = alertService;
		this.geofencingService = geofencingService;
		this.preferencesService = preferencesService;

		name = string.Empty;
		description = string.Empty;
		shortDescription = string.Empty;

		AddGeofenceCommand = ReactiveCommand.CreateFromTask(AddGeofenceCommandExecuteAsync, IsNotLoadingObservable);
	}

	public string Name
	{
		get => name;
		set => this.RaiseAndSetIfChanged(ref name, value);
	}

	public string ShortDescription
	{
		get => shortDescription;
		set => this.RaiseAndSetIfChanged(ref shortDescription, value);
	}

	public string Description
	{
		get => description;
		set => this.RaiseAndSetIfChanged(ref description, value);
	}

	public double Latitude
	{
		get => latitude;
		set => this.RaiseAndSetIfChanged(ref latitude, value);
	}

	public double Longitude
	{
		get => longitude;
		set => this.RaiseAndSetIfChanged(ref longitude, value);
	}

	public float Ratio
	{
		get => ratio;
		set => this.RaiseAndSetIfChanged(ref ratio, value);
	}

	public bool WatchDwell
	{
		get => watchDwell;
		set => this.RaiseAndSetIfChanged(ref watchDwell, value);
	}

	public bool WatchExit
	{
		get => watchExit;
		set => this.RaiseAndSetIfChanged(ref watchExit, value);
	}

	public bool WatchEnter
	{
		get => watchEnter;
		set => this.RaiseAndSetIfChanged(ref watchEnter, value);
	}

	public ReactiveCommand<Unit, Unit> AddGeofenceCommand { get; }

	public override CompositeDisposable OnActivated(CompositeDisposable disposables)
	{
		base.OnActivated(disposables);

		disposables.Add(AddGeofenceCommand.ThrownExceptions.Subscribe(logService.LogError, logService.LogError));

		return disposables;
	}

	private async Task AddGeofenceCommandExecuteAsync()
	{
		try
		{
			Loading = Text.Adding;
			PointModel? pointModel = ValidateFields();

			if (pointModel is null)
			{
				await alertService.ShowAlertAsync(MainText.AlertTitleError, Text.AlertFields, MainText.AlertAccept);
				return;
			}

			bool result = await alertService.ShowAlertAsync(MainText.AlertTitleWarning, Text.AlertEnsureWantAdd, MainText.AlertOk, MainText.AlertCancel);

			if (!result)
				return;

			await preferencesService.InsertPersonalPointAsync(pointModel);
			await geofencingService.AddGeofencingAsync(pointModel);

			await alertService.ShowAlertAsync(MainText.AlertTitleWarning, Text.AlertAddOk, MainText.AlertAccept);
		}
		catch (Exception ex)
		{
			logService.LogError(ex);
			await alertService.ShowAlertAsync(MainText.AlertTitleError, MainText.AlertMessageError, MainText.AlertAccept);
		}
		finally
		{
			Loading = string.Empty;
		}
	}

	private PointModel? ValidateFields()
	{
		try
		{
			if (string.IsNullOrEmpty(Name))
				return null;

			return new PointModel
			{
				Name = name,
				Category = PointModel.PersonalCategory,
				Description = Description,
				Latitude = Latitude,
				Longitude = Longitude,
				Ratio = Ratio,
				ShortDescription = ShortDescription,
				WatchDwell = WatchDwell,
				WatchEnter = WatchEnter,
				WatchExit = WatchExit
			};

		}
		catch (Exception ex)
		{
			logService.LogError(ex);
			return null;
		}
	}
}
