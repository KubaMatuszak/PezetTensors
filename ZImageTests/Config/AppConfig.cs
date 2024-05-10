using Newtonsoft.Json;
using System.IO;
using ZImageTests.Helpers;

namespace ZImageTests.Config;
public class CustomConfig
{
	[JsonProperty("DllPath")]
	public string DllPath { get; set; }
}

public class AppConfig
{
	[JsonProperty("CustomConfig")]
	public CustomConfig CustomConfig { get; set; }

	[JsonIgnore]
	public static AppConfig Instance { get; private set; }
	public static void Load(string path)
	{
		string json = File.ReadAllText(path);
		var instance = JsonConvert.DeserializeObject<AppConfig>(json);
		Instance = instance;
	}
}