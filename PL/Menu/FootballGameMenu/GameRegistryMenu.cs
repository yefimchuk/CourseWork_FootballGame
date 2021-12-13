using BLL;
using System;
using System.Collections.Generic;

namespace PL
{
    public class GameRegistryMenu : StaticMenu
    {
       

        protected override void SetupBindings(Dictionary<ConsoleKey, Action> binds)
        {
            binds.Add(ConsoleKey.D1, RunAddMenu);
            binds.Add(ConsoleKey.D2, RunDeleteMenu);
            binds.Add(ConsoleKey.D3, RunChangeMenu);
            binds.Add(ConsoleKey.D4, RunShowMenu);
            binds.Add(ConsoleKey.D5, RunSortMenu);

            BindExit(ConsoleKey.Q);
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("- - - - - - - - - - - - Football Game registry - - - - - - - - - - - - - -");
            view.Add("1) Add game");
            view.Add("2) Delete game");
            view.Add("3) Change data of game");
            view.Add("4) Show All games");
            view.Add("4) Show sort games");
            view.Add("Q) Back");
        }

        private void RunAddMenu() => Run<AddGamenMenu>();
        private void RunDeleteMenu() => Run<DeleteGame>();
        private void RunChangeMenu() => Run<SelectGameMenu>();
        private void RunShowMenu() => Run<ShowGameMenu>();
        private void RunSortMenu() => Run<Sort>();
    }

}
