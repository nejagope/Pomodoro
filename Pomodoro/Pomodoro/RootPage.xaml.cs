using Pomodoro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pomodoro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<RootPageViewModel>(this, "GoToConfiguration", (a) => {
                Detail = new NavigationPage(new ConfigurationPage());
                IsPresented = false;
            });

            MessagingCenter.Subscribe<RootPageViewModel>(this, "GoToPomodoro", (a) => {
                Detail = new NavigationPage(new PomodoroPage());
                IsPresented = false;
            });

            MessagingCenter.Subscribe<RootPageViewModel>(this, "GoToHistory", (a) => {
                Detail = new NavigationPage(new HistoryPage());
                IsPresented = false;
            });
            
        }
    }
}