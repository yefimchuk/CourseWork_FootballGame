using BLL;
using System;
using System.Collections.Generic;

namespace PL
{
    class PatientsRegistryMenu : StaticMenu
    {
        private IPatientService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is PatientRegistryMenuInitArgs)
            {
                var args = (PatientRegistryMenuInitArgs)initArgs;
                _service = args.service;
            }
        }

        protected override void SetupBindings(Dictionary<ConsoleKey, Action> binds)
        {
            binds.Add(ConsoleKey.D1, RunAddMenu);
            binds.Add(ConsoleKey.D2, RunDeleteMenu);
            binds.Add(ConsoleKey.D3, RunChangeCardMenu);

            BindExit(ConsoleKey.Q);
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("========== Patients Registry ==========");
            view.Add("1) Add");
            view.Add("2) Delete");
            view.Add("3) Change card");
            view.Add("Q) Back");
        }

        private void RunAddMenu() => Run<AddPatientMenu>(new PatientRegistryMenuInitArgs(_service));

        private void RunDeleteMenu() { }

        private void RunChangeCardMenu() { }
    }
}
