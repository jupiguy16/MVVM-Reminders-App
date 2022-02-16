using ReminderAppFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderAppFinal.Models
{
    public class Reminder
    {
        // Properties
        public string Name { get; }
        public DateTime DueDate { get; }
        public string DueTime { get; }
        public int Importance { get; }
        public string Details { get;  }
        public string Aol { get;  }

        // Constructors
        public Reminder(string name, DateTime dueDate, int importance, string aol, string dueTime = "--", string details = "No details added.")
        {
            Name = name;
            DueDate = dueDate;
            Importance = importance;
            Details = details;
            DueTime = dueTime;
            Aol = aol;
        }

        // Methods

        /// <summary>
        /// Overridden ToString() method for natural looking display.
        /// </summary>
        /// <returns>A modified string format.</returns>
        public override string ToString()
        {
                return $"Name: {Name}, due dueDate: {DueDate:d MMM yyyy} {DueTime}, importance: {Importance}\n Details: {Details}";
        }

        public static explicit operator Reminder(ReminderViewModel v)
        {
            return new Reminder(v.Name, v.DueDate, v.Importance, v.Aol, v.DueTime, v.Details);
        }



        /// <summary>
        /// Overriden Equals() method so that the Remove() method works in my RemindersList class.
        /// </summary>
        /// <param name="obj">A very vague type which encapsulates every single possible type, and then checks if this instance is the same as a specific reminder.</param>
        /// <returns>True if the instances are the same, false if they are not.</returns>
        public override bool Equals(object obj)
        {
            return obj is Reminder reminder &&
                Name == reminder.Name &&
                DueDate == reminder.DueDate &&
                Importance == reminder.Importance &&
                Aol == reminder.Aol;
        }

        /// <summary>
        /// Modified GetHashCode() method so that the Equals() method works.
        /// </summary>
        /// <returns>A working hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, DueDate, Importance);
        }
    }
}
