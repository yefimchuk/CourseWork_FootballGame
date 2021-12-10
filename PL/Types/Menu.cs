using System.Collections.Generic;

namespace PL
{
    public abstract class Menu
    {
        public static void Run<T>(MenuInitArgs initArgs = null) where T : Menu, new()
        {
            T newMenu = new T();
      
            newMenu.Init(initArgs);
            newMenu.RunLoop();
        }

        protected abstract void Init(MenuInitArgs initArgs);
        protected abstract void RunLoop();
        protected abstract void Draw();
    }
}
