using System;
using System.Collections.Generic;

namespace PL
{
    class SearchMenu : StaticMenu
    {
        protected override void SetupBindings(Dictionary<ConsoleKey, Action> binds)
        {

            binds.Add(ConsoleKey.D1, RunFindPlayerMenu);
            binds.Add(ConsoleKey.D2, RunFindGameMenu);
            binds.Add(ConsoleKey.D3, RunFindStadMenu);
            BindExit(ConsoleKey.Q);

        }

        protected override void SetupView(List<string> view)
        {
            view.Add("========== Search Menu ==========");
            view.Add("1) Find Player");
            view.Add("2) Find Game");
            view.Add("3) Find Stadium");
            view.Add("Q) Back");
        }

        private void RunFindPlayerMenu() => Run<PlayerFindMenu>();

        private void RunFindGameMenu() => Run<GameFindMenu>();

        private void RunFindStadMenu() => Run<StadiumFindMenu>();
    }
}
