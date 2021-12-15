using System;
using System.Collections.Generic;
using BLL;

namespace PL
{
    public class FootballPlayerRegistryMenu : StaticMenu
    {
       
        protected override void SetupBindings(Dictionary<ConsoleKey, Action> binds)
        {
            binds.Add(ConsoleKey.D1, RunAddMenu);
            binds.Add(ConsoleKey.D2, RunDeleteMenu);
            binds.Add(ConsoleKey.D3, RunChangeMenu);
            binds.Add(ConsoleKey.D4, RunShowMenu);
            binds.Add(ConsoleKey.D5, RunShowPlayerMenu);
            BindExit(ConsoleKey.Q);
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("========== Player Registry ==========");
            view.Add("1) Add player ");
            view.Add("2) Delete player");
            view.Add("3) Change player");
            view.Add("4) Show all players");
            view.Add("5) Show player");
            view.Add("Q) Back");
        }

        private void RunAddMenu() => Run<AddFootballPlayer>();

        private void RunDeleteMenu() => Run<DeleteFootballPlayer>();

        private void RunChangeMenu() => Run<SelectFootballPlayerMenu>();

        private void RunShowMenu() => Run<ShowFootballPlayerMenu>();
        private void RunShowPlayerMenu() => Run<PlayerFindMenu>();

    }
}
