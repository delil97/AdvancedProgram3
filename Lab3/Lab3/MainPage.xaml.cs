using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Lab3.Model;
using System.Net.Http;
using Newtonsoft.Json;


namespace Lab3
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

                HttpClient client = new HttpClient();
                var JsonREsponse = await client.GetStringAsync("http://localhost:59417/Agencies");
                var listresultat = JsonConvert.DeserializeObject<List<Agency>>(JsonREsponse);
                agencyList.ItemsSource = listresultat;

        }

     
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddAgency));

        }

        private void AgencyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var agencyy = agencyList.SelectedItem as Agency;
            Frame.Navigate(typeof(EditAgecy), agencyy); 
        }

    }
}
