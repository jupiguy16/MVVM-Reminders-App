using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ReminderAppFinal.Models
{
    public class RemindersList
    {
        private readonly ObservableCollection<Reminder> _reminders;

        public RemindersList()
        {
            _reminders = new ObservableCollection<Reminder>();

        }


        /// <summary>
        /// Add a reminder for a profile.
        /// </summary>
        /// <param name="reminder">The reminder to be added.</param>
        public void AddReminder(Reminder reminder)
        {
            _reminders.Add(reminder);
        }

        /// <summary>
        /// Removes a reminder from the profile's 'Reminders' list.
        /// </summary>
        /// <param name="reminder"></param>
        public void RemoveReminder(Reminder reminder)
        {
            _reminders.Remove(reminder);
        }

        /// <summary>
        /// Returns the 'Reminders' list for easy access and display.
        /// </summary>
        /// <returns>The 'Reminders' list.</returns>
        public IEnumerable<Reminder> Display_Reminders(string aol)
        {
            List<Reminder> list = new List<Reminder>();

            foreach (Reminder k in _reminders) {
                if (k.Aol == aol)
                {
                    list.Add(k);
                }
            }

            return list;
        }
    }
}
