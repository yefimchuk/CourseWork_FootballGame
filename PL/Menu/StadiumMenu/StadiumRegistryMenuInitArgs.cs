using BLL;

namespace PL
{
    public class StadiumRegistryMenuInitArgs : MenuInitArgs
    {
        public readonly IStadiumService service;

        public StadiumRegistryMenuInitArgs(IStadiumService service) => this.service = service;
    }
}

