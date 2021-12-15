
using BLL;

namespace PL
{
    class SelectStadiumMenu : InitializationMenu
    {
      

        protected override void SetupViewQueue()
        {
            AddView("========== Select the game ==========");
            AddEnumView(typeof(StadiumName));
            AddView("Input name of stadium: ", true);

        }

        protected override void OnInputFilled(string[] inputs)
        {
            var fieldCollection = new FieldCollection(1);

            fieldCollection.Add("Name Stadium", System.Enum.Parse<StadiumName>(inputs[0]));
            Run<ChangeStadiumMenu>(new InputParametersInitArgs(fieldCollection));
        }
    }
}

