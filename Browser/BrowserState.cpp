#include "pch.h"
#include "BrowserState.h"

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;

BrowserState::BrowserState() {
	// TODO: Load from config.
	this->UserAgent = L"Mozilla/5.0 (iPhone; CPU iPhone OS 15_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 Mobile/15E148 Safari/604.1";

	// TODO: Load from disk.
	this->history = ref new Platform::Collections::Vector<String^>();
}

void BrowserState::SetWebView(Windows::UI::Xaml::Controls::WebView^ webview) {
	this->webview = webview;
}

void BrowserState::Reload() {
	// Make sure we actually have something to reload.
	if (this->history->Size <= 0)
		return;

	// TODO: Don't duplicate code here, DRY.

	Uri^ url = ref new Uri(this->history->GetAt(this->history->Size - 1));
	auto request = ref new Windows::Web::Http::HttpRequestMessage(Windows::Web::Http::HttpMethod::Get, url);

	// Set the user agent to something compentent,
	// TODO: figure out a way to also do this for
	// subsequent requests (eg resources).
	request->Headers->Insert("User-Agent", UserAgent);

	// Send request.
	webview->NavigateWithHttpRequestMessage(request);
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

	// this->PushHistory(address);
}

void BrowserState::PushHistory(String^ address) {
	// Make sure we don't duplicate
	if (this->history->Size > 0) {
		if (this->history->GetAt(this->history->Size - 1) == address)
			return;
	}

	this->history->Append(address);
}

void BrowserState::ClearHistory() {
	this->history->Clear();
}

Platform::Collections::Vector<String^>^ BrowserState::GetHistory() {
	return this->history;
}