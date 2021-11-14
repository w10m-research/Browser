//
// MainPage.xaml.cpp
// Implementation of the MainPage class.
//

#include "pch.h"
#include "MainPage.xaml.h"

using namespace Browser;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;

MainPage::MainPage()
{
	InitializeComponent();

	BrowserProgress->Value = 0;
	BrowserProgress->Visibility = Windows::UI::Xaml::Visibility::Collapsed;
}

void Browser::MainPage::Menu_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	// TODO: Open flyout.

	Windows::UI::Popups::MessageDialog alert{ L"TODO: Menu." };
	alert.ShowAsync();
}

void Browser::MainPage::Addressbar_QuerySubmitted(Windows::UI::Xaml::Controls::AutoSuggestBox^ sender, Windows::UI::Xaml::Controls::AutoSuggestBoxQuerySubmittedEventArgs^ args)
{
	String^ _url;
	try {
		ref new Uri(Addressbar->Text);
		_url = Addressbar->Text;
	}
	catch ( ... ) {
		// TODO: do this properly.
		try {
			_url = L"https://" + Addressbar->Text;
			auto temp = ref new Uri(_url);

			// TODO: make sure we actually have a TLd.
		}
		catch (...) {
			// TODO: user-configurable search engine.
			_url = L"http://www.google.com/search?q=" + Uri::EscapeComponent(Addressbar->Text);
		}
	}

	Uri^ url = ref new Uri(_url);
	auto request = ref new Windows::Web::Http::HttpRequestMessage(Windows::Web::Http::HttpMethod::Get, url);
	// Set the user agent to something compentent,
	// TODO: figure out a way to also do this for
	// subsequent requests (eg resources).
	request->Headers->Insert("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 15_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 Mobile/15E148 Safari/604.1");

	// Send request.
	WebView->NavigateWithHttpRequestMessage(request);

	// Unfocus Textbox.
	// Addressbar->Focus(Windows::UI::Xaml::FocusState::Unfocused);

	// TODO: Progressbar.
	BrowserProgress->Value = 0;
	BrowserProgress->Visibility = Windows::UI::Xaml::Visibility::Visible;
}

void Browser::MainPage::WebView_FrameNavigationCompleted(Windows::UI::Xaml::Controls::WebView^ sender, Windows::UI::Xaml::Controls::WebViewNavigationCompletedEventArgs^ args)
{
	Addressbar->Text = WebView->Source->DisplayUri;

	BrowserProgress->Value = 100;
	BrowserProgress->Visibility = Windows::UI::Xaml::Visibility::Collapsed;
}


void Browser::MainPage::Tabs_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	// TODO: Show tabs view.

	Windows::UI::Popups::MessageDialog alert{ L"TODO: Tabs menu." };
	alert.ShowAsync();
}
