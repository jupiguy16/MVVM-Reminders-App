using ReminderAppFinal.Commands;
using ReminderAppFinal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ReminderAppFinal.ViewModels
{
    public class HomepageViewModel : ViewModelBase
    {
        public ICommand ChangeBackgroundCommand { get;  }

        public ICommand MakeReminderCommand { get; }

        public ICommand DeleteReminderCommand { get; }

        private readonly Profile profile;

        private string _background;

        public string Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
                OnPropertyChanged(nameof(Background));
                profile.ChangeBackground(value);
            }
        }

        // Selected Reminders

        private ReminderViewModel _uniSelectedReminder;
        public ReminderViewModel UniSelectedReminder
        {
            get
            {
                return _uniSelectedReminder;
            }
            set
            {
                _uniSelectedReminder = value;
                OnPropertyChanged(nameof(UniSelectedReminder));
            }
        }

        private ReminderViewModel _badCoachSelectedReminder;
        public ReminderViewModel BadCoachSelectedReminder
        {
            get
            {
                return _badCoachSelectedReminder;
            }
            set
            {
                _badCoachSelectedReminder = value;
                OnPropertyChanged(nameof(BadCoachSelectedReminder));
            }
        }

        private ReminderViewModel _badPlaySelectedReminder;
        public ReminderViewModel BadPlaySelectedReminder
        {
            get
            {
                return _badPlaySelectedReminder;
            }
            set
            {
                _badPlaySelectedReminder = value;
                OnPropertyChanged(nameof(BadPlaySelectedReminder));
            }
        }

        private ReminderViewModel _otherSelectedReminder;
        public ReminderViewModel OtherSelectedReminder
        {
            get
            {
                return _otherSelectedReminder;
            }
            set
            {
                _otherSelectedReminder = value;
                OnPropertyChanged(nameof(OtherSelectedReminder));
            }
        }

        // Reminder Lists

        private readonly ObservableCollection<ReminderViewModel> _uniReminders;

        public IEnumerable<ReminderViewModel> UniReminders => _uniReminders;

        private readonly ObservableCollection<ReminderViewModel> _badCoachingReminders;

        public IEnumerable<ReminderViewModel> BadCoachingReminders => _badCoachingReminders;

        private readonly ObservableCollection<ReminderViewModel> _badPlayingReminders;

        public IEnumerable<ReminderViewModel> BadPlayingReminders => _badPlayingReminders;

        private readonly ObservableCollection<ReminderViewModel> _otherReminders;

        public IEnumerable<ReminderViewModel> OtherReminders => _otherReminders;

        // Constructor
        public HomepageViewModel(Profile _profile, Services.NavigationService makeReminderNavigationService)
        {
            profile = _profile;
            _uniReminders = new ObservableCollection<ReminderViewModel>();
            _badCoachingReminders = new ObservableCollection<ReminderViewModel>();
            _badPlayingReminders = new ObservableCollection<ReminderViewModel>();
            _otherReminders = new ObservableCollection<ReminderViewModel>();

            MakeReminderCommand = new NavigateCommand(makeReminderNavigationService);
            ChangeBackgroundCommand = new ChangeBackgroundCommand(profile, _background);
            DeleteReminderCommand = new DeleteReminderCommand(_profile, this);


            Background = _profile.Background;
            

            UpdateReminders(profile);
        }

        // Method to refresh view
        public void UpdateReminders(Profile profile)
        {
            _uniReminders.Clear();
            _badCoachingReminders.Clear();
            _badPlayingReminders.Clear();
            _otherReminders.Clear();

            foreach (Reminder reminder in profile.GetReminders("University"))
            {
                ReminderViewModel reminderViewModel = new ReminderViewModel(reminder);
                _uniReminders.Add(reminderViewModel);
            }

            foreach (Reminder reminder in profile.GetReminders("Badminton Career"))
            {
                ReminderViewModel reminderViewModel = new ReminderViewModel(reminder);
                _badPlayingReminders.Add(reminderViewModel);
            }

            foreach (Reminder reminder in profile.GetReminders("Badminton Coaching"))
            {
                ReminderViewModel reminderViewModel = new ReminderViewModel(reminder);
                _badCoachingReminders.Add(reminderViewModel);
            }

            foreach (Reminder reminder in profile.GetReminders("Other"))
            {
                ReminderViewModel reminderViewModel = new ReminderViewModel(reminder);
                _otherReminders.Add(reminderViewModel);
            }
        }
    }
}
