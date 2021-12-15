using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PL
{
    public class SortByLoss : ShowMenu
    {

        protected override void InitDemonstrationObjects(ref IDemonstrated[] objects)
        {
            objects = Registry.Load<FootballGame>().Where(game => game.Win == "Nobody").OrderBy(game => game.Win).ToArray();
        }
    }
}
