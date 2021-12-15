using BLL;
using System;

namespace PL
{
    public class DeleteGamePlayer : InitializationMenu
    {

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);
            if (initArgs is InputParametersInitArgs args)
                _processedInputs = args.fields[0];
        }

        protected override void SetupViewQueue()
        {
            AddView("========== Add ==========");
            AddView("Name: ", true);
            AddView("Surname: ", true);

        }

        protected override void OnInputFilled(string[] inputs)
        {
            FieldCollection parameters = new FieldCollection(2);
            parameters.Add("Name", inputs[0]);
            parameters.Add("Surname", inputs[1]);

            FootballPlayer[] footballPlayer = Registry.Find<FootballPlayer>(parameters);
            Registry.DeleteGamePlayer(_processedInputs, footballPlayer[0]);

           

        }




    }
}
