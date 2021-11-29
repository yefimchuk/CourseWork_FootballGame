using BLL;
using System;

namespace PL
{
    public abstract class ShowMenu : Menu
    {
        private IDemonstrated[] _objects;

        protected override void Draw()
        {
            Console.Clear();

            foreach (var obj in _objects)
                Console.WriteLine(obj.GetDemonstrationString() + '\n');
        }

        protected override void Init(MenuInitArgs initArgs) { }

        protected override void RunLoop()
        {
            InitDemonstrationObjects(ref _objects);

            Draw();

            Console.Write("Press any key...");
            Console.ReadKey(true);
        }

        protected abstract void InitDemonstrationObjects(ref IDemonstrated[] objects);
    }
}
