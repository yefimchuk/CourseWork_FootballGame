using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
  class RegistryGameMenuInitArg : MenuInitArgs
    {
        public readonly IGameService service;

        public RegistryGameMenuInitArg(IGameService service) => this.service = service;
    }
}
