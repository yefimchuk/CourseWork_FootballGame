
namespace PL
{
    class PlayerFindMenu : InitializationMenu
    {
        protected override void SetupViewQueue()
        {
            AddView("========== Doctor Find ==========");
            AddView("Name: ", true);
            AddView("Surname: ", true);
        }

        protected override void OnInputFilled(string[] inputs)
        {
            _processedInputs.Add("Name", inputs[0]);
            _processedInputs.Add("Surname", inputs[1]);
        }

        protected override void PostInputHandle()
        {
            Run<FindedPlayerShowMenu>(new InputParametersInitArgs(_processedInputs));
        }
    }
}

