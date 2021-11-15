//
// App.xaml.h
// Declaration of the App class.
//

#pragma once

#include "App.g.h"
#include "BrowserState.h"

extern BrowserState *State;

namespace Browser
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	ref class App sealed
	{
	protected:
		virtual void OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ e) override;
		void App_BackRequested(Platform::Object ^ sender, Windows::UI::Core::BackRequestedEventArgs ^ e);

	internal:
		App();

	private:
		void OnSuspending(Platform::Object^ sender, Windows::ApplicationModel::SuspendingEventArgs^ e);
		void OnNavigationFailed(Platform::Object ^sender, Windows::UI::Xaml::Navigation::NavigationFailedEventArgs ^e);
	};
}
