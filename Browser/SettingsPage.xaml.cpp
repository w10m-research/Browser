//
// SettingsPage.xaml.cpp
// Implementation of the SettingsPage class
//

#include "pch.h"
#include "SettingsPage.xaml.h"

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

SettingsPage::SettingsPage()
{
	InitializeComponent();

	// App Version
	auto major = Windows::ApplicationModel::Package::Current->Id->Version.Major.ToString();
	auto minor = Windows::ApplicationModel::Package::Current->Id->Version.Minor.ToString();
	auto revision = Windows::ApplicationModel::Package::Current->Id->Version.Revision.ToString();
	auto build = Windows::ApplicationModel::Package::Current->Id->Version.Build.ToString();
	auto version_str = major + "." + minor + "." + revision + "." + build;
	AppVersionStr->Text = Windows::ApplicationModel::Package::Current->DisplayName + " " + version_str;

	// TODO: Engine version
	EngineVersionStr->Text = L"EdgeHTML x.x.x.x";

	// TODO: Properly init all settings
	UserAgentStr->Text = L"TODO, come back later";
}
