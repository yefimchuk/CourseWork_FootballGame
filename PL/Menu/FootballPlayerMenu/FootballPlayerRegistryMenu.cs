using System;
using System.Collections.Generic;
using BLL;

namespace PL
{
    public class FootballPlayerRegistryMenu : StaticMenu
    {
        private IFootBallService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is DoctorRegistryMenuInitArgs)
            {
                var args = (DoctorRegistryMenuInitArgs)initArgs;
                _service = args.service;
            }
        }

        protected override void SetupBindings(Dictionary<ConsoleKey, Action> binds)
        {
            binds.Add(ConsoleKey.D1, RunAddMenu);
            binds.Add(ConsoleKey.D2, RunDeleteMenu);
            binds.Add(ConsoleKey.D3, RunChangeMenu);
            binds.Add(ConsoleKey.D4, RunShowMenu);

            BindExit(ConsoleKey.Q);
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("========== Doctors Registry ==========");
            view.Add("1) Add");
            view.Add("2) Delete");
            view.Add("3) Change");
            view.Add("4) Show");
            view.Add("Q) Back");
        }

        private void RunAddMenu() => Run<AddFootballPlayer>(new DoctorRegistryMenuInitArgs(_service));

        private void RunDeleteMenu() => Run<DeleteFootballPlayer>(new DoctorRegistryMenuInitArgs(_service)); //_service.DeleteDoctors();

        private void RunChangeMenu() => Run<SelectFootballPlayerMenu>(new DoctorRegistryMenuInitArgs(_service));

        private void RunShowMenu() => Run<ShowFootballPlayerMenu>(new RegistryMenuInitArgs(_service as Registry));

    }
}
