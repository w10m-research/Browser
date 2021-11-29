using Rattmann.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Rattmann.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TabsPage : Page {
        public TabsPage() {
            this.InitializeComponent();

            this._refresh();
        }

        private void _refresh() {
            this.TabsGrid.ItemsSource = null;
            this.TabsGrid.ItemsSource = App.Tabs.Tabs;
            this.TabCountStr.Text = $"({App.Tabs.Tabs.Count})";
        }

        private void BackBtn_OnClick(Object sender, RoutedEventArgs e) {
            this.Frame.GoBack(new DrillInNavigationTransitionInfo());
        }

        private void NewTabBtn_OnClick(Object sender, RoutedEventArgs e) {
            App.Tabs.NewTab(new TabModel() {
                HistoryIndex = 0,
                History = new List<LocationModel>() {
                    new LocationModel() {
                        Title = $"New page {App.Tabs.Tabs.Count}"
                    }
                }
            });
            this._refresh();
        }

        private void CloseBtn_OnClick(Object sender, RoutedEventArgs e) {
            // App.Tabs.CloseTab();
            var tab = (sender as AppBarButton)?.DataContext as TabModel;
            App.Tabs.CloseTab(tab);
            this._refresh();
        }

        private void TabsGrid_OnItemClick(Object sender, ItemClickEventArgs e) {
            App.Tabs.TabIndex = App.Tabs.Tabs.FindIndex(x => x == (TabModel)e.ClickedItem);
            this.Frame.GoBack(new DrillInNavigationTransitionInfo());
        }
    }
}
