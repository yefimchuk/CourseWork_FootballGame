
using BLL;
using System;
using System.Collections.Generic;

namespace PL
{
    class GameChangeMenu : StaticMenu
    {
     

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
        private FieldCollection _processedInputs;
        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);
            if (initArgs is InputParametersInitArgs args)
                _processedInputs = args.fields[0];
        }

        private void RunAddPlayer() => Run<AddPlayerGame>(new InputParametersInitArgs(_processedInputs));

        private void RunDeletePlayer() => Run<DeleteGamePlayer>(new InputParametersInitArgs(_processedInputs));

        private void RunChangeOther() => Run<ChangeGame>(new InputParametersInitArgs(_processedInputs));

    }
}
