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
using System.Text;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddAgency : Page
    {
        private const string BASE_URL = @"http://localhost:59417/";

        public AddAgency()
        {
            this.InitializeComponent();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            var agency = new Agency()
            {
                Email = agencyEmailTb.Text,
                Name = agencyNameTb.Text
            };

            var agencyJson = JsonConvert.SerializeObject(agency);

            var client = new HttpClient();
            var HttpContent = new StringContent(agencyJson);

            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            await client.PostAsync("http://localhost:59417/Agencies", HttpContent);
            Frame.GoBack();
        }



            //    var agencyJson = JsonConvert.SerializeObject(agency);
            //    var content = new StringContent(agencyJson, Encoding.UTF8, "application/json");

            //    var client = new HttpClient();

            //    string URL = BASE_URL + "Agencies";

            //    var response = await client.PostAsync(URL, content);
            //    var responseString = await response.Content.ReadAsStringAsync();

            //    Frame.GoBack();
            //}

            private void btnCancel_Click(object sender, RoutedEventArgs e)
            {
                Frame.GoBack();
            }
        }
    }

