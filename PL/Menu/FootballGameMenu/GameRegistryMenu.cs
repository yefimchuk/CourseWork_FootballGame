using BLL;
using System;
using System.Collections.Generic;

namespace PL
{
    class GameRegistryMenu : StaticMenu
    {
        private IGameService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is GameRegistryMenuInitArgs)
            {
                var args = (GameRegistryMenuInitArgs)initArgs;
                _service = args.service;
            }
        }

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

        private void RunAddMenu() => Run<AddGamenMenu>(new GameRegistryMenuInitArgs(_service));
        private void RunDeleteMenu() => Run<DeleteGame>(new GameRegistryMenuInitArgs(_service));
        private void RunChangeMenu() => Run<SelectGameMenu>(new GameRegistryMenuInitArgs(_service));
        private void RunShowMenu() => Run<ShowGameMenu>(new RegistryMenuInitArgs(_service as Registry));
        private void RunSortMenu() => Run<SortByDateGame>(new GameRegistryMenuInitArgs(_service));
    }

}
