using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NorskeMagic
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogIn : Page
    {

        private HttpClient httpClient;
        private CancellationTokenSource cts;
        private const string loginUri = "http://www.norskemagic.com";

        public LogIn()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(httpClient != null)
                httpClient.Dispose();

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(loginUri);

            cts = new CancellationTokenSource();
            base.OnNavigatedTo(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var username = usernameInput.Text;
            var password = passwordBoxInput.ToString();
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("loginusername", username));
            postData.Add(new KeyValuePair<string, string>("password", password));
            HttpContent httpContent = new FormUrlEncodedContent(postData);
        }
    }
}
