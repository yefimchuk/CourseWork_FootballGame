
using BLL;

namespace PL
{
    class SelectGameMenu : InitializationMenu
    {
        private IGameService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is GameRegistryMenuInitArgs)
            {
                var args = (GameRegistryMenuInitArgs)initArgs;
                _service = args.service;
            }
        }

        protected override void SetupViewQueue()
        {
            AddView("========== Select the game ==========");
            AddView("Input the data of event: ", true);

        }

        protected override void OnInputFilled(string[] inputs)
        {
            var fieldCollection = new FieldCollection(1);

            fieldCollection.Add("Date of Event", inputs[0]);

            Run<GameChangeMenu>(new GameChangeMenuInitArgs(_service, fieldCollection));
        }
    }
}
