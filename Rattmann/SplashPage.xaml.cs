using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Rattmann {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplashPage : Page {
        public SplashPage() {
            this.InitializeComponent();
        }

        private async void SplashPage_OnLoaded(Object sender, RoutedEventArgs e) {
            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0)) {
                var statusBar = StatusBar.GetForCurrentView();
                await statusBar.HideAsync();
            }

            // TODO
            this.Frame.Navigate(typeof(Pages.WrapperPage));
            this.Frame.BackStack.Remove(this.Frame.BackStack.Last());
        }
    }
}
