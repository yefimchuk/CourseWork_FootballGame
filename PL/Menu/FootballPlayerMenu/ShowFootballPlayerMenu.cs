using BLL;

namespace PL
{
    public class ShowFootballPlayerMenu : ShowMenu
    {
        private Registry _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            var args = initArgs as RegistryMenuInitArgs;

            if (args != null)
                _service = args.service;
        }

        protected override void InitDemonstrationObjects(ref IDemonstrated[] objects) => objects = _service.GetAllDoctors();
    }
}
