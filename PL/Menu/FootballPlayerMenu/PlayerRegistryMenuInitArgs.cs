using BLL;

namespace PL
{
    public class PlayerRegistryMenuInitArgs : MenuInitArgs
    {
        public readonly IFootBallService service;

        public PlayerRegistryMenuInitArgs(IFootBallService service) => this.service = service;
    }
}
