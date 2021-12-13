using BLL;
using System;

namespace PL
{
    class DeleteFootballPlayer : InitializationMenu
    {
      

        protected override void SetupViewQueue()
        {
            AddView("========== Delete Doctor ==========");
            AddView("Name: ", true);
            AddView("Surname: ", true);
        }

        protected override void OnInputFilled(string[] parameters)
        {
            FieldCollection initializer = new FieldCollection(1);

            initializer.Add("Name", parameters[0]);
            initializer.Add("Surname", parameters[1]);

            Registry.Delete<FootballPlayer>(initializer);
        }
    }
}
