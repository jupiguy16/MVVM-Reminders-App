using ReminderAppFinal.Commands;
using ReminderAppFinal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ReminderAppFinal.ViewModels
{
    public class RemindersViewModel : ViewModelBase
    {
        private readonly Profile _profile;
        public string Background => _profile.Background;

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _details;

        public string Details
        {
            get
            {
                return _details;
            }
            set
            {
                _details = value;
                OnPropertyChanged(nameof(Details));
            }
        }

        private DateTime _dueDate = DateTime.Now;

        public DateTime DueDate
        {
            get
            {
                return _dueDate;
            }
            set
            {
                _dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }

        private string _dueTime;

        public string DueTime
        {
            get
            {
                return _dueTime;
            }
            set
            {
                _dueTime = value;
                OnPropertyChanged(nameof(DueTime));
            }
        }

        private int _importance;

        public int Importance
        {
            get
            {
                return _importance;
            }
            set
            {
                _importance = value;
                OnPropertyChanged(nameof(Importance));
            }
        }

        private string _aol;

        public string AOL
        {
            get
            {
                return _aol;
            }
            set
            {
                _aol = value;
                OnPropertyChanged(nameof(AOL));
            }
        }



        public ICommand SubmitCommand { get;  }
        public ICommand CancelCommand { get;  }

        public RemindersViewModel(Profile profile, Services.NavigationService reminderViewNavigationService)
        {
            _profile = profile;
            SubmitCommand = new MakeReminderCommand(this, profile, reminderViewNavigationService);
            CancelCommand = new NavigateCommand(reminderViewNavigationService);
        }
    }
}
