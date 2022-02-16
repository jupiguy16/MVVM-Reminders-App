using ReminderAppFinal.Stores;
using ReminderAppFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderAppFinal.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = createViewModel();

        }
    }
}
