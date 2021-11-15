//
// HistoryPage.xaml.h
// Declaration of the HistoryPage class
//

#pragma once

#include "HistoryPage.g.h"

namespace Browser
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	[Windows::Foundation::Metadata::WebHostHidden]
	public ref class HistoryPage sealed
	{
	public:
		HistoryPage();
	private:
		void ClearHistoryBtn_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
	};
}
