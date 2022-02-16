using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderAppFinal.Models
{
    class Homepage
    {
        DateTime AllTime = DateTime.Now;

        public string DisplayTime()
        {
            return $"{AllTime.Hour}.{AllTime.Minute}.{AllTime.Second}";
        }
    }
}
