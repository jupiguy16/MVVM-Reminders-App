using ReminderAppFinal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderAppFinal.Commands
{
    public class ChangeBackgroundCommand : CommandBase
    {
        private readonly Profile _profile;
        private readonly string _color;

        public ChangeBackgroundCommand(Profile profile, string color)
        {
            _profile = profile;
            _color = color;
        }

        public override void Execute(object parameter)
        {
            _profile.ChangeBackground(_color);
        }
    }
}
