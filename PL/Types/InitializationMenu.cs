using System;
using System.Collections.Generic;

namespace PL
{
    public abstract class InitializationMenu : Menu
    {
        private int _currentPosition = 0;
        private int _maxPosition = 0;
        private List<string> _inputs = new List<string>();
        private List<ViewElement> _view = new List<ViewElement>();

        protected abstract void SetupViewQueue();
        protected abstract void OnInputFilled(string[] parameters);

        protected override void Init(MenuInitArgs initArgs) => SetupViewQueue();

        protected void AddView(string line, bool handleInputAfter = false)
        {
            if (handleInputAfter == true)
                _maxPosition++;
            else
                line += '\n';

            _view.Add(new ViewElement(
                line,
                handleInputAfter == true 
                ? _maxPosition - 1 
                : _maxPosition));
        }
        protected void AddEnumView(Type type)
        {
            if (type.IsEnum)
            {
                string[] names = Enum.GetNames(type);
                string newLine = string.Empty;

                for (int i = 0; i < names.Length; i++)
                    newLine += $"[{names[i]}: {i}] ";
                _view.Add(new ViewElement(newLine, _maxPosition));
            }

        }

        protected override void Draw()
        {
            foreach (var line in _view)
                if (line.Position == _currentPosition)
                    Console.Write(line);
        }

        protected override void RunLoop()
        {
            Console.Clear();

            while (_currentPosition < _maxPosition)
            {
                Draw();
                HandleInput();
                _currentPosition++;
            }

            OnInputFilled(_inputs.ToArray());
        }

        private void HandleInput() => _inputs.Add(Console.ReadLine());
    }
}
