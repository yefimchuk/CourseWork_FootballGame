using System;
using System.Collections.Generic;
using BLL;

namespace PL
{
    public class MainMenu : StaticMenu
    {
        private Registry _registry;

        public MainMenu() => _registry = new Registry();

        protected override void SetupBindings(Dictionary<ConsoleKey, Action> binds)
        {
            binds.Add(ConsoleKey.D1, RunFootballPlayerRegistry);
            binds.Add(ConsoleKey.D2, RunFootballGameRegistry);
            binds.Add(ConsoleKey.D3, RunScheduleManagement);

            BindExit(ConsoleKey.Q);
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("---------- Main Menu ----------");
            view.Add("1) Player control");
            view.Add("2) Game control");
            view.Add("3) Stadion control");
            view.Add("Q) Exit");
        }

        private void RunFootballPlayerRegistry() => Run<FootballPlayerRegistryMenu>(new DoctorRegistryMenuInitArgs(_registry));

        private void RunFootballGameRegistry() => Run<PatientsRegistryMenu>(new PatientRegistryMenuInitArgs(_registry));

        private void RunScheduleManagement() => Run<ScheduleManagementMenu>();
    }
}
