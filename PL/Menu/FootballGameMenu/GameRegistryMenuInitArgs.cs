using BLL;

namespace PL
{
    public class GameRegistryMenuInitArgs : MenuInitArgs
    {
        public readonly IGameService service;

        public GameRegistryMenuInitArgs(IGameService service) => this.service = service;
    }
}
