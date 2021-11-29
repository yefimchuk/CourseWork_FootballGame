using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
namespace PL
{
    class SelectorShowMenu : StaticMenu
    {
        private Registry _service;

        protected override void SetupBindings(Dictionary<ConsoleKey, Action> binds)
        {
            binds.Add(ConsoleKey.D1, RunShowFootballPlayerMenu);

            BindExit(ConsoleKey.Q);
        }

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            var args = initArgs as RegistryMenuInitArgs;

            if (args != null)
                _service = args.service;
        }

        protected override void SetupView(List<string> view)
        {
            view.Add("========== Show Menu ==========");
            view.Add("1) Doctors");
            view.Add("2) Patients");
            view.Add("Q) Back");
        }

        private void RunShowFootballPlayerMenu() => Run<ShowFootballPlayerMenu>(new RegistryMenuInitArgs(_service));
    }
}
