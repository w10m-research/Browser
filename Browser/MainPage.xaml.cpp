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
using namespace concurrency;

void Navigate_To(Windows::UI::Xaml::Controls::WebView^ WebView, Platform::String^ address) {
	Uri^ url = ref new Uri(address);
	auto request = ref new Windows::Web::Http::HttpRequestMessage(Windows::Web::Http::HttpMethod::Get, url);

	// Set the user agent to something compentent,
	// TODO: figure out a way to also do this for
	// subsequent requests (eg resources).
	request->Headers->Insert("User-Agent", L"Mozilla/5.0 (iPhone; CPU iPhone OS 15_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 Mobile/15E148 Safari/604.1");

	// Send request.
	WebView->NavigateWithHttpRequestMessage(request);

	// TODO: Push to history.
}

MainPage::MainPage()
{
	InitializeComponent();

	// TODO: hide titlebar

	// Initialize 
	BrowserProgress->Value = 0;
	BrowserProgress->Visibility = Windows::UI::Xaml::Visibility::Collapsed;
}

void Browser::MainPage::Addressbar_KeyDown(Platform::Object^ sender, Windows::UI::Xaml::Input::KeyRoutedEventArgs^ e)
{

	if (e->Key != Windows::System::VirtualKey::Enter)
		return;

	String^ _url;
	try {
		ref new Uri(Addressbar->Text);
		_url = Addressbar->Text;
	}
	catch (...) {
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

	// Send navigation request.
	Navigate_To(WebView, _url);

	// Unfocus Textbox.
	WebView->Focus(Windows::UI::Xaml::FocusState::Programmatic);
}

void Browser::MainPage::WebView_FrameNavigationCompleted(Windows::UI::Xaml::Controls::WebView^ sender, Windows::UI::Xaml::Controls::WebViewNavigationCompletedEventArgs^ args)
{
	// TODO: handle alert

	// Temporary pre-engine switch to servo
	// Add polyfills
	auto corejs = ref new Platform::Collections::Vector<String^>(1);
	corejs->SetAt(0, L"var script=document.createElement('script');script.src='https://cdnjs.cloudflare.com/ajax/libs/core-js/3.19.1/minified.min.js';document.head.appendChild(script);");
	create_task(WebView->InvokeScriptAsync("eval", corejs));

	// TODO: only display the url if we're not on a search url (eg google.com/search?q=xxxx).
	Addressbar->Text = WebView->Source->DisplayUri;

	// Progressbar
	BrowserProgress->Value = 100;
	BrowserProgress->Visibility = Windows::UI::Xaml::Visibility::Collapsed;
}

void Browser::MainPage::Tabs_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	// TODO: Show tabs view.

	Windows::UI::Popups::MessageDialog alert{ L"TODO: Tabs menu." };
	alert.ShowAsync();
}

void Browser::MainPage::Addressbar_GotFocus(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	// Automatically select the contents on tap.
	Addressbar->SelectAll();
}

void Browser::MainPage::WebView_NavigationStarting(Windows::UI::Xaml::Controls::WebView^ sender, Windows::UI::Xaml::Controls::WebViewNavigationStartingEventArgs^ args)
{
	// TODO: Progressbar.
	BrowserProgress->Value = 25;
	BrowserProgress->Visibility = Windows::UI::Xaml::Visibility::Visible;
}

void Browser::MainPage::AboutBtn_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	Navigate_To(WebView, L"https://github.com/w10m-research/Browser");
}


void Browser::MainPage::RefreshBtn_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	WebView->Navigate(WebView->BaseUri);
}
