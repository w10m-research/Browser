#include "pch.h"
#include "BrowserState.h"

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;

BrowserState::BrowserState(Windows::UI::Xaml::Controls::WebView^ webview) {
	this->webview = webview;
	this->UserAgent = L"Mozilla/5.0 (iPhone; CPU iPhone OS 15_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 Mobile/15E148 Safari/604.1";
}

void BrowserState::NavigateTo(String^ address) {
	Uri^ url = ref new Uri(address);
	auto request = ref new Windows::Web::Http::HttpRequestMessage(Windows::Web::Http::HttpMethod::Get, url);

	// Set the user agent to something compentent,
	// TODO: figure out a way to also do this for
	// subsequent requests (eg resources).
	request->Headers->Insert("User-Agent", UserAgent);

	// Send request.
	webview->NavigateWithHttpRequestMessage(request);

	// TODO: Push to history.
}