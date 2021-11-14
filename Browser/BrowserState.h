#pragma once
class BrowserState
{
public:
	BrowserState(Windows::UI::Xaml::Controls::WebView^ webview);
	void NavigateTo(Platform::String^ address);

	Platform::String^ UserAgent;
private:
	Windows::UI::Xaml::Controls::WebView^ webview;
};

