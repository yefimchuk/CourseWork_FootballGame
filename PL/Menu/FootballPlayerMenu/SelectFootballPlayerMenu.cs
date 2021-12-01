
using BLL;

namespace PL
{
    class SelectFootballPlayerMenu : InitializationMenu
    {
        private IFootBallService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is DoctorRegistryMenuInitArgs)
            {
                var args = (DoctorRegistryMenuInitArgs)initArgs;
                _service = args.service;
            }
        }

        protected override void SetupViewQueue()
        {
            AddView("========== Select Doctor ==========");
            AddView("Name: ", true);
            AddView("Surname: ", true);
        }

        protected override void OnInputFilled(string[] inputs)
        {
            var fieldCollection = new FieldCollection(2);

            fieldCollection.Add("Name", inputs[0]);
            fieldCollection.Add("Surname", inputs[1]);

            Run<ChangeFootballPlayerMenu>(new FootballPlayerChangeMenuInitArgs(_service, fieldCollection));
        }
    }
}
