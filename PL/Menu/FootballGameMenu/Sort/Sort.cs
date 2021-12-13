using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Sort : StaticMenu
    {
        protected override void SetupBindings(Dictionary<ConsoleKey, Action> binds)
        {
            binds.Add(ConsoleKey.D1, RunFootballPlayerRegistry);
            binds.Add(ConsoleKey.D2, RunFootballGameRegistry);
            binds.Add(ConsoleKey.D3, RunFootballStadiumRegistry);

            BindExit(ConsoleKey.Q);
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("---------- Sort ----------");
            view.Add("1) By date");
            view.Add("2) By win/lose");
            view.Add("3) By draw/not Play");

        }

        private void RunFootballPlayerRegistry() => Run<SortByDateGame>();

        private void RunFootballGameRegistry() => Run<SortByWin>();

        private void RunFootballStadiumRegistry() => Run<StadiumRegistryMenu>();

   
    }
}
