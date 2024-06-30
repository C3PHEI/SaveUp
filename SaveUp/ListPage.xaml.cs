using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.Maui.Controls;

namespace SaveUp
{
    public partial class ListPage : ContentPage
    {
        public ObservableCollection<SavedItem> SavedItems { get; set; }

        public ListPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadSavedItems();
        }

        private void LoadSavedItems()
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "SaveUp");
            string filePath = Path.Combine(folderPath, "SavedItems.csv");

            SavedItems = new ObservableCollection<SavedItem>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var parts = line.Split(',');
                        SavedItems.Add(new SavedItem { Description = parts[0], Price = parts[1] });
                    }
                }
            }
        }
    }

    public class SavedItem
    {
        public string Description { get; set; }
        public string Price { get; set; }
    }
}