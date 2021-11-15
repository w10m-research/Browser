//
// HistoryPage.xaml.cpp
// Implementation of the HistoryPage class
//

#include "pch.h"
#include "HistoryPage.xaml.h"

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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

HistoryPage::HistoryPage()
{
	InitializeComponent();

	// Set history items.
	HistoryList->ItemsSource = State->GetHistory();
}


void Browser::HistoryPage::ClearHistoryBtn_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	State->ClearHistory();
}
