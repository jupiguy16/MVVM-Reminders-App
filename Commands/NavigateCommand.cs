using ReminderAppFinal.Services;
using ReminderAppFinal.Stores;
using ReminderAppFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderAppFinal.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
