using ReminderAppFinal.Models;
using ReminderAppFinal.Services;
using ReminderAppFinal.Stores;
using ReminderAppFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ReminderAppFinal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Profile _profile;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _profile = new Profile("Nella", "--", "White");
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateHomepageViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private RemindersViewModel CreateMakeReminderViewModel()
        {
            return new RemindersViewModel(_profile, new NavigationService(_navigationStore, CreateHomepageViewModel));
        }

        private ViewModelBase CreateHomepageViewModel()
        {
            return new HomepageViewModel(_profile, new NavigationService(_navigationStore, CreateMakeReminderViewModel));
        }
    }
}
