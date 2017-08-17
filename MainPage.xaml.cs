using System;
using Windows.UI.Xaml;
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
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Uri u = new Uri("http://somaliastabilityke.masterpiecefusion.com"); //http://ssf.masterpiecefusion.com/
            MyWebView.Navigate(u);
        }


        private void MyWebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            ProgressRing1.IsActive = true;
        }

        private void MyWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            ProgressRing1.IsActive = false; //for progress ring  
        }

    }
}
