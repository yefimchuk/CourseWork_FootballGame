using BLL;
using System.Collections.Generic;
using System;

namespace PL
{
    public class ShowGameMenu : ShowMenu
    {

        protected override void InitDemonstrationObjects(ref IDemonstrated[] objects)
        {
            /* List<IDemonstrated> demonstrateds = new( Registry.Load<FootballGame>());*/
            objects = Registry.Load<FootballGame>();






        }
    }
}
