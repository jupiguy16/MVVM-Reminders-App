using ReminderAppFinal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderAppFinal.ViewModels
{
    public class ReminderViewModel : ViewModelBase
    {
        private readonly Reminder _reminder;

        public string Name => _reminder.Name;
        public DateTime DueDate => _reminder.DueDate;
        public string DueTime => _reminder.DueTime;
        public int Importance => _reminder.Importance;
        public string Details => _reminder.Details;
        public string Aol => _reminder.Aol;

        public ReminderViewModel(Reminder reminder)
        {
            _reminder = reminder;
        }
    }
}
