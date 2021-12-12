
using BLL;

namespace PL
{
    class SelectStadiumMenu : InitializationMenu
    {
        private IStadiumService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is StadiumRegistryMenuInitArgs)
            {
                var args = (StadiumRegistryMenuInitArgs)initArgs;
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

            fieldCollection.Add("Name Stadium", inputs[0].ToString());
            Run<ChangeStadiumMenu>(new StadiumChangeMenuInitArgs(_service, fieldCollection));
        }
    }
}

