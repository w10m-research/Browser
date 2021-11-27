using System;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rattmann.Pages {
    public sealed partial class SettingsPage : Page {
        public SettingsPage() {
            this.InitializeComponent();

            PackageVersion version = Package.Current.Id.Version;
            this.AppVersionStr.Text = String.Format($"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}");

            // TODO
            this.EngineVersionStr.Text = "TODO";
        }

        private void BackBtn_OnClick(Object sender, RoutedEventArgs e) {
            this.Frame.GoBack();
        }
    }
}
