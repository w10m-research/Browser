using System;
using Windows.ApplicationModel;
using Windows.Storage;
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

            // Settings
            ApplicationDataContainer settings = Windows.Storage.ApplicationData.Current.RoamingSettings;
            this.SearchEngineDrpDwn.SelectedIndex = settings.Values["PreferredSearchEngine"] as Int32? ?? 0;
            this.CookiesDrpDwn.SelectedIndex = settings.Values["PreferredCookiesSelection"] as Int32? ?? 0;
            this.DoNotTrackToggle.IsOn = settings.Values["SendDoNotTrack"] as Boolean? ?? false;
        }

        private void BackBtn_OnClick(Object sender, RoutedEventArgs e) {
            this.Frame.GoBack();
        }

        private void SearchEngineDrpDwn_OnSelectionChanged(Object sender, SelectionChangedEventArgs e) {
            ApplicationDataContainer settings = Windows.Storage.ApplicationData.Current.RoamingSettings;
            settings.Values["PreferredSearchEngine"] = this.SearchEngineDrpDwn.SelectedIndex;
        }
        private void CookiesDrpDwn_OnSelectionChanged(Object sender, SelectionChangedEventArgs e) {
            ApplicationDataContainer settings = Windows.Storage.ApplicationData.Current.RoamingSettings;
            settings.Values["PreferredCookiesSelection"] = this.CookiesDrpDwn.SelectedIndex;
        }

        private void DoNotTrackToggle_OnToggled(Object sender, RoutedEventArgs e) {
            ApplicationDataContainer settings = Windows.Storage.ApplicationData.Current.RoamingSettings;
            settings.Values["SendDoNotTrack"] = this.DoNotTrackToggle.IsOn;
        }
    }
}
