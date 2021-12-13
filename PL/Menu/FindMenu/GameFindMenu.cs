
namespace PL
{
    class GameFindMenu : InitializationMenu
    {
        protected override void SetupViewQueue()
        {
            AddView("========== Doctor Find ==========");
            AddView("Date of event: ", true);

            AddView("Select team 2 : ", true);

        }

        protected override void OnInputFilled(string[] inputs)
        {
            _processedInputs.Add("Date of Event", inputs[0]);
            _processedInputs.Add("Team Two", inputs[1]);

        }

        protected override void PostInputHandle()
        {
            Run<FindedGameMenu>(new InputParametersInitArgs(_processedInputs));
        }
    }
}
