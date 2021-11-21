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
            binds.Add(ConsoleKey.D1, RunDoctorsRegistry);
            binds.Add(ConsoleKey.D2, RunPatientRegistry);
            binds.Add(ConsoleKey.D3, RunScheduleManagement);

            BindExit(ConsoleKey.Q);
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("---------- Main Menu ----------");
            view.Add("1) Player control");
            view.Add("2) Patients Registry");
            view.Add("3) Schedule Management");
            view.Add("Q) Exit");
        }

        private void RunDoctorsRegistry() => Run<DoctorsRegistryMenu>(new DoctorRegistryMenuInitArgs(_registry));

        private void RunPatientRegistry() => Run<PatientsRegistryMenu>(new PatientRegistryMenuInitArgs(_registry));

        private void RunScheduleManagement() => Run<ScheduleManagementMenu>();
    }
}
