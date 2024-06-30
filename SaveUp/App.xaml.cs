using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Microsoft.Maui.Graphics;
using Application = Microsoft.Maui.Controls.Application;

namespace SaveUp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            CreateDataFile();

            MainPage = new NavigationPage(new MainPage());
        }

        private void CreateDataFile()
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "SaveUp");
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, "SavedItems.csv");

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }
    }
}