﻿using BLL;
using System;

namespace PL
{
    class DeleteStadium : InitializationMenu
    {
       

        protected override void SetupViewQueue()
        {
            AddView("========== Delete Game ==========");
            AddEnumView(typeof(StadiumName));
            AddView("Name Stadium: ", true);
        }

        protected override void OnInputFilled(string[] parameters)
        {
            FieldCollection initializer = new FieldCollection(1);

            initializer.Add("Name Stadium", parameters[0].ToString());

            Registry.Delete<FootballStadium>(initializer);
        }
    }
}
