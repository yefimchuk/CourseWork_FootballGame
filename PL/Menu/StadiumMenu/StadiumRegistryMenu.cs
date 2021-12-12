using BLL;
using System;
using System.Collections.Generic;

namespace PL
{
    class StadiumRegistryMenu : StaticMenu
    {
        private IStadiumService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is StadiumRegistryMenuInitArgs)
            {
                var args = (StadiumRegistryMenuInitArgs)initArgs;
                _service = args.service;
            }
        }

        protected override void SetupBindings(Dictionary<ConsoleKey, Action> binds)
        {
            binds.Add(ConsoleKey.D1, RunAddStadiumMenu);
            binds.Add(ConsoleKey.D2, RunDeleteStadiumMenu);
            binds.Add(ConsoleKey.D3, RunChangeStadiumMenu);
            binds.Add(ConsoleKey.D4, RunShowStadiumMenu);

            BindExit(ConsoleKey.Q);
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("- - - - - - - - - - - - Football Game registry - - - - - - - - - - - - - -");
            view.Add("1) Add stadium");
            view.Add("2) Delete stadium");
            view.Add("3) Change data of stadium");
            view.Add("4) Show All stadium");
            view.Add("Q) Back");
        }

        private void RunAddStadiumMenu() => Run<AddStadiumMenu>(new StadiumRegistryMenuInitArgs(_service));
        private void RunDeleteStadiumMenu() => Run<DeleteStadium>(new StadiumRegistryMenuInitArgs(_service));
        private void RunChangeStadiumMenu() => Run<SelectStadiumMenu>(new StadiumRegistryMenuInitArgs(_service));
        private void RunShowStadiumMenu() => Run<ShowStadiumMenu>(new RegistryMenuInitArgs(_service as Registry));
    }

}
