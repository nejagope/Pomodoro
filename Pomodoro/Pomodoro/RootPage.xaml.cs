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

        /*
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as RootPageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            //MasterPage.ListView.SelectedItem = null;
        }
        */
    }

    internal class NotificationObject
    {
    }
}