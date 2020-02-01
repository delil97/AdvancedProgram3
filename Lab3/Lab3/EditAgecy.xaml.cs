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
using Newtonsoft.Json;
using System.Net.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditAgecy : Page
    {
        private Agency agency = new Agency() ;

        public EditAgecy()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             agency = e.Parameter as Agency;
            agencyEmailTb.Text = agency.Email;
            agencyNameTb.Text = agency.Name;

        }




        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            await client.DeleteAsync("http://localhost:59417/Agencies/" + agency.Id);
            Frame.GoBack();

        }

        private async void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            agency.Email = agencyEmailTb.Text;
            agency.Name = agencyNameTb.Text;
            var agencyJson = JsonConvert.SerializeObject(agency);

            var HttpContent = new StringContent(agencyJson);
            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            await client.PutAsync("http://localhost:59417/Agencies/" + agency.Id, HttpContent);
            Frame.GoBack();
        }      
    }
}
