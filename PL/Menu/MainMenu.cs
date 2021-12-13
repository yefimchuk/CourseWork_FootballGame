using System;
using System.Collections.Generic;
using BLL;

namespace PL
{
    public class MainMenu : StaticMenu
    {
      

        protected override void SetupBindings(Dictionary<ConsoleKey, Action> binds)
        {
            binds.Add(ConsoleKey.D1, RunFootballPlayerRegistry);
            binds.Add(ConsoleKey.D2, RunFootballGameRegistry);
            binds.Add(ConsoleKey.D3, RunFootballStadiumRegistry);
            binds.Add(ConsoleKey.D4, RunFindMenu);
            BindExit(ConsoleKey.Q);
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("---------- Main Menu ----------");
            view.Add("1) Player control");
            view.Add("2) Game control");
            view.Add("3) Stadion control");
            view.Add("4) Find menu");
            view.Add("Q) Exit");
        }

        private void RunFootballPlayerRegistry() => Run<FootballPlayerRegistryMenu>();

        private void RunFootballGameRegistry() => Run<GameRegistryMenu>();

        private void RunFootballStadiumRegistry() => Run<StadiumRegistryMenu>();

        private void RunFindMenu() => Run<SearchMenu>();

    }
}
