using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{    
    public class ConfigurationPageViewModel: NotificationObject
    {        
        private ObservableCollection<int> pomodoroDurations;

        public ObservableCollection<int> PomodoroDurations
        {
            get { return pomodoroDurations; }
            set { pomodoroDurations = value; OnPropertyChanged(); }
        }

        private ObservableCollection<int> breakDurations;

        public ObservableCollection<int> BreakDurations
        {
            get { return breakDurations; }
            set { breakDurations = value; OnPropertyChanged(); }
        }

        private int selectedPomodoroDuration;

        public int SelectedPomodoroDuration
        {
            get { return selectedPomodoroDuration; }
            set { selectedPomodoroDuration = value; OnPropertyChanged(); }
        }

        private int selectedBreakDuration;

        public int SelectedBreakDuration
        {
            get { return selectedBreakDuration; }
            set { selectedBreakDuration = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; set; }

        public ConfigurationPageViewModel()
        {
            LoadPomodoroDurations();
            LoadBreakDurations();
            LoadConfiguration();
            SaveCommand = new Command(SaveCommandExecute);
        }

        private void LoadConfiguration()
        {
            if (Application.Current.Properties.ContainsKey(Literals.PomodoroDurationKey))
            {
                SelectedPomodoroDuration = (int)Application.Current.Properties[Literals.PomodoroDurationKey];
            }
            if (Application.Current.Properties.ContainsKey(Literals.BreakDurationKey))
            {
                SelectedBreakDuration = (int)Application.Current.Properties[Literals.BreakDurationKey];
            }
        }

        private void LoadBreakDurations()
        {
            breakDurations = new ObservableCollection<int>();
            breakDurations.Add(1);
            breakDurations.Add(5);
            breakDurations.Add(10);
            breakDurations.Add(25);
        }

        private void LoadPomodoroDurations()
        {
            pomodoroDurations = new ObservableCollection<int>();
            pomodoroDurations.Add(1);
            pomodoroDurations.Add(5);
            pomodoroDurations.Add(10);
            pomodoroDurations.Add(25);
        }

        private async void SaveCommandExecute(object obj)
        {
            Application.Current.Properties[Literals.PomodoroDurationKey] = SelectedPomodoroDuration;
            Application.Current.Properties[Literals.BreakDurationKey] = SelectedBreakDuration;

            await Application.Current.SavePropertiesAsync();
            MessagingCenter.Send<ConfigurationPageViewModel>(this, "GoToPomodoro");
        }
    }
}
