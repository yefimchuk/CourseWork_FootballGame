using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
    public class RegistryMenuInitArgs : MenuInitArgs
    {
        public readonly Registry service;

        public RegistryMenuInitArgs(Registry registry) => service = registry;
    }
}
