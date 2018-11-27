using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Pomodoro.ViewModels
{
    public class HistoryPageViewModel: NotificationObject
    {
        private ObservableCollection<DateTime> pomodoros;

        public ObservableCollection<DateTime> Pomodoros
        {
            get { return pomodoros; }
            set { pomodoros = value; OnPropertyChanged(); }
        }

        public HistoryPageViewModel()
        {
            LoadHistory();
        }

        private void LoadHistory()
        {
            if (Application.Current.Properties.ContainsKey(Literals.HistoryKey))
            {
                var json = Application.Current.Properties[Literals.HistoryKey].ToString();
                var history = JsonConvert.DeserializeObject<List<DateTime>>(json);
                Pomodoros = new ObservableCollection<DateTime>(history);
            }
        }
    }
}
