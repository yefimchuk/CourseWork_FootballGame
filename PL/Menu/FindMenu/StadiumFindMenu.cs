
namespace PL
{
    class StadiumFindMenu : InitializationMenu
    {
        protected override void SetupViewQueue()
        {
            AddView("========== Stadium Find ==========");
            AddView("input name of stadium : ", true);

        }

        protected override void OnInputFilled(string[] inputs)
        {
            _processedInputs.Add("Name Stadium", inputs[0]);

        }

        protected override void PostInputHandle()
        {
            Run<FindedStadiumMenu>(new InputParametersInitArgs(_processedInputs));
        }
    }
}


