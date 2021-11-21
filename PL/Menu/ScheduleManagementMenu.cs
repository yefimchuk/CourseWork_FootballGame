using System;
using System.Collections.Generic;

namespace PL
{
    class ScheduleManagementMenu : StaticMenu
    {
        protected override void SetupBindings(Dictionary<ConsoleKey, Action> binds)
        {
            binds.Add(ConsoleKey.D1, RunFindPatientMenu);
            binds.Add(ConsoleKey.D2, RunFindDoctorMenu);
            binds.Add(ConsoleKey.D3, RunDoctorScheduleMenu);

            BindExit(ConsoleKey.Q);
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("========== Patients Registry ==========");
            view.Add("1) Find Patient");
            view.Add("2) Find Doctor");
            view.Add("3) Get Doctor Schedule");
            view.Add("Q) Back");
        }

        private void RunFindPatientMenu() { }

        private void RunFindDoctorMenu() { }

        private void RunDoctorScheduleMenu() { }
    }
}
