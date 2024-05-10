using PZWrapper.Links;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZImageTests.Config;
using ZImageTests.Helpers;

namespace ZImageTests
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			LoadConfiguration();
		}

		private void LoadConfiguration()
		{
			try
			{
				var configDir = PathHelper.GetDir("ApplicationSettings");
				var configPath = Path.Combine(configDir, "CustomConfig.json");
				if (File.Exists(configPath))
				{
					AppConfig.Load(configPath);
					CppMethods.


				}
				else
				{
					MessageBox.Show("Configuration file not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					Shutdown();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred while loading configuration: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				Shutdown();
			}
		}
	}
}
