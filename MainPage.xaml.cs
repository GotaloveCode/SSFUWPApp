using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SSF_Intranet
{
    public delegate void LoadCompletedEventHandler(object sender, NavigationEventArgs e);
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MyWebView.UnviewableContentIdentified += MyWebView_UnviewableContentIdentified;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var uristring = e.Parameter as string;
            if (uristring != "")
            {
                string[] parts = uristring.ToString().Split(':');
                string p = parts[1].Substring(1, parts[1].Length - 1);
                uristring = "https://somaliastabilityke.sharepoint.com/sites/ssf2" + p;                
                Uri u = new Uri(uristring); 
                MyWebView.Navigate(u);
            }else
            {
                Uri u = new Uri("https://somaliastabilityke.sharepoint.com/sites/ssf2"); 
                MyWebView.Navigate(u);
            }
        }        


        private void MyWebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            ProgressRing1.IsActive = true;
        }

        private void MyWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            ProgressRing1.IsActive = false; //for progress ring  
        }

        private void MyWebView_UnviewableContentIdentified(WebView sender,WebViewUnviewableContentIdentifiedEventArgs args)
        {
            Windows.Foundation.IAsyncOperation<bool> b =
            Windows.System.Launcher.LaunchUriAsync(args.Uri);
        }



    }
}
