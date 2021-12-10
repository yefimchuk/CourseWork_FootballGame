using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PL
{
    public class SortByDateGame : ShowMenu
    {
           private Registry _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            var args = initArgs as GameRegistryMenuInitArgs;

            if (args != null)
                _service = (Registry)args.service;
        }

        protected override void InitDemonstrationObjects(ref IDemonstrated[] objects) {
            objects = _service.GetAllGame().OrderBy(game=>game.DateOfEvent).ToArray();

         }
 

   
    }
}
