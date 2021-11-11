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
}

void Browser::MainPage::Menu_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	// TODO: Open flyout.
}

void Browser::MainPage::Addressbar_QuerySubmitted(Windows::UI::Xaml::Controls::AutoSuggestBox^ sender, Windows::UI::Xaml::Controls::AutoSuggestBoxQuerySubmittedEventArgs^ args)
{
	// FIXME: Make sure it's a valid URL, otherwise search.
	// TODO: handle missing protocol.
	auto url = ref new Uri(Addressbar->Text);
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
}

void Browser::MainPage::WebView_FrameNavigationCompleted(Windows::UI::Xaml::Controls::WebView^ sender, Windows::UI::Xaml::Controls::WebViewNavigationCompletedEventArgs^ args)
{
	Addressbar->Text = WebView->Source->DisplayUri;

	// TODO: Remove Progressbar.
}
