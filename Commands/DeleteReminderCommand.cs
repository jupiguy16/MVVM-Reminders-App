using ReminderAppFinal.Models;
using ReminderAppFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderAppFinal.Commands
{
    public class DeleteReminderCommand : CommandBase
    {
        private readonly Profile _profile;
        private readonly HomepageViewModel _homepageViewModel;

        public DeleteReminderCommand(Profile profile, HomepageViewModel homepageViewModel)
        {
            _profile = profile;
            _homepageViewModel = homepageViewModel;
        }


        public override void Execute(object parameter)
        {
            List<ReminderViewModel> reminderViewModels = new List<ReminderViewModel> { _homepageViewModel.BadCoachSelectedReminder, 
                _homepageViewModel.BadPlaySelectedReminder, _homepageViewModel.UniSelectedReminder, _homepageViewModel.OtherSelectedReminder };

            List<Reminder> reminders = new List<Reminder>();

            foreach (ReminderViewModel remViewModel in reminderViewModels)
            {
                if (remViewModel != null)
                {
                    reminders.Add((Reminder)remViewModel);
                }
            }

            foreach (Reminder reminder in reminders)
            {
                _profile.DeleteReminder(reminder);
            }

            _homepageViewModel.UpdateReminders(_profile);
        }
    }
}
