using BLL;
using System;
using System.Collections.Generic;

namespace PL
{
    class StadiumRegistryMenu : StaticMenu
    {
      

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

        private void RunAddStadiumMenu() => Run<AddStadiumMenu>();
        private void RunDeleteStadiumMenu() => Run<DeleteStadium>();
        private void RunChangeStadiumMenu() => Run<SelectStadiumMenu>();
        private void RunShowStadiumMenu() => Run<ShowStadiumMenu>();
    }

}
