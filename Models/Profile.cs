using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace ReminderAppFinal.Models
{
    public class Profile
    {
        public readonly RemindersList RemindersList;

        public string Name { get; }

        public string Email { get; }

        public string Background { get; private set; }

        public Profile(string name, string email, string color)
        {
            Name = name;
            Email = email;
            Background = color;

            RemindersList = new RemindersList();
        }

        public void ChangeBackground(string color)
        {
            Background = color;
        }

        public void MakeReminder(Reminder reminder)
        {
            RemindersList.AddReminder(reminder);
        }

        public IEnumerable<Reminder> GetReminders(string aol)
        {
            return RemindersList.Display_Reminders(aol);
        }

        public void DeleteReminder(Reminder reminder)
        {
            RemindersList.RemoveReminder(reminder);
        }
    }
}
