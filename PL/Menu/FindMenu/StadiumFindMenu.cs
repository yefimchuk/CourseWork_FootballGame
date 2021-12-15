using BLL;
using System;
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
            _processedInputs.Add("Name Stadium", Enum.Parse<StadiumName>(inputs[0]));

        }

        protected override void PostInputHandle()
        {
            Run<FindedStadiumMenu>(new InputParametersInitArgs(_processedInputs));
        }
    }
}


