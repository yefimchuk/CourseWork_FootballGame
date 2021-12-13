using BLL;
using System;

namespace PL
{
    class DeleteGame : InitializationMenu
    {
       
        protected override void SetupViewQueue()
        {
            AddView("========== Delete Game ==========");
            AddView("Date of Event: ", true);
        }

        protected override void OnInputFilled(string[] parameters)
        {
            FieldCollection initializer = new FieldCollection(1);

            initializer.Add("Date of Event", DateTime.Parse(parameters[0])); 


            Registry.Delete<FootballGame>(initializer);
        }
    }
}
