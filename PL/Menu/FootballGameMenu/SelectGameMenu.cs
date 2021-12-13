
using BLL;

namespace PL
{
    class SelectGameMenu : InitializationMenu
    {
       

        protected override void SetupViewQueue()
        {
            AddView("========== Select the game ==========");
            AddView("Input the data of event: ", true);

        }

        protected override void OnInputFilled(string[] inputs)
        {


            _processedInputs.Add("Date of Event", inputs[0]);


        }
        protected override void PostInputHandle()
        {

            Run<GameChangeMenu>(new InputParametersInitArgs(_processedInputs));

        }
    }
}
