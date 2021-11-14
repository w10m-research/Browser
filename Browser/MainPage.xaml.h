//
// MainPage.xaml.h
// Declaration of the MainPage class.
//

#pragma once

#include "MainPage.g.h"

namespace Browser
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public ref class MainPage sealed
	{
	public:
		MainPage();

	private:
		void Menu_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void WebView_FrameNavigationCompleted(Windows::UI::Xaml::Controls::WebView^ sender, Windows::UI::Xaml::Controls::WebViewNavigationCompletedEventArgs^ args);
		void Tabs_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void Addressbar_KeyDown(Platform::Object^ sender, Windows::UI::Xaml::Input::KeyRoutedEventArgs^ e);
		void Addressbar_GotFocus(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void WebView_GotFocus(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void WebView_NavigationStarting(Windows::UI::Xaml::Controls::WebView^ sender, Windows::UI::Xaml::Controls::WebViewNavigationStartingEventArgs^ args);
		void AboutBtn_Tapped(Platform::Object^ sender, Windows::UI::Xaml::Input::TappedRoutedEventArgs^ e);
		void PopupMenu_SelectionChanged(Platform::Object^ sender, Windows::UI::Xaml::Controls::SelectionChangedEventArgs^ e);
		void ToggleMenus();
	};
}
