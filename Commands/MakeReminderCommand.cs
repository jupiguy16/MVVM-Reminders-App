using ReminderAppFinal.Models;
using ReminderAppFinal.Services;
using ReminderAppFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ReminderAppFinal.Commands
{
    public class MakeReminderCommand : CommandBase
    {
        private readonly RemindersViewModel _remindersViewModel;
        private readonly Profile _profile;
        private readonly NavigationService reminderViewNavigationService;

        public MakeReminderCommand(RemindersViewModel remindersViewModel, Profile profile, NavigationService reminderViewNavigationService)
        {
            _remindersViewModel = remindersViewModel;
            _profile = profile;
            this.reminderViewNavigationService = reminderViewNavigationService;
            _remindersViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_remindersViewModel.Name) && _remindersViewModel.Importance != 0 && base.CanExecute(parameter) && !string.IsNullOrEmpty(_remindersViewModel.AOL);
        }

        public override void Execute(object parameter)
        {
            Reminder reminder = new Reminder(_remindersViewModel.Name, 
                _remindersViewModel.DueDate, 
                _remindersViewModel.Importance, 
                _remindersViewModel.AOL,
                _remindersViewModel.DueTime, 
                _remindersViewModel.Details
            );

            _profile.MakeReminder(reminder);

            reminderViewNavigationService.Navigate();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RemindersViewModel.Name) || e.PropertyName == nameof(RemindersViewModel.Importance))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
