using System;
using System.IO;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace SaveUp
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public string ItemDescription { get; set; }
        public string ItemPrice { get; set; }

        public ICommand SaveItemCommand => new Command(SaveItem);

        private void SaveItem()
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "SaveUp");
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, "SavedItems.csv");

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{ItemDescription},{ItemPrice}");
            }

            DisplayAlert("Success", "Item saved successfully", "OK");
        }
    }
}