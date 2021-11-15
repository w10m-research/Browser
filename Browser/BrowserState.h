#pragma once
class BrowserState
{
public:
	BrowserState();
	void SetWebView(Windows::UI::Xaml::Controls::WebView^ webview);
	void NavigateTo(Platform::String^ address);
	void PushHistory(Platform::String^ address);
	void ClearHistory();
	void Reload();
	Platform::Collections::Vector<Platform::String^>^ BrowserState::GetHistory();

	Platform::String^ UserAgent;
private:
	Windows::UI::Xaml::Controls::WebView^ webview;
	Platform::Collections::Vector<Platform::String^>^ history; // TODO: custom class?
};

