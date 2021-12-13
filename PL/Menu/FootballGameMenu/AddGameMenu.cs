using BLL;
using System;

namespace PL
{
    public class AddGamenMenu : InitializationMenu
    {
      

        protected override void SetupViewQueue()
        {

            AddView("========== Add ==========");
            AddEnumView(typeof(Teams)); 
            AddView("\nSelect the first team: ", true);
            AddEnumView(typeof(Teams));
            AddView("\nSelect the second team: ", true);
            AddView("Date of Event: ", true);
            AddEnumView(typeof(PlaceGame));
            AddView("\nPlaceGame", true);
            AddView("Number of spectators: ", true);
      
 
        }

        protected override void OnInputFilled(string[] inputs)
        {
            FieldCollection parameters = new FieldCollection(5);

            parameters.Add("Team One", Enum.Parse<Teams>(inputs[0]));
            parameters.Add("Team Two", Enum.Parse<Teams>(inputs[1]));
            parameters.Add("Date of Event", DateTime.Parse(inputs[2]));
            parameters.Add("Place game", Enum.Parse<PlaceGame>(inputs[3]));
            parameters.Add("Number of spectators", int.Parse(inputs[4]));      
            Registry.Add<FootballGame>(parameters);
        }
    }
}
