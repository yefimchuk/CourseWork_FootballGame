using System;
using System.Collections.Generic;

namespace PL
{
    public abstract class StaticMenu : Menu
    {
        private Dictionary<ConsoleKey, Action> _binds = new Dictionary<ConsoleKey, Action>();
        private ConsoleKey _exitKey;
        private List<string> _view = new List<string>();

        protected abstract void SetupBindings(Dictionary<ConsoleKey, Action> binds);
        protected abstract void SetupView(List<string> view);

        protected override void Init(MenuInitArgs initArgs)
        {
            SetupView(_view);
            SetupBindings(_binds);
        }

        protected override void RunLoop()
        {
            bool wantExit = false;

            while (!wantExit)
            {
                Draw();
                HandleInput(ref wantExit);
            }
        }

        private void HandleInput(ref bool wantExit)
        {
            bool wasProcessed = false;

            while (!wasProcessed)
            {
                var actionKey = Console.ReadKey(true).Key;

                if (actionKey == _exitKey)
                {
                    wasProcessed = true;
                    wantExit = true;
                }

                if (_binds.ContainsKey(actionKey))
                {
                    _binds[actionKey].Invoke();
                    return; // для того что бы родительское меню перерисовывалось
                }
            }
        }

        protected override void Draw()
        {
            Console.Clear();

            foreach (var line in _view)
                Console.WriteLine(line);
        }

        protected void BindExit(ConsoleKey key) => _exitKey = key;
    }
}
