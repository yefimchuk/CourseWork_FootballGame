using BLL;
using System;
using System.Collections.Generic;

namespace PL
{
    class PatientsRegistryMenu : StaticMenu
    {
        private IGameService _service;

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
            binds.Add(ConsoleKey.D3, RunChangeDataMenu);

            BindExit(ConsoleKey.Q);
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("- - - - - - - - - - - - Football Game registry - - - - - - - - - - - - - -");
            view.Add("1) Add game");
            view.Add("2) Delete game");
            view.Add("3) Change data of game menu");
            view.Add("Q) Back");
        }

        private void RunAddMenu() => Run<AddGamenMenu>(new PatientRegistryMenuInitArgs(_service));
        private void RunDeleteMenu() => Run<DeleteFootballPlayer>(new PatientRegistryMenuInitArgs(_service)); 

        private void RunChangeDataMenu() { }
    }

}
