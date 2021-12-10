
using BLL;
using System;
using System.Collections.Generic;

namespace PL
{
    class GameChangeMenu : StaticMenu
    {
        private IGameService _service;
        private FieldCollection _fields;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is GameChangeMenuInitArgs)
            {
                var args = (GameChangeMenuInitArgs)initArgs;
                _service = args.service;
                _fields = args.fields;
            }
        }

        protected override void SetupBindings(Dictionary<ConsoleKey, Action> binds)
        {
            binds.Add(ConsoleKey.D1, RunAddPlayer);
            binds.Add(ConsoleKey.D2, RunDeletePlayer);
            binds.Add(ConsoleKey.D3, RunChangeOther);

            BindExit(ConsoleKey.Q);
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("---------- Change game ----------");
            view.Add("1) Add player");
            view.Add("2) Delete player");
            view.Add("3) Change data of event, number speacers and place of game");
            view.Add("Q) Exit");
        }


        private void RunAddPlayer() => Run<AddPlayerGame>(new GameRegistryMenuInitArgs(_service));

        private void RunDeletePlayer() => Run<GameRegistryMenu>(new GameRegistryMenuInitArgs(_service));

        private void RunChangeOther() => Run<ChangeGame>(new GameChangeMenuInitArgs(_service, _fields));

    }
}
