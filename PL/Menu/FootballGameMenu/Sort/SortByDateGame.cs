using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PL
{
    public class SortByDateGame : ShowMenu
    {
        protected override void InitDemonstrationObjects(ref IDemonstrated[] objects)
        {
            objects = Registry.Load<FootballGame>().OrderBy(game => game.DateOfEvent).ToArray();
        } 
    }
}
