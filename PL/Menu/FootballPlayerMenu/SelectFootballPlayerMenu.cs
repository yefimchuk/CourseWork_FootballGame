
using BLL;

namespace PL
{
    class SelectFootballPlayerMenu : InitializationMenu
    {
       

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

            Run<ChangeFootballPlayerMenu>(new InputParametersInitArgs(fieldCollection));
        }
    }
}
