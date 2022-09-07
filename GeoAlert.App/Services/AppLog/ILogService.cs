namespace GeoAlert.App.Services.AppLog;

using System;

public interface ILogService
{
	void LogError(Exception ex);
	void LogLine(string line);
}