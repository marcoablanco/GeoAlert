namespace GeoAlert.App.Services.AppLog;

using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

internal class LogService : ILogService
{
	private ObservableCollection<string> log;
	private int i = 0;

	public LogService()
	{
		log = new ObservableCollection<string>();
	}


	public virtual void LogLine(string line)
	{
		log.Add($"{i++:D6}:{DateTime.UtcNow} {line}");
	}

	public void LogError(Exception ex)
	{
		Debug.WriteLine(ex.ToString());
		log.Add(ex.Message);
		Crashes.TrackError(ex, GetDeviceDataAndExceptionData(ex), ErrorAttachmentLog.AttachmentWithText(GetLog(), $"Log{DateTime.UtcNow.ToString("s")}.log"));
	}

	private string GetLog()
	{
		StringBuilder sb = new StringBuilder();

		Dictionary<string, string> deviceProperties = GetDeviceProperties(new Dictionary<string, string>());
		foreach (KeyValuePair<string, string> item in deviceProperties)
		{
			sb.AppendLine($"{item.Key}: {item.Value}");
		}

		foreach (string item in log)
		{
			sb.AppendLine($"{item}");
		}
		return sb.ToString();
	}

	private Dictionary<string, string> GetDeviceDataAndExceptionData(Exception ex)
	{
		Dictionary<string, string> dict = new Dictionary<string, string>();
		dict = GetDeviceProperties(dict);
		dict.Add("EXCEPTION INFORMATION", GetExceptionData(ex));
		return dict;
	}

	private string GetExceptionData(Exception ex, string title = "EXCEPTION")
	{
		if (ex == null)
		{
			return string.Empty;
		}
		StringBuilder st = new StringBuilder();
		st.AppendLine($"--{title}--");
		st.AppendLine($"MESSAGE: {ex.Message}");
		st.AppendLine($"TOSTRING: {ex.ToString()}");
		st.AppendLine($"STACKTRACE: {ex.StackTrace}");
		if (ex.InnerException != null)
		{
			st.AppendLine(GetExceptionData(ex.InnerException, "INNER EXCEPTION"));
		}
		return st.ToString();
	}

	private Dictionary<string, string> GetDeviceProperties(Dictionary<string, string> properties)
	{
#if DEBUG
		properties.Add("Debug", "True");
#else
			properties.Add("Debug", "False");
#endif

		properties.Add("Device Idiom", DeviceInfo.Idiom.ToString());
		properties.Add("Device Platform", DeviceInfo.Platform.ToString());
		properties.Add("Device Type", DeviceInfo.DeviceType.ToString());
		properties.Add("Device Manufacturer", DeviceInfo.Manufacturer);
		properties.Add("Device Model", DeviceInfo.Model);
		properties.Add("Device Name", DeviceInfo.Name);
		properties.Add("Device Version", DeviceInfo.Version.ToString());
		properties.Add("Device VersionString", DeviceInfo.VersionString);

		return properties;
	}
}