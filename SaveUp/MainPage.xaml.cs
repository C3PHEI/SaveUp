using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace SaveUp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public ICommand NavigateToAddItemPageCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new AddItemPage());
        });

        public ICommand NavigateToListPageCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new ListPage());
        });
    }
}